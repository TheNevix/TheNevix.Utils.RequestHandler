using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace TheNevix.Utils.RequestHandler
{
    public class RequestBuilder : IRequestBuilder
    {
        private readonly RequestHandler _requestHandler;
        private readonly HttpRequestMessage _requestMessage;

        public RequestBuilder(RequestHandler requestHandler, string url)
        {
            _requestHandler = requestHandler;
            _requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        }

        /// <summary>
        /// Adds a header to the HTTP request.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>The current instance of <see cref="IRequestBuilder"/> for method chaining.</returns>
        public IRequestBuilder AddHeader(string name, string value)
        {
            _requestMessage.Headers.Add(name, value);
            return this;
        }


        /// <summary>
        /// Adds a request body to the HTTP request.
        /// </summary>
        /// <typeparam name="TModel">The type of the request body model.</typeparam>
        /// <param name="model">The model to be serialized and added as the request body.</param>
        /// <returns>The current instance of <see cref="IRequestBuilder"/> for method chaining.</returns>
        public IRequestBuilder WithRequestBody<TModel>(TModel model)
        {
            _requestMessage.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            return this;
        }


        /// <summary>
        /// Sets the HTTP method (GET, POST, etc.) for the request.
        /// </summary>
        /// <param name="method">The HTTP method to use.</param>
        /// <returns>The current instance of <see cref="IRequestBuilder"/> for method chaining.</returns>
        public IRequestBuilder WithMethod(HttpMethod method)
        {
            _requestMessage.Method = method;
            return this;
        }

        /// <summary>
        /// Executes the HTTP request and deserializes the response into the specified type.
        /// </summary>
        /// <typeparam name="TResponse">The type to which the response should be deserialized.</typeparam>
        /// <returns>A task representing the asynchronous operation, with the deserialized response as the result.</returns>
        public async Task<TResponse> ExecuteAsync<TResponse>()
        {
            var response = await _requestHandler.SendAsync(_requestMessage);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
        }

        /// <summary>
        /// Executes the HTTP request with built-in error handling, deserializing the response into the specified type.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response model implementing <see cref="IResponseModel{TData}"/>.</typeparam>
        /// <typeparam name="TData">The type of the data within the response model.</typeparam>
        /// <returns>A task representing the asynchronous operation, with the deserialized and error-handled response as the result.</returns>
        public async Task<TResponse> ExecuteWithHandlingAsync<TResponse, TData>()
             where TResponse : IResponseModel<TData>, new()
        {
            try
            {
                var response = await _requestHandler.SendAsync(_requestMessage);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new TResponse
                    {
                        IsSuccess = false,
                        Message = "Unauthorized access. Please check your credentials.",
                        StatusCode = (int)HttpStatusCode.Unauthorized
                    };
                }

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var resultData = JsonConvert.DeserializeObject<TData>(jsonResponse);

                return new TResponse
                {
                    IsSuccess = true,
                    StatusCode = (int)response.StatusCode,
                    Data = resultData
                };
            }
            catch (Exception ex)
            {
                return new TResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Executes the HTTP request and returns the raw <see cref="HttpResponseMessage"/> without deserialization.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the raw HTTP response as the result.</returns>
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await _requestHandler.SendAsync(_requestMessage);
        }
    }
}
