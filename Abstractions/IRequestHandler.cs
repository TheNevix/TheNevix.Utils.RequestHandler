using TheNevix.Utils.RequestHandler;

namespace TheNevix.Utils
{
    public interface IRequestHandler
    {
        /// <summary>
        /// Used to start building an HTTP request.
        /// </summary>
        /// <param name="url">The endpoint url</param>
        /// <returns>An instance of <see cref="RequestBuilder"/> for method chaining.</returns>
        public RequestBuilder CreateRequest(string url);
    }
}
