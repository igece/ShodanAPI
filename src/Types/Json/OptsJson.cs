using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class OptsJson
  {
    [DataMember(Name = "screenshot")]
    public ScreenshotJson Screenshot { get; set; }
  }
}
