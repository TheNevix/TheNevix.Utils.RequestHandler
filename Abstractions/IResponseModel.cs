namespace TheNevix.Utils.RequestHandler
{
    /// <summary>
    /// Base response model interface to use when doing ExecuteWithHandlingAsync()
    /// </summary>
    /// <typeparam name="T">The type of the data within the response model.</typeparam>
    public interface IResponseModel<T>
    {
        /// <summary>
        /// A boolean to indicate if any exceptions occured.
        /// </summary>
        bool IsSuccess { get; set; }

        /// <summary>
        /// A message which is null upon success. If an exception occurs, the errormessage will be stored here.
        /// </summary>
        string? Message { get; set; }

        /// <summary>
        /// Holds the statuscode of the request
        /// </summary>
        int StatusCode { get; set; }

        /// <summary>
        /// The data within the response model.
        /// </summary>
        T Data { get; set; }
    }
}
