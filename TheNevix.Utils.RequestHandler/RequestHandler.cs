using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using TheNevix.Utils.RequestHandler.Options;

namespace TheNevix.Utils.RequestHandler
{

    public class RequestHandler : IRequestHandler
    {
        private readonly HttpClient _httpClient;

        public RequestHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Function to make a Get api call. Possible to add optional headers.
        /// </summary>
        /// <param name="url">The endpoint url.</param>
        /// <param name="options">Optional header parameters.</param>
        /// <returns>A string with the result.</returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<string> GetAsync(string url, RequestHandlerOptions options = null)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

                // Add headers if provided
                if (options?.Headers != null)
                {
                    foreach (var header in options.Headers)
                    {
                        content.Headers.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                throw new ApplicationException($"Error calling API: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Function to make a Post api call. Possible to add optional headers.
        /// </summary>
        /// <param name="url">The endpoint url.</param>
        /// <param name="body">The body object of a POST request</param>
        /// <returns>A string with the result.</returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<string> PostAsync<T>(string url, T body, RequestHandlerOptions options = null)
        {
            try
            {
                // Serialize the body object to JSON
                string jsonBody = JsonConvert.SerializeObject(body);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Add headers if provided
                if (options?.Headers != null)
                {
                    foreach (var header in options.Headers)
                    {
                        content.Headers.Add(header.Key, header.Value);
                    }
                }

                // Make the POST request
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                throw new ApplicationException($"Error calling API: {ex.Message}", ex);
            }
        }
    }
}
