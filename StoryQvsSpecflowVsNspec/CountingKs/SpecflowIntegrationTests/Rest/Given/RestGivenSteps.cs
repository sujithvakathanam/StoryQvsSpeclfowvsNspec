using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using AcceptanceTests.Rest.When;
using TechTalk.SpecFlow;
using AcceptanceTests.TestContexts;

namespace AcceptanceTests.Rest.Given
{
    [Binding]
    [Scope(Tag = "TestSupport.Rest")]
    public class RestGivenSteps
    {

        private readonly RestContext _restContext;
        private StringContent _stringContent;
        

        public RestGivenSteps(RestContext restContext)
        {
            _restContext = restContext;
        }

        [Given("the request has the content type (.*) and the following body")]
        public void GivenTheRequestHasTheContentTypeAndTheFollowingBody(string contentType, string message)
        {
            _stringContent = new StringContent(message, Encoding.UTF8, contentType);
            _restContext.HttpRequestMessage.Content = new StringContent(message, Encoding.UTF8, contentType);
        }

        [Given(@"the request has the following header values")]
        public void GivenTheRequestHasTheFollowingHeaderValues(Table headers)
        {
            foreach (var header in headers.Rows)
            {
                _restContext.HttpRequestMessage.Headers.Add(header["header"], header["value"]);
            }
        }

        [Given(@"the request has already been (.*)ed successfully to (.*)")]
        public void GivenTheRequestHasAlreadyBeenPostedSuccessfully(string httpMethod, string url)
        {
            _restContext.HttpRequestMessage.Method = new HttpMethod(httpMethod);
            url = ReplaceBaseUrlToken(url);
            _restContext.HttpRequestMessage.RequestUri = new Uri(url);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();

            _restContext.HttpResponseMessage = client.SendAsync(_restContext.HttpRequestMessage).Result;
        }

        [Given(@"there is already a Diary Entry with EntryId as following")]
        public void GivenThereIsAlreadyADiaryEntryWithEntryIdAsFollowing(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        private string ReplaceBaseUrlToken(string url)
        {
            var result = Regex.Match(url, "#.*#");

            if (result.Length == 0) return url;

            string token = result.Value.Substring(1, result.Value.Length - 2);
            string tokenReplacement = ConfigurationManager.AppSettings[token];

            if (tokenReplacement == null)
                throw new InvalidOperationException(String.Format("Missing app setting: {0}", token));

            return url.Replace(String.Concat("#", token, "#"), tokenReplacement);
        }


    }
}
