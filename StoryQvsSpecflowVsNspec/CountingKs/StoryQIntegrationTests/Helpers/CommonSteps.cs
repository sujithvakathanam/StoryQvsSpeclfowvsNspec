using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;

namespace StoryQIntegrationTests.Helpers
{
    public static class CommonSteps
    {
        public static HttpResponseMessage response;

        public static void TheRequestIsSentToUri(string url, string headerValue, HttpMethod method)
        {

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage { RequestUri = new Uri(url) };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(headerValue));
                request.Method = method;
                response = client.SendAsync(request, new CancellationTokenSource().Token).Result;
                
            }
        }

        public static void TheRequestIsSentToUriWithBody(string url, string headerValue, HttpMethod method, string body)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage {RequestUri = new Uri(url)};
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(headerValue));
                request.Method = method;
                response = client.SendAsync(request, new CancellationTokenSource().Token).Result;
            }
        }
    }
}