
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using NunitIntegrationTests.Domain;

namespace NunitIntegrationTests
{

    using System.Web;
    using System.Web.Http;
    using NUnit.Framework;
    using System.Net.Http.Formatting;
    using System.Net.Http;
    //using Newtonsoft.Json;
    
    [TestFixture]
    public class IntegrationTest
    {
        private HttpClient client;

        [SetUp]
        public void HttpClientSetup()
        {
 
            client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
        }

        // DiarySummary Controller
        [Test]
        public void GetDiarySummaryTest()
        {
            var url = "http://localhost:8901/api/user/diaries/2015-05-07/summary";
            var request = HttpRequestMethods.CreateRequest(url, "application/json", HttpMethod.Get);
            HttpResponseMessage response = this.client.SendAsync(request, new CancellationTokenSource().Token).Result;
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(response.Content);
        }

        //Diaries Contrtoller
        [Test]
        public void GetDiariesTest()
        {
            var url = "http://localhost:8901/api/user/diaries/2015-05-07";
            var request = HttpRequestMethods.CreateRequest(url, "application/json", HttpMethod.Get);
            HttpResponseMessage response = this.client.SendAsync(request, new CancellationTokenSource().Token).Result;
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(response);
        }


        //DiaryEntries Controller
        [Test]
        public void GetDiaryEntriesTest()
        {
            var url = "http://localhost:8901/api/user/diaries/2015-05-07/entries";
            var request = HttpRequestMethods.CreateRequest(url, "application/json", HttpMethod.Get);
            HttpResponseMessage response = this.client.SendAsync(request, new CancellationTokenSource().Token).Result;
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(response);
        }

        //DiaryEntries Controller
        [Test]
        public void PostDiaryEntriesTest()
        {
            var url = "http://localhost:8901/api/user/diaries/2015-05-07/entries";

            var requestBody = new Record { Quantity = 105, MeasureUrl = "http://localhost:8901/api/nutrition/foods/4087/measures/6586" };
            var request = HttpRequestMethods.CreateRequest(url, "application/json", HttpMethod.Post, requestBody,
                                                           new JsonMediaTypeFormatter());
            HttpResponseMessage response = this.client.SendAsync(request, new CancellationTokenSource().Token).Result;

            Assert.True(response.IsSuccessStatusCode);
            Assert.AreEqual(response.ReasonPhrase,"Created");
            Assert.NotNull(response.Content);
        }

        //DiaryEntriesController
        [Test]
        public void PostDiaryEntries_BadRequest_Test()
        {
            var url = "http://localhost:8901/api/user/diaries/2015-05-07/entries";

            var requestBody = new Record { Quantity = 105, MeasureUrl = "http://localhost:8901/api/nutrition/foods/4280/measures/6924" };
            var request = HttpRequestMethods.CreateRequest(url, "application/json", HttpMethod.Post, requestBody,
                                                           new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.SendAsync(request, new CancellationTokenSource().Token).Result;
            
            Assert.AreEqual(response.ReasonPhrase, "Bad Request");

            string responseContent = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseContent);
        }

    }
}