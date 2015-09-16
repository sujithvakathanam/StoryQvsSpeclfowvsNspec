using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Rest
{
    [Binding]
    [Scope(Tag = "TestSupport.Rest")]
    public class BaseSteps
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [Scope(Tag = "myTag")]
        [BeforeScenario]
        public void BeforeScenario()
        {
            


        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
