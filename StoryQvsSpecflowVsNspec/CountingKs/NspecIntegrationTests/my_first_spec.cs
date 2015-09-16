using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NSpec;

namespace NspecIntegrationTests
{
    public class my_first_spec : nspec
    {
        private string name;
        void before_each() { name = "Nspec"; }
        void it_works()
        {
            name.should_be("Nspec");
        }
        void describe_nesting()
        {
            before = () => name += " BDD";
            it["works here"] = () => name.should_be("Nspec BDD");
            it["and here"] = () => name.should_be("Nspec BDD");
        }
    }

}