using System.Threading.Tasks;

using Shodan.API.Types.Responses;


namespace Shodan.API
{
  public partial class ShodanClient
  {
    public static Task<ApiInfoJson> ApiInfoAsync()
    {
      return MakeRequest<ApiInfoJson>(GetRequestBuilder("/api-info").ToString());
    }
  }
}
