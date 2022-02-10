using System.Threading.Tasks;

using Shodan.API.Types.Responses;


namespace Shodan.API
{
  public partial class ShodanClient
  {
    public static Task<ApiInfo> ApiInfoAsync()
    {
      return MakeRequest<ApiInfo>(GetRequestBuilder("/api-info").ToString());
    }
  }
}
