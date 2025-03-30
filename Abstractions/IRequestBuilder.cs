using TheNevix.Utils.RequestHandler.Models;

namespace TheNevix.Utils.RequestHandler
{
    /// <summary>
    /// Interface for building and executing HTTP requests with optional error handling.
    /// </summary>
    public interface IRequestBuilder
    {
        /// <summary>
        /// Adds a header to the HTTP request.
        /// </summary>
        /// <param name="name">The name of the header</param>
        /// <param name="value">The value of the header</param>
        /// <returns>The current instance of <see cref="IRequestBuilder"/> for method chaining.</returns>
        IRequestBuilder AddHeader(string name, string value);

        /// <summary>
        /// Adds a query parameter to the request URI.
        /// </summary>
        /// <param name="name">The name of the query parameter</param>
        /// <param name="value">The value of the query parameter</param>
        /// <param name="checkIfNull">Optional boolean to check if the value is null, if it is null, it won't add it to the request URI. Default is true</param>
        /// <returns>The current instance of <see cref="IRequestBuilder"/> for method chaining.</returns>
        IRequestBuilder AddQueryParameter(string name, string value, bool checkIfNull = true);

        /// <summary>
        /// Adds a request body to the HTTP request as StringContent.
        /// </summary>
        /// <typeparam name="TModel">The type of the request body model.</typeparam>
        /// <param name="model">The model to be serialized and added as the request body.</param>
        /// <returns>The current instance of <see cref="IRequestBuilder"/> for method chaining.</returns>
        IRequestBuilder WithRequestBody<TModel>(TModel model);

        /// <summary>
        /// Sets RequestOptions with provided options
        /// </summary>
        /// <param name="requestOptions">THe options for the request</param>
        /// <returns>The current instance of <see cref="IRequestBuilder"/> for method chaining.</returns>
        IRequestBuilder WithOptions(RequestOptions requestOptions);

        /// <summary>
        /// Executes the HTTP request and deserializes the response into the specified type.
        /// </summary>
        /// <typeparam name="TResponse">The type to which the response should be deserialized.</typeparam>
        /// <returns>A task representing the asynchronous operation, with the deserialized response as the result.</returns>
        Task<TResponse> ExecuteAsync<TResponse>();

        /// <summary>
        /// Executes the HTTP request with built-in error handling, deserializing the response into the specified type.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response model implementing <see cref="IResponseModel{TData}"/>.</typeparam>
        /// <typeparam name="TData">The type of the data within the response model.</typeparam>
        /// <returns>A task representing the asynchronous operation, with the deserialized and error-handled response as the result.</returns>
        Task<TResponse> ExecuteWithHandlingAsync<TResponse, TData>() where TResponse : IResponseModel<TData>, new();

        /// <summary>
        /// Executes the HTTP request and returns the raw <see cref="HttpResponseMessage"/> without deserialization.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the raw HTTP response as the result.</returns>
        Task<HttpResponseMessage> ExecuteAsync();
    }
}
