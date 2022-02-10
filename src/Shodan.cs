using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using Shodan.API.Exceptions;
using Shodan.API.Types.Filters;
using Shodan.API.Types.Responses;


namespace Shodan.API
{
  public class Shodan
  {
    public static string ApiKey { get; set; }

    public static string Url { get; set; } = "https://api.shodan.io";

    public static uint ResultsPerPage { get; set; } = 100;


    public static Task<ApiInfoJson> ApiInfoAsync()
    {
      return MakeRequest<ApiInfoJson>(GetRequestBuilder("/api-info").ToString());
    }


    public static Task<HostInfoJson> GetHostInfoAsync(string ip, bool? minify = null)
    {
      if (ip == null)
        throw new ArgumentNullException(nameof(ip));

      if (ip.Length == 0)
        throw new ArgumentException(nameof(ip));

      var request = GetRequestBuilder($"/shodan/host/{ip}");

      if (minify != null)
        request.Append($"&minify={minify.ToString().ToLowerInvariant()}");

      return MakeRequest<HostInfoJson>(request.ToString());
    }


    public static Task<HostSearchJson> SearchHostsAsync(string query, SearchFilter filter = null, bool? minify = null, uint maxPages = 1)
    {
      var request = GetRequestBuilder("/shodan/host/search");

      if (!string.IsNullOrEmpty(query))
        request.Append($"&query={query}");

      if (filter != null)
        request.Append($"&{filter}");

      if (minify != null)
        request.Append($"&minify={minify.ToString().ToLowerInvariant()}");

      return MakeMultipageRequest<HostSearchJson, HostJson>(request.ToString(), maxPages);
    }


    private static StringBuilder GetRequestBuilder(string methodPath)
    {
      if (string.IsNullOrEmpty(ApiKey))
        throw new ShodanException("Shodan API key not specified");

      return new StringBuilder($"{Url}{methodPath}?key={ApiKey}");
    }


    private static async Task<T> MakeRequest<T>(string request)
    {
      var httpClient = new HttpClient();
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
            return await response.Content.ReadFromJsonAsync<T>();

          if (response.StatusCode == HttpStatusCode.RequestTimeout && retries++ < 5)
          {
            System.Diagnostics.Debug.WriteLine($"Request timed out, retrying... ({retries}/5)");
            timeout = true;

            await Task.Delay(1000);
            continue;
          }

          var shodanError = await response.Content.ReadFromJsonAsync<Error>();

          if (shodanError != null)
            throw new ShodanException(shodanError.Message);
        } while (timeout);

        throw new HttpRequestException($"{response.StatusCode} {response.ReasonPhrase}");
      }

      finally
      {
        response?.Dispose();
      }
    }


    private static async Task<T> MakeMultipageRequest<T, V>(string request, uint maxPages) where T : IPagedResults<V>, new() where V : class, new()
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
