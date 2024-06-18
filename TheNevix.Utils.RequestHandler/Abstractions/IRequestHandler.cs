using TheNevix.Utils.RequestHandler.Options;

namespace TheNevix.Utils
{
    public interface IRequestHandler
    {
        Task<string> GetAsync(string url, RequestHandlerOptions options = null);
        Task<string> PostAsync<T>(string url, T body, RequestHandlerOptions options = null);

    }
}
