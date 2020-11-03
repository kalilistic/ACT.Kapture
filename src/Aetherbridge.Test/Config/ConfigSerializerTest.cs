using System;
using System.IO;
using NUnit.Framework;

namespace ACT_FFXIV.Aetherbridge.Test
{
	[TestFixture]
	public class ConfigSerializerTest
	{
		[SetUp]
		public void TestInitialize()
		{
			_testFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TestFile);
		}

		[TearDown]
		public void TestCleanup()
		{
			try
			{
				File.Delete(_testFilePath);
			}
			catch (Exception)
			{
				// ignored
			}
		}

		private const string TestFile = "Test.xml";
		private const string TestObjectName = "John";
		private string _testFilePath = "";

		[Test]
		public void WriteXml_BadPath_NoError()
		{
			var objectIn = new TestObject {Name = TestObjectName};
			ConfigSerializer.WriteXml(null, objectIn);
		}

		[Test]
		public void WriteXml_NoFile_NoError()
		{
			ConfigSerializer.ReadXml(_testFilePath, new TestObject());
		}

		[Test]
		public void WriteXml_ReadXml_SavesFile()
		{
			var objectIn = new TestObject {Name = TestObjectName};
			ConfigSerializer.WriteXml(_testFilePath, objectIn);

			TestObject objectOut = ConfigSerializer.ReadXml(_testFilePath, objectIn);
			Assert.AreEqual(TestObjectName, objectOut.Name);
		}
	}
}