namespace TheNevix.Utils.RequestHandler
{
    public class RequestHandler : IRequestHandler
    {
        private readonly HttpClient _httpClient;

        public RequestHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public RequestBuilder CreateRequest(string url)
        {
            return new RequestBuilder(this, url);
        }

        internal async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request);
        }
    }
}
