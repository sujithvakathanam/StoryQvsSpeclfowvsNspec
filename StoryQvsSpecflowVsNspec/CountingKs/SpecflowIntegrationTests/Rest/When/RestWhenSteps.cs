using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using AcceptanceTests.TestContexts;
using System.Configuration;

namespace AcceptanceTests.Rest.When
{
    [Binding]
    [Scope(Tag = "TestSupport.Rest")]
    public class RestWhenSteps
    {
        private readonly RestContext _requestContext;

        public RestWhenSteps(RestContext requestContext)
        {
            _requestContext = requestContext;
        }


        [When("the request is sent as a (.*) to (.*)")]
        public void WhenTheRequestIsSentAsATo(string httpMethod, string url)
        {
            _requestContext.HttpRequestMessage.Method = new HttpMethod(httpMethod);
            url = ReplaceBaseUrlToken(url);
            _requestContext.HttpRequestMessage.RequestUri = new Uri(url);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();

            _requestContext.HttpResponseMessage = client.SendAsync(_requestContext.HttpRequestMessage).Result;
        }

        private string ReplaceBaseUrlToken(string url)
        {
            var result = Regex.Match(url, "#.*#");
            if (result.Length == 0) return url;

            string token = result.Value.Substring(1, result.Value.Length - 2);
            string tokenReplacement = ConfigurationManager.AppSettings[token];
            if (tokenReplacement == null)
            {
                throw new InvalidOperationException(string.Format("Missing app settings: {0}", token));
            }
            return url.Replace(String.Concat("#", token, '#'), tokenReplacement);
        }

    }
}
