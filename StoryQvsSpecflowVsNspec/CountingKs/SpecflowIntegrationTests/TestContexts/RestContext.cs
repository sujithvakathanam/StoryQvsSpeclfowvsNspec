using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace AcceptanceTests.TestContexts
{
    public class RestContext
    {
        public RestContext()
        {
            HttpRequestMessage = new HttpRequestMessage();
            HttpRequestMessage.Headers.Clear();
        }

        public HttpRequestMessage HttpRequestMessage { get; private set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

    }
}
