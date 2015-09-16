using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using LightBDD;
using NUnit.Framework;
using System.Net.Http;

namespace LightBDDTests
{
    [Description(
        @"Inorder to checked DiariesController
        As a user
        I want to check this controller"
        )]
    [TestFixture]
    [Label("Story1")]
    public partial class DiariesControllerFeature
    {
        public string DiariesUri = "http://localhost:8901/api/user/diaries/2015-05-07";

   
        [Test]
        public void Diaries_Controller_Get_Response()
        {
            Runner.RunScenario(
                given => Request_has_HeaderValue("application/json"),
                when => Request_is_sent_to_Uri(DiariesUri, HeaderValue, HttpMethod.Get),
                then => I_Should_get_StatusCode(HttpStatusCode.OK)
                );
        }
    }

    //Below part is for implementation
    public partial class DiariesControllerFeature : FeatureFixture
    {
        protected BDDRunner Runner { get; private set; }

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Runner = new BDDRunner(GetType(), CreateProgressNotifier());
        }

        private string HeaderValue = "";
        private HttpResponseMessage _response;

       
        private void Request_has_HeaderValue(string headerValue)
        {
            HeaderValue = headerValue;
        }

        private void Request_is_sent_to_Uri(string url, string methodVariable, HttpMethod method)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(method, new Uri(url));
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValue));
                _response = client.SendAsync(request, new CancellationTokenSource().Token).Result;

            }
        }

        private void I_Should_get_StatusCode(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode,_response.StatusCode);
        }
    }


}
