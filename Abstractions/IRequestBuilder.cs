using TheNevix.Utils.RequestHandler.Models;

namespace TheNevix.Utils.RequestHandler
{
    /// <summary>
    /// Interface for building and executing HTTP requests with optional error handling.
    /// </summary>
    public interface IRequestBuilder
    {
        IRequestBuilder AddHeader(string name, string value);
        IRequestBuilder WithRequestBody<TModel>(TModel model);
        IRequestBuilder WithMethod(HttpMethod method);
        IRequestBuilder WithOptions(RequestOptions requestOptions);
        Task<TResponse> ExecuteAsync<TResponse>();
        Task<TResponse> ExecuteWithHandlingAsync<TResponse, TData>() where TResponse : IResponseModel<TData>, new();
        Task<HttpResponseMessage> ExecuteAsync();
    }
}
