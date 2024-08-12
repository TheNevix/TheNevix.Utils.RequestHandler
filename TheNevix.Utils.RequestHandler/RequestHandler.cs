﻿using Newtonsoft.Json;
using System.Text;
using TheNevix.Utils.RequestHandler.Builders;
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

        public RequestBuilder CreateRequest(string url)
        {
            return new RequestBuilder(this, url);
        }

        internal async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request);
        }

        /// <summary>
        /// Function to make a GET request. Possible to add optional headers.
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
                        request.Headers.Add(header.Key, header.Value);
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
                throw new ApplicationException($"Error making GET request to {url}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Function to make a HEAD request. Possible to add optional headers.
        /// </summary>
        /// <param name="url">The endpoint url.</param>
        /// <param name="options">Optional header parameters.</param>
        /// <returns>A HttpResponseMessage with the result.</returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<HttpResponseMessage> HeadAsync(string url, RequestHandlerOptions options = null)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url);

                // Add headers if provided
                if (options?.Headers != null)
                {
                    foreach (var header in options.Headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                throw new ApplicationException($"Error making HEAD request to {url}: {ex.Message}", ex);
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
                throw new ApplicationException($"Error making POST request to {url}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Function to make a Patch api call. Possible to add optional headers.
        /// </summary>
        /// <param name="url">The endpoint url.</param>
        /// <param name="body">The body object of a POST request</param>
        /// <returns>A string with the result.</returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<string> PatchAsync<T>(string url, T body, RequestHandlerOptions options = null)
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

                // Make the PATCH request
                HttpResponseMessage response = await _httpClient.PatchAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                throw new ApplicationException($"Error making PATCH request to {url}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Function to make a Put api call. Possible to add optional headers.
        /// </summary>
        /// <param name="url">The endpoint url.</param>
        /// <param name="body">The body object of a POST request</param>
        /// <returns>A string with the result.</returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<string> PutAsync<T>(string url, T body, RequestHandlerOptions options = null)
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

                // Make the PUT request
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                throw new ApplicationException($"Error making PUT request to {url}: {ex.Message}", ex);
            }
        }
    }
}
