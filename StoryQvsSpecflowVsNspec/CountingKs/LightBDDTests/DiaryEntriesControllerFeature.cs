using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using LightBDD;
using NUnit.Framework;

namespace LightBDDTests
{
  [Description(
      @"In order to check the DiaryEntriesController
        As a user
        I want to check this controller")]
    [TestFixture]
    [Label("Story2")]
    public partial class DiaryEntriesControllerFeature 
     {
      public string DiaryEntriesUri = "";
      public string HeaderValue = "application/json";

      [Test]
      public void DiaryEntries_Controller_Get_Response()
      { 
          Runner.RunScenario(
              given => Request_has_HeaderValue("application/json"),
              when => Request_is_sent_to_Uri(DiaryEntriesUri, HeaderValue, HttpMethod.Get),
              then => I_should_get_StatusCode(HttpStatusCode.OK)
                  );
      }

  }

  public partial class DiaryEntriesControllerFeature : FeatureFixture
    {
      protected BDDRunner Runner { get; private set; }
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Runner = new BDDRunner(GetType(), CreateProgressNotifier());
        }

        private HttpResponseMessage _response;

        
      private void I_should_get_StatusCode(object ok)
      {
          throw new NotImplementedException();
      }

      private void Request_is_sent_to_Uri(string diaryEntriesUri, object headerValue, HttpMethod get)
      {
          throw new NotImplementedException();
      }

      private object Request_has_HeaderValue(string p)
      {
          throw new NotImplementedException();
      }


        
    }
}