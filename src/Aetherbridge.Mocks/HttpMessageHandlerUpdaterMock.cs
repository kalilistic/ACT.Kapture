using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ACT_FFXIV.Aetherbridge.Mocks.Properties;

namespace ACT_FFXIV.Aetherbridge.Mocks
{
	public class HttpMessageHandlerUpdaterMock : HttpMessageHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			var isRateLimited = request.RequestUri.ToString().ToUpper().Contains("RATE-LIMITED");
			var isBadRepoName = request.RequestUri.ToString().ToUpper().Contains("BAD-REPO");
			var isOtherError = request.RequestUri.ToString().ToUpper().Contains("OTHER-ERROR");
			var isPageRequest = request.RequestUri.Query.ToUpper().Contains("PAGE");
			var isReleasesRequest = request.RequestUri.ToString().ToUpper().EndsWith("RELEASES");
			var isAssetUrlsRequest = request.RequestUri.ToString().ToUpper().EndsWith("ASSETS");
			var responseMessage = new HttpResponseMessage();
			string response;
			string headers;
			HttpStatusCode status;

			if (isRateLimited)
			{
				status = HttpStatusCode.Forbidden;
				headers = Resources.rate_limit_headers_403;
				response = Resources.rate_limit_response_403;
			}
			else if (isBadRepoName)
			{
				status = HttpStatusCode.NotFound;
				headers = Resources.repo_not_found_headers_404;
				response = Resources.repo_not_found_response_404;
			}
			else if (isOtherError)
			{
				status = HttpStatusCode.GatewayTimeout;
				headers = Resources.repo_not_found_headers_404;
				response = "GitHub API is broken.";
			}
			else if (isReleasesRequest || isPageRequest)
			{
				status = HttpStatusCode.OK;
				var pageNumber = isPageRequest
					? Convert.ToInt32(request.RequestUri.Query.Split('=').Last())
					: 1;

				switch (pageNumber)
				{
					case 1:
						headers = Resources.page1_headers_200;
						response = Resources.page1_response_200;
						break;
					case 2:
						headers = Resources.page2_headers_200;
						response = Resources.page2_response_200;
						break;
					case 3:
						headers = Resources.page3_headers_200;
						response = Resources.page3_response_200;
						break;
					case 4:
						headers = Resources.page4_headers_200;
						response = Resources.page4_response_200;
						break;
					case 5:
						headers = Resources.page5_headers_200;
						response = Resources.page5_response_200;
						break;
					default:
						throw new Exception("Bad page number.");
				}
			}
			else if (isAssetUrlsRequest)
			{
				status = HttpStatusCode.OK;
				headers = Resources.assets_headers_200;
				response = Resources.assets_response_200;
			}
			else
			{
				status = HttpStatusCode.OK;
				headers = Resources.assets_headers_200;
				response = "This is a sample downloaded file";
			}

			responseMessage.StatusCode = status;
			responseMessage.Content = new StringContent(response);
			AddHeaders(responseMessage, headers);

			return await Task.FromResult(responseMessage);
		}

		private static void AddHeaders(HttpResponseMessage responseMessage, string headersString)
		{
			var headerLines = headersString.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			foreach (var headerLine in headerLines)
			{
				var header = headerLine.Split(new[] {": "}, StringSplitOptions.RemoveEmptyEntries);
				responseMessage.Headers.Add(header[0], new List<string> {header[1]});
			}
		}
	}
}