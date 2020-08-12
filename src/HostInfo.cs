using System.Threading.Tasks;

using Shodan.API.Exceptions;
using Shodan.API.Types.Json;


namespace Shodan.API
{
  public class HostInfo : ShodanMethod<HostInfoJson>
  {
    public string IP { get; set; }

    public bool? Minify { get; set; }

    
    public HostInfo()
    : base("shodan/host/")
    {
      IP = string.Empty;
      Minify = null;
    }


    public override HostInfoJson Execute()
    {
      if (string.IsNullOrEmpty(IP))
        throw new ShodanException("No IP specified.");

      MethodUrl = $"shodan/host/{IP}";
      RequestParams.Clear();

      if (Minify.HasValue)
        RequestParams.Add("minify", Minify.Value.ToString().ToLowerInvariant());

      return base.Execute();
    }


    public override async Task<HostInfoJson> ExecuteAsync()
    {
      if (string.IsNullOrEmpty(IP))
        throw new ShodanException("No IP specified.");

      MethodUrl = $"shodan/host/{IP}";
      RequestParams.Clear();

      if (Minify.HasValue)
        RequestParams.Add("minify", Minify.Value.ToString().ToLowerInvariant());

      return await base.ExecuteAsync();
    }
  }
}
