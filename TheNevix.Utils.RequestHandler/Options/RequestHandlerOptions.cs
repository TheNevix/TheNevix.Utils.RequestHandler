namespace TheNevix.Utils.RequestHandler.Options
{
    public class RequestHandlerOptions
    {
        /// <summary>
        /// A dictionary of headers to add to the request.
        /// The TKey is the key of the header and TValue is the value of the header.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Options to pass headers to the request.
        /// </summary>
        /// <param name="headers"></param>
        public RequestHandlerOptions(Dictionary<string, string> headers)
        {
            Headers = headers;
        }
    }
}
