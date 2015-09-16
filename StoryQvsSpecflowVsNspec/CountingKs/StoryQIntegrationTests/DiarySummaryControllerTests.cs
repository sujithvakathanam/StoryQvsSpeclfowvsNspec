using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using NUnit.Framework;
using StoryQ;
using System.Web.Http;
using System.Net.Http;
using StoryQIntegrationTests.Helpers;

namespace StoryQIntegrationTests
{
    [TestFixture]
    public class DiarySummaryControllerTests
    {
        private readonly Feature feature =
                               new Story("To verify DiarySummary Controller")
                                 .InOrderTo(" test how the DiarySummaryController works")
                                .AsA("team")
                                .IWant("to valid this controller");

        public string DiarySummaryUri = "http://localhost:8901/api/user/diaries/2015-05-07/summary";
      
        private string _headerValue = "";
       
        [Test]
        public void DiarySummaryTest_GETResponse()
        {
            string ExpectedJson = @"{""diaryDate"":""2015-05-07T00:00:00"",""totalCalories"":44143.0}";
            this.feature.WithScenario(" GET Response validation for DiarySummaryController")
            .Given(TheRequestHasHeaderValue, "application/json")
            .When(CommonSteps.TheRequestIsSentToUri, DiarySummaryUri, "application/json",HttpMethod.Get)
            .Then(IShouldGetHttpStatusCode_, HttpStatusCode.OK)
            .And(IShouldGetResponseInJsonFormat,ExpectedJson)
            .Execute();
        }

        private void IShouldGetResponseInJsonFormat(string ExpectedJson)
        {
            string json = CommonSteps.response.Content.ReadAsStringAsync().Result;
            
            Assert.AreEqual(ExpectedJson, json);
        }


        private void IShouldGetHttpStatusCode_(HttpStatusCode statusCode)
        {
 	        Assert.AreEqual(statusCode,CommonSteps.response.StatusCode);
        }

        private void TheRequestHasHeaderValue(string headerValue)
        {
            _headerValue = headerValue;
        }
      
    }
}