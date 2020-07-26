//////////////////////////////////////////////////////////////////////
// NUGET PACKAGES
//////////////////////////////////////////////////////////////////////
#tool nuget:?package=NUnit.ConsoleRunner&version=3.10.0
#tool nuget:?package=JetBrains.dotCover.CommandLineTools&version=2019.2.3
#tool nuget:?package=ReportGenerator&version=4.3.6
#tool nuget:?package=Codecov&version=1.8.0
#tool nuget:?package=GitVersion.CommandLine&version=5.1.2

//////////////////////////////////////////////////////////////////////
// CAKE ADDINS
//////////////////////////////////////////////////////////////////////
#addin nuget:?package=Octokit&version=0.32.0
#addin nuget:?package=Cake.Codecov&version=0.7.0

//////////////////////////////////////////////////////////////////////
// IMPORTS
//////////////////////////////////////////////////////////////////////
using Octokit;
using System.Xml;

//////////////////////////////////////////////////////////////////////
// PROJECT VARIABLES
//////////////////////////////////////////////////////////////////////
var projectName = "Kapture";
var authorName = "kalilistic";
var packageName = "Kapture";
var packageDescription = "FFXIV ACT Loot Tracker Plugin";
var packageTags = "FFXIV ACT plugin loot";

//////////////////////////////////////////////////////////////////////
// ARGUMENT VARIABLES
//////////////////////////////////////////////////////////////////////
var target = Argument ("target", "Default");
var configuration = Argument ("configuration", "Release");
var verbosity = Argument<string> ("verbosity", "Information");

//////////////////////////////////////////////////////////////////////
// ENVIRONMENT VARIABLES
//////////////////////////////////////////////////////////////////////
var githubToken = EnvironmentVariable ("GITHUB_TOKEN");

//////////////////////////////////////////////////////////////////////
// BUILD SYSTEM VARIABLES
//////////////////////////////////////////////////////////////////////
var isLocalBuild = BuildSystem.IsLocalBuild;

//////////////////////////////////////////////////////////////////////
// OTHER GLOBAL VARIABLES
//////////////////////////////////////////////////////////////////////
var buildDir = Directory ("./src") + Directory (projectName) + Directory ("bin") + Directory (configuration);
var buildFilePath = Directory (buildDir) + File (projectName + ".dll");
var solutionFile = Directory ("./src") + File (projectName + ".sln");
var testResultDir = Directory ("./test-result");
var testResultFile = testResultDir + File ("NUnitResults.xml");
var coverageReportXML = testResultDir + File ("result.xml");
var version = string.Empty;
var buildSuccess = true;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task ("Clean")
    .Does (() => {
        CleanDirectory (buildDir);
        Information ("Build directory cleaned.");
    });

Task ("Restore-Nuget-Packages")
    .IsDependentOn ("Clean")
    .Does (() => {
        NuGetRestore (solutionFile);
    });

Task ("Set-Version")
    .IsDependentOn ("Restore-Nuget-Packages")
    .Does (() => {
        if (isLocalBuild) {
            version = "1.0.0-LOCAL";
        } else {
            version = GitVersion ().SemVer;
        }
        Information ("Version set to " + version);
    });

Task ("Create-Assembly-Info")
    .WithCriteria (!isLocalBuild)
    .IsDependentOn ("Set-Version")
    .Does (() => {
        GitVersion (new GitVersionSettings {
            UpdateAssemblyInfo = true
        });
        Information ("Assembly info updated.");
    });

Task ("Build")
    .IsDependentOn ("Create-Assembly-Info")
    .Does (() => {
        MSBuild (solutionFile, settings =>
            settings.SetConfiguration (configuration));
    })
    .OnError (exception => {
        buildSuccess = false;
    });

Task ("Run-Unit-Tests")
    .WithCriteria (buildSuccess)
    .IsDependentOn ("Build")
    .Does (() => {
        MSBuild (solutionFile, settings =>
            settings.SetConfiguration ("Debug"));
        var testsPath = "./src/**/bin/Debug/*.Test.dll";
        var coverageReportDCVR = testResultDir + File ("result.dcvr");
        DotCoverCover (tool => {
                tool.NUnit3 (
                    testsPath, 
                    new NUnit3Settings {
                        Results = new [] { new NUnit3Result { FileName = testResultFile } },
                        ShadowCopy = false
                    });
            },
            new FilePath (coverageReportDCVR),
            new DotCoverCoverSettings ()
                .WithFilter("+:" + projectName)
                .WithFilter("-:" + projectName + ".Test"));
        DotCoverReport (new FilePath (coverageReportDCVR),
            new FilePath (coverageReportXML),
            new DotCoverReportSettings {
                ReportType = DotCoverReportType.DetailedXML
            });
    })
    .OnError (exception => {
        buildSuccess = false;
    });

Task ("Publish-Github-Release")
    .WithCriteria (buildSuccess)
    .WithCriteria (!isLocalBuild)
    .IsDependentOn ("Run-Unit-Tests")
    .Does (async () => {
        var gitTag = "v" + version;
        var client = new GitHubClient (new ProductHeaderValue (projectName));
        var tokenAuth = new Credentials (githubToken);
        client.Credentials = tokenAuth;
        var newRelease = new NewRelease (gitTag);
        newRelease.Name = "Version " + version;
        newRelease.Body = "This is a pre-release and may not be stable.";
        newRelease.Draft = false;
        newRelease.Prerelease = true;
        await client.Repository.Release.Create (authorName, projectName, newRelease);
        using (var fileStream = System.IO.File.OpenRead (buildFilePath)) {
            var assetUpload = new ReleaseAssetUpload () {
            FileName = projectName + ".dll",
            ContentType = "application/x-msdownload",
            RawData = fileStream
            };
            var release = await client.Repository.Release.Get (authorName, projectName, gitTag);
            await client.Repository.Release.UploadAsset (release, assetUpload);
        }
        Information ("Created GitHub release.");
    });

Task ("Check-Build-Status")
    .IsDependentOn ("Publish-Github-Release")
    .Does (() => {
        if (buildSuccess) {
            Information ("Tasks complete.");
        } else {
            throw new Exception ("Build failed.");
        }
    });

Task ("Default")
    .IsDependentOn ("Clean")
    .IsDependentOn ("Restore-Nuget-Packages")
    .IsDependentOn ("Set-Version")
    .IsDependentOn ("Create-Assembly-Info")
    .IsDependentOn ("Build")
    .IsDependentOn ("Run-Unit-Tests")
    .IsDependentOn ("Publish-Github-Release")
    .IsDependentOn ("Check-Build-Status");

RunTarget (target);