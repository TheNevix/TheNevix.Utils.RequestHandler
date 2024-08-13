using Microsoft.Extensions.DependencyInjection;

namespace TheNevix.Utils.RequestHandler.Configurations
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adding this to your program will enable the usage of the IRequestHandler interface to create api calls.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRequestHandlerServices(this IServiceCollection services)
        {
            services.AddHttpClient<IRequestHandler, RequestHandler>();
            services.AddHttpClient<IRequestBuilder, RequestBuilder>();
            return services;
        }
    }
}
