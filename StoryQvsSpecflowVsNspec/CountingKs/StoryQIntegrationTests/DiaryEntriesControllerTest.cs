using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using NUnit.Framework;
using StoryQ;
using StoryQIntegrationTests.Helpers;

namespace StoryQIntegrationTests
{
    [TestFixture]
    public class DiaryEntriesControllerTest
    {
        
        private readonly Feature feature =
                       new Story("To verify DiaryEntries Controller")
                         .InOrderTo(" test how the DiaryEntriesController works")
                        .AsA("team")
                        .IWant("to valid this controller");

        public string DiaryEntriesUri = "http://localhost:8901/api/user/diaries/2015-05-07/entries";
        public string HeaderValue = "";

        
    [Test]
    public void DiaryEntriesControllerTest_GETResponse()
    {
        string ExpectedJson = @"{""url"":""http://localhost:8901/api/user/diaries/2015-05-07/entries/1"",""foodDescription"":""Turkey, All Classes, Meat&Skn&Giblets&Neck, Raw"",""measureDescription"":""1 Turkey"",""measureUrl"":""http://localhost:8901/api/nutrition/foods/912/measures/1595"",""quantity"":1.5}";
        this.feature.WithScenario(" GET Response validation for DiaryEntriesController")
        .Given(TheRequestHasHeaderValue, "application/json")
        .When(CommonSteps.TheRequestIsSentToUri, (DiaryEntriesUri + "/1"), "application/json", HttpMethod.Get)
        .Then(IShouldGetHttpStatusCode, HttpStatusCode.OK)
        .And(IShouldGetResponseInJsonFormat, ExpectedJson)
        .Execute();
    }

    [Test]
    public void DiaryEntriesControllerTest_POSTResponse()
    {
        string body = @"{""quantity"":105,""measureUrl"":""http://localhost:8901/api/nutrition/foods/3632/measures/5777""}";
        this.feature.WithScenario("POST Response validation for DiaryEntriesController")
        .Given(TheRequestHasHeaderValue, "application/json")
        .When(CommonSteps.TheRequestIsSentToUriWithBody, DiaryEntriesUri, "application/json", HttpMethod.Post, body)
        .Then(IShouldGetHttpStatusCode, HttpStatusCode.Created)
        .Execute();
    }


    [Test]
    public void DiaryEntriesControllerTest_POSTResponse_BadRequest()
    {
      string body = @"{""quantity"":105,""measureUrl"":""http://localhost:8901/api/nutrition/foods/4280/measures/6924""}";
        this.feature.WithScenario(("POST BadRequest Response validation for DiaryEntriesController"))
            .Given(TheRequestHasHeaderValue, "application/json")
            .When(CommonSteps.TheRequestIsSentToUriWithBody, DiaryEntriesUri, "application/json", HttpMethod.Post, body)
            .Then(IShouldGetHttpStatusCode, HttpStatusCode.BadRequest)
            .Execute();
    }


    private void TheRequestHasHeaderValue(string headerValue)
    {
        HeaderValue = headerValue;
    }

    private void IShouldGetResponseInJsonFormat(string ExpectedJson)
    {
        string ActualJson = CommonSteps.response.Content.ReadAsStringAsync().Result;
        Assert.AreEqual(ExpectedJson,ActualJson);
    }

    private void IShouldGetHttpStatusCode(HttpStatusCode statusCode)
    {
        Assert.AreEqual(statusCode, CommonSteps.response.StatusCode);
    }
    
    
    
    
    }

}