using System.Runtime.Serialization;


namespace Shodan.API.JsonTypes
{
  [DataContract]
  public class ApiInfoJson
  {
    [DataMember(Name = "query_credits")]
    public ushort QueryCredits { get; set; }

    [DataMember(Name = "scan_credits")]
    public ushort ScanCredits { get; set; }

    [DataMember(Name = "telnet")]
    public bool Telnet { get; set; }

    [DataMember(Name = "plan")]
    public string Plan { get; set; }

    [DataMember(Name = "https")]
    public bool HTTPS { get; set; }

    [DataMember(Name = "unlocked")]
    public bool Unlocked { get; set; }
  }
}
