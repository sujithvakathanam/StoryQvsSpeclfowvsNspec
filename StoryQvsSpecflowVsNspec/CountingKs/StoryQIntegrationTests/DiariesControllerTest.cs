using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using NUnit.Framework;
using StoryQ;
using StoryQIntegrationTests.Helpers;

namespace StoryQIntegrationTests
{
    [TestFixture]
    public class DiariesControllerTest
    {
        
        private readonly Feature feature =
                               new Story("To verify Diaries Controller")
                                 .InOrderTo(" test how the DiariesController works")
                                .AsA("team")
                                .IWant("to valid this controller");

        public string DiariesUri = "http://localhost:8901/api/user/diaries/2015-05-07";
        public string HeaderValue = "";

        private HttpResponseMessage _response;

        
        [Test]
        public void DiariesControllerTest_GETResponse()
        {
            this.feature.WithScenario(" GET Response validation for DiariesController")
            .Given(TheRequestHasHeaderValue, "application/json")
            .When(TheRequestIsSentToUri, DiariesUri, HeaderValue, HttpMethod.Get)
            .Then(IShouldGetHttpStatusCode, HttpStatusCode.OK)
            .Execute();
        }

        private void IShouldGetHttpStatusCode(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode,_response.StatusCode);
            
        }

        private void TheRequestIsSentToUri(string url, string methodVariable, HttpMethod method)
        {

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(method, new Uri(url));
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValue));
                _response = client.SendAsync(request, new CancellationTokenSource().Token).Result;

            }
        }

        private void TheRequestHasHeaderValue(string headerValue)
        {
            HeaderValue = headerValue;
        }

    }
}