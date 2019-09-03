using System.Runtime.Serialization;

using Shodan.API.JsonTypes;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class HostInfoJson
  {
    [DataMember(Name = "data")]
    public HostJson[] Data { get; set; }
  }
}
