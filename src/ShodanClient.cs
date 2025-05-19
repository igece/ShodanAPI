using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Arnath.StandaloneHttpClientFactory;

using Shodan.API.Exceptions;
using Shodan.API.Interfaces;
using Shodan.API.Types.Responses;


namespace Shodan.API
{
    public partial class ShodanClient
    {
        public static string ApiKey { get; set; }

        public static string Url { get; set; } = "https://api.shodan.io";

        public static uint ResultsPerPage { get; set; } = 100;


        private static readonly StandaloneHttpClientFactory _httpClientFactory = new StandaloneHttpClientFactory();

        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { DefaultBufferSize = 16 * 1024 };


        public static void Dispose()
        {
            _httpClientFactory.Dispose();
        }


        private static StringBuilder GetRequestBuilder(string methodPath)
        {
            if (string.IsNullOrEmpty(ApiKey))
                throw new ShodanException("Shodan API key not specified");

            return new StringBuilder($"{Url}{methodPath}?key={ApiKey}");
        }


        private static async Task<T> MakeRequest<T>(string request)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                HttpResponseMessage response = null;
                bool timeout;
                var retries = 0;

                try
                {
                    do
                    {
                        timeout = false;
                        response = await httpClient.GetAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            using (var stream = await response.Content.ReadAsStreamAsync())
                                return await JsonSerializer.DeserializeAsync<T>(stream, _serializerOptions);
                        }

                        if (response.StatusCode == HttpStatusCode.RequestTimeout && retries++ < 5)
                        {
                            System.Diagnostics.Debug.WriteLine($"Request timed out, retrying... ({retries}/5)");
                            timeout = true;

                            await Task.Delay(1000);
                            continue;
                        }

                        try
                        {
                            var shodanError = await response.Content.ReadFromJsonAsync<Error>();

                            if (shodanError != null)
                                throw new ShodanException(shodanError.Message);
                        }

                        catch (Exception)
                        {
                            throw new HttpRequestException($"{(int)response.StatusCode} {response.ReasonPhrase}");
                        }

                    } while (timeout);

                    throw new HttpRequestException($"{response.StatusCode} {response.ReasonPhrase}");
                }

                finally
                {
                    response?.Dispose();
                }
            }
        }


        private static async Task<T> MakeMultipageRequest<T, V>(string request, uint maxPages)
          where T : IPagedResults<V>, new()
          where V : class, new()
        {
            if (maxPages == 1)
                return await MakeRequest<T>(request);

            uint currentPage = 1;
            uint realMaxPages = maxPages;

            var allResults = new T();
            var allItems = new List<V>();

            do
            {
                try
                {
                    var pageResults = await MakeRequest<T>($"{request}&page={currentPage}");

                    if (currentPage == 1)
                    {
                        allResults.Total = pageResults.Total;
                        uint totalPages = Convert.ToUInt32(Math.Ceiling(pageResults.Total / Convert.ToDouble(ResultsPerPage)));

                        if (realMaxPages > totalPages)
                            realMaxPages = totalPages;
                    }

                    allItems.AddRange(pageResults.Matches);
                    await Task.Delay(1000);
                }

                catch (Exception)
                {
                }
            } while (currentPage++ < realMaxPages);

            allResults.Matches = allItems.ToArray();

            return allResults;
        }
    }
}
