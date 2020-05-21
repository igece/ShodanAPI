using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class ScreenshotJson
  {
    [DataMember(Name = "data")]
    public string Data { get; set; }

    [DataMember(Name = "labels")]
    public string[] Labels { get; set; }

    [DataMember(Name = "mime")]
    public string MIME { get; set; }
  }
}
