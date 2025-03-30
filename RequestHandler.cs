namespace TheNevix.Utils.RequestHandler
{
    internal class RequestHandler : IRequestHandler
    {
        private readonly HttpClient _httpClient;

        public RequestHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IRequestBuilder GetRequest(string url)
        {
            return new RequestBuilder(this, HttpMethod.Get, url);
        }

        public IRequestBuilder PostRequest(string url)
        {
            return new RequestBuilder(this, HttpMethod.Post, url);
        }

        public IRequestBuilder PutRequest(string url)
        {
            return new RequestBuilder(this, HttpMethod.Put, url);
        }

        public IRequestBuilder PatchRequest(string url)
        {
            return new RequestBuilder(this, HttpMethod.Patch, url);
        }

        public IRequestBuilder DeleteRequest(string url)
        {
            return new RequestBuilder(this, HttpMethod.Delete, url);
        }

        internal async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request);
        }
    }
}
