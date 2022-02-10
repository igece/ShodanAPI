using System;
using System.Threading.Tasks;

using Shodan.API.Types.Filters;
using Shodan.API.Types.Responses;


namespace Shodan.API
{
  public partial class ShodanClient
  {
    public static Task<HostInfo> GetHostInfoAsync(string ip, bool? minify = null)
    {
      if (ip == null)
        throw new ArgumentNullException(nameof(ip));

      if (ip.Length == 0)
        throw new ArgumentException(nameof(ip));

      var request = GetRequestBuilder($"/shodan/host/{ip}");

      if (minify != null)
        request.Append($"&minify={minify.ToString().ToLowerInvariant()}");

      return MakeRequest<HostInfo>(request.ToString());
    }


    public static Task<HostSearch> SearchHostsAsync(string query, SearchFilter filter = null, bool? minify = null, uint maxPages = 1)
    {
      var request = GetRequestBuilder("/shodan/host/search");

      if (!string.IsNullOrEmpty(query))
        request.Append($"&query={query}");

      if (filter != null)
        request.Append($"&{filter}");

      if (minify != null)
        request.Append($"&minify={minify.ToString().ToLowerInvariant()}");

      return MakeMultipageRequest<HostSearch, Host>(request.ToString(), maxPages);
    }
  }
}
