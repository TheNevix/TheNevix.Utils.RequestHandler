using TheNevix.Utils.RequestHandler.Models.Enums;

namespace TheNevix.Utils.RequestHandler.Models
{
    /// <summary>
    /// Deserialization options to pass when building a request.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Can either be standard system deserialization of newtonsoft deserialization.
        /// </summary>
        public ResponseDeserialization? ResponseDeserialization { get; set; }
    }
}
