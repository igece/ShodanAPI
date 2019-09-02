using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class FaviconJson
  {
    [DataMember(Name = "data")]
    public string Data { get; set; }

    [DataMember(Name = "hash")]
    public int Hash { get; set; }

    [DataMember(Name = "location")]
    public string Location { get; set; }
  }
}
