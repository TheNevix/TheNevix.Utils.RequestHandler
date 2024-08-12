using TheNevix.Utils.RequestHandler.Builders;

namespace TheNevix.Utils
{
    public interface IRequestHandler
    {
        public RequestBuilder CreateRequest(string url);
    }
}
