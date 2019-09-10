using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class HttpJson
  {
    [DataMember(Name = "favicon")]
    public FaviconJson Favicon { get; set; }

    [DataMember(Name = "html")]
    public string HTML { get; set; }

    [DataMember(Name = "html_hash")]
    public long? HTMLHash { get; set; }

    [DataMember(Name = "server")]
    public string Server { get; set; }

    [DataMember(Name = "title")]
    public string Title { get; set; }
  }
}
