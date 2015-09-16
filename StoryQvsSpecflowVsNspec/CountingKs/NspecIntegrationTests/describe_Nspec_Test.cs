using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NSpec;

namespace NspecIntegrationTests
{
    public class describe_Nspec_Test : nspec
    {
        void before_each()
        {
            Console.WriteLine("I run before each test");
        }

        void it_works_here()
        {
            "hello".should_be("hello");

        }
        void a_category_of_examples()
        {
            before = () => Console.WriteLine("I run before each test defined in this context");
            it["also works here"] = () => "hello".should_be("hello");
            it["works here too"] = () => "hello".should_be("hello");
        }
    }
}