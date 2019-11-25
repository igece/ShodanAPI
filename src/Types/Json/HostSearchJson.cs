using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class HostSearchJson
  {
    [DataMember(Name = "matches")]
    public HostJson[] Matches { get; set; }

    [DataMember(Name = "total")]
    public uint Total { get; set; }
  }
}
