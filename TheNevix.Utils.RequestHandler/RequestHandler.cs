using TheNevix.Utils.RequestHandler.Options;

namespace TheNevix.Utils.RequestHandler
{

    public class RequestHandler
    {
        private readonly HttpClient _httpClient;

        public RequestHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Function to make a Get api call. Possible to add optional headers
        /// </summary>
        /// <param name="url">The endpoint url.</param>
        /// <param name="options">Optional header parameter.</param>
        /// <returns>A string with the result.</returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<string> GetAsync(string url, RequestHandlerOptions options = null)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
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
