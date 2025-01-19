using TheNevix.Utils.RequestHandler.Models.Enums;

namespace TheNevix.Utils.RequestHandler.Models
{
    /// <summary>
    /// Options to pass when building a request.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Can either be standard system deserialization of newtonsoft deserialization.
        /// </summary>
        public ResponseDeserialization? ResponseDeserialization { get; set; }

        /// <summary>
        /// Can either be standard system deserialization of newtonsoft deserialization.
        /// </summary>
        public ResponseDeserialization? RequestDeserialization { get; set; }
    }
}
