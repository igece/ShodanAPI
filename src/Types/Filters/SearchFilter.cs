using Shodan.API.CustomAttributes;


namespace Shodan.API.Types.Filters
{
  public class SearchFilter : UrlParameters
  {
    public string All { get; set; }

    public string ASN { get; set; }

    [Parameter("has_screenshot")]
    public bool? HasScreenshot { get; set; }

    public ushort? Port { get; set; }
  }
}
