namespace TheNevix.Utils.RequestHandler.Options
{
    public class RequestHandlerOptions
    {
        public Dictionary<string, string> Headers { get; set; }

        public RequestHandlerOptions(Dictionary<string, string> headers)
        {
            Headers = headers;
        }
    }
}
