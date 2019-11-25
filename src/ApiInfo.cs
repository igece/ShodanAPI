using Shodan.API.Types.Json;


namespace Shodan.API
{
  public class ApiInfo : ShodanMethod<ApiInfoJson>
  {
    public ApiInfo()
    : base("api-info")
    {
    }
  }
}
