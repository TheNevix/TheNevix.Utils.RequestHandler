using Microsoft.Extensions.DependencyInjection;
using TheNevix.Utils;
using TheNevix.Utils.Configurations;
using TheNevix.Utils.RequestHandler.Options;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Set up the dependency injection container
            var services = new ServiceCollection();
            services.AddRequestHandlerServices(); // Register IRequestHandler and RequestHandler

            var serviceProvider = services.BuildServiceProvider();

            // Resolve IRequestHandler from the DI container
            var requestHandler = serviceProvider.GetRequiredService<IRequestHandler>();

            var someHeaders = new Dictionary<string, string>
            {
                { "Authorization", "Bearer ey..." }
            };

            var someRequestOptions = new RequestHandlerOptions(someHeaders);

            // Use the request handler to make an API call
            string response = await requestHandler.GetAsync("https://www.freetogame.com/api/games", someRequestOptions);

            // Output the response
            Console.WriteLine(response);
        }
    }
}
