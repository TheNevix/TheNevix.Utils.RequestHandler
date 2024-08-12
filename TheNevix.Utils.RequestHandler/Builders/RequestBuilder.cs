using Newtonsoft.Json;
using System.Text;

namespace TheNevix.Utils.RequestHandler.Builders
{
    public class RequestBuilder
    {
        private readonly RequestHandler _requestHandler;
        private readonly HttpRequestMessage _requestMessage;

        public RequestBuilder(RequestHandler requestHandler, string url)
        {
            _requestHandler = requestHandler;
            _requestMessage = new HttpRequestMessage(HttpMethod.Get, url); // Default to GET; can be modified
        }

        public RequestBuilder AddHeader(string name, string value)
        {
            _requestMessage.Headers.Add(name, value);
            return this;
        }

        public RequestBuilder WithRequestBodyl<TModel>(TModel model)
        {
            _requestMessage.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            return this;
        }

        public RequestBuilder WithMethod(HttpMethod method)
        {
            _requestMessage.Method = method;
            return this;
        }

        public async Task<TResponse> ExecuteAsync<TResponse>()
        {
            var response = await _requestHandler.SendAsync(_requestMessage);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
        }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await _requestHandler.SendAsync(_requestMessage);
        }
    }
}
