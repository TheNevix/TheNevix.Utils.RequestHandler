using TheNevix.Utils.RequestHandler.Builders;
using TheNevix.Utils.RequestHandler.Options;

namespace TheNevix.Utils
{
    public interface IRequestHandler
    {

        public RequestBuilder CreateRequest(string url);

        /// <summary>
        /// Sends an asynchronous GET request to the specified URL.
        /// Allows optional headers to be included in the request.
        /// </summary>
        /// <param name="url">The endpoint URL to which the GET request is sent.</param>
        /// <param name="options">Optional parameters for adding headers to the request. If no headers are specified, default headers will be used.</param>
        /// <returns>A task that represents the asynchronous GET operation. The task result contains the response as a string.</returns>
        /// <exception cref="ApplicationException">Thrown when an error occurs while making the GET request.</exception>
        Task<string> GetAsync(string url, RequestHandlerOptions options = null);

        /// <summary>
        /// Sends an asynchronous HEAD request to the specified URL.
        /// Allows optional headers to be included in the request.
        /// </summary>
        /// <param name="url">The endpoint URL to which the HEAD request is sent.</param>
        /// <param name="options">Optional parameters for adding headers to the request. If no headers are specified, default headers will be used.</param>
        /// <returns>A task that represents the asynchronous HEAD operation. The task result contains the response as a string.</returns>
        /// <exception cref="ApplicationException">Thrown when an error occurs while making the HEAD request.</exception>
        Task<HttpResponseMessage> HeadAsync(string url, RequestHandlerOptions options = null);

        /// <summary>
        /// Sends an asynchronous POST request to the specified URL with the provided body.
        /// Allows optional headers to be included in the request.
        /// </summary>
        /// <typeparam name="T">The type of the body object to be serialized and sent in the POST request.</typeparam>
        /// <param name="url">The endpoint URL to which the POST request is sent.</param>
        /// <param name="body">The body object to be serialized into JSON and sent in the POST request.</param>
        /// <param name="options">Optional parameters for adding headers to the request. If no headers are specified, default headers will be used.</param>
        /// <returns>A task that represents the asynchronous POST operation. The task result contains the response as a string.</returns>
        /// <exception cref="ApplicationException">Thrown when an error occurs while making the POST request.</exception>
        Task<string> PostAsync<T>(string url, T body, RequestHandlerOptions options = null);

        /// <summary>
        /// Sends an asynchronous PATCH request to the specified URL with the provided body.
        /// Allows optional headers to be included in the request.
        /// </summary>
        /// <typeparam name="T">The type of the body object to be serialized and sent in the PATCH request.</typeparam>
        /// <param name="url">The endpoint URL to which the PATCH request is sent.</param>
        /// <param name="body">The body object to be serialized into JSON and sent in the PATCH request.</param>
        /// <param name="options">Optional parameters for adding headers to the request. If no headers are specified, default headers will be used.</param>
        /// <returns>A task that represents the asynchronous PATCH operation. The task result contains the response as a string.</returns>
        /// <exception cref="ApplicationException">Thrown when an error occurs while making the PATCH request.</exception>
        Task<string> PatchAsync<T>(string url, T body, RequestHandlerOptions options = null);

        /// <summary>
        /// Sends an asynchronous PUT request to the specified URL with the provided body.
        /// Allows optional headers to be included in the request.
        /// </summary>
        /// <typeparam name="T">The type of the body object to be serialized and sent in the PUT request.</typeparam>
        /// <param name="url">The endpoint URL to which the PUT request is sent.</param>
        /// <param name="body">The body object to be serialized into JSON and sent in the PUT request.</param>
        /// <param name="options">Optional parameters for adding headers to the request. If no headers are specified, default headers will be used.</param>
        /// <returns>A task that represents the asynchronous PUT operation. The task result contains the response as a string.</returns>
        /// <exception cref="ApplicationException">Thrown when an error occurs while making the PUT request.</exception>
        Task<string> PutAsync<T>(string url, T body, RequestHandlerOptions options = null);
    }
}
