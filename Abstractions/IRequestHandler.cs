using TheNevix.Utils.RequestHandler;

namespace TheNevix.Utils
{
    /// <summary>
    /// Defines a handler used to initiate the construction of HTTP requests.
    /// </summary>
    public interface IRequestHandler
    {

        /// <summary>
        /// Used to start building an HTTP Get request.
        /// </summary>
        /// <param name="url">The endpoint url</param>
        /// <returns>An instance of <see cref="IRequestBuilder"/> for method chaining.</returns>
        public IRequestBuilder GetRequest(string url);

        /// <summary>
        /// Used to start building an HTTP Post request.
        /// </summary>
        /// <param name="url">The endpoint url</param>
        /// <returns>An instance of <see cref="RequestBuilder"/> for method chaining.</returns>
        public IRequestBuilder PostRequest(string url);

        /// <summary>
        /// Used to start building an HTTP Put request.
        /// </summary>
        /// <param name="url">The endpoint url</param>
        /// <returns>An instance of <see cref="RequestBuilder"/> for method chaining.</returns>
        public IRequestBuilder PutRequest(string url);

        /// <summary>
        /// Used to start building an HTTP Patch request.
        /// </summary>
        /// <param name="url">The endpoint url</param>
        /// <returns>An instance of <see cref="RequestBuilder"/> for method chaining.</returns>
        public IRequestBuilder PatchRequest(string url);

        /// <summary>
        /// Used to start building an HTTP Delete request.
        /// </summary>
        /// <param name="url">The endpoint url</param>
        /// <returns>An instance of <see cref="RequestBuilder"/> for method chaining.</returns>
        public IRequestBuilder DeleteRequest(string url);
    }
}
