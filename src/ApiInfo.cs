using Shodan.API.JsonTypes;


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
