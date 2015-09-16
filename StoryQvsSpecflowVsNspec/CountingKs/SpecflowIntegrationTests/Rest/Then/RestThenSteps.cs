using System;
using System.Net;
using System.Text.RegularExpressions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AcceptanceTests.TestContexts;

namespace AcceptanceTests.Rest.Then
{
    [Binding]
    [Scope(Tag = "TestSupport.Rest")]
    public class RestThenSteps
    {

        private readonly RestContext _requestContext;

        public RestThenSteps(RestContext requestContext)
        {
            _requestContext = requestContext;

        }


        [Then(@"the server returns response code (.*)")]
        public void ThenTheServerResponseCode(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode, _requestContext.HttpResponseMessage.StatusCode);
        }

        [Then("the response has the following body")]
        public void TheResponseHasTheFollowingBody(string expectedResponseBody)
        {
            AssertMatch(expectedResponseBody, _requestContext.HttpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Match strings either literally or by a regex.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        private static void AssertMatch(string expected, string actual)
        {
            // Perform regex search if term is contained within forward slashes.
            if (expected.StartsWith("/") && expected.EndsWith("/"))
            {
                Assert.IsTrue(
                    Regex.IsMatch(actual, expected.Substring(1, expected.Length - 2)),
                    String.Format("The header value {0} does not match the expected regular expression {1}", actual,
                                  expected));
            }
            else
            {
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
