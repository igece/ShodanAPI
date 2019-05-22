using System.Runtime.Serialization;

using Shodan.API.Types.Json;


namespace Shodan.API.JsonTypes
{
  [DataContract]
  public class HostJson
  {
    [DataMember(Name = "os")]
    public string OS { get; set; }

    [DataMember(Name = "server")]
    public string Server { get; set; }

    [DataMember(Name = "timestamp")]
    public string TimeStamp { get; set; }

    [DataMember(Name = "isp")]
    public string ISP { get; set; }

    [DataMember(Name = "asn")]
    public string ASN { get; set; }

    [DataMember(Name = "hostnames")]
    public string[] Hostnames { get; set; }

    [DataMember(Name = "location")]
    public LocationJson Location { get; set; }

    [DataMember(Name = "ip")]
    public long IP { get; set; }
    
    [DataMember(Name = "domains")]
    public string[] Domains { get; set; }

    [DataMember(Name = "org")]
    public string Organization { get; set; }

    [DataMember(Name = "data")]
    public string Data { get; set; }

    [DataMember(Name = "port")]
    public int Port { get; set; }

    [DataMember(Name = "ip_str")]
    public string IPString { get; set; }

    [DataMember(Name = "smb")]
    public SmbJson SMB { get; set; }
  }
}
