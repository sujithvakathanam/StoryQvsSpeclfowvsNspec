namespace NunitIntegrationTests
{

    using System;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    
    public static class HttpRequestMethods
    {
        public static HttpRequestMessage CreateRequest(string uri, string methodVariable, HttpMethod method)
        {
            var request = new HttpRequestMessage {RequestUri = new Uri(uri)};
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(methodVariable));
            request.Method = method;
            return request;
        }

        public static HttpRequestMessage CreateRequest<T>(string uri, string methodVariable,HttpMethod method, T content,
                                                         MediaTypeFormatter formatter) where T : class
        {
            HttpRequestMessage request = CreateRequest(uri, methodVariable, method);
            request.Content =  new ObjectContent<T>(content,formatter);
            return request;
        }

    }
}