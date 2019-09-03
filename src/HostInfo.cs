using Shodan.API.Exceptions;
using Shodan.API.JsonTypes;


namespace Shodan.API
{
  public class HostInfo : ShodanMethod<HostJson>
  {
    public string IP { get; set; }

    public bool? Minify { get; set; }

    
    public HostInfo()
    : base("shodan/host/")
    {
      IP = string.Empty;
      Minify = null;
    }


    public override HostJson Execute()
    {
      if (string.IsNullOrEmpty(IP))
        throw new ShodanException("No IP specified.");

      MethodUrl = $"shodan/host/{IP}";
      RequestParams.Clear();

      if (Minify.HasValue)
        RequestParams.Add("minify", Minify.Value.ToString().ToLowerInvariant());

      return base.Execute();
    }
  }
}
