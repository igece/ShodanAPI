using System;
using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class HostJson
  {
    [DataMember(Name = "os")]
    public string OS { get; set; }

    [DataMember(Name = "server")]
    public string Server { get; set; }

    [DataMember(Name = "timestamp")]
    public DateTime? TimeStamp { get; set; }

    [DataMember(Name = "isp")]
    public string ISP { get; set; }

    [DataMember(Name = "asn")]
    public string ASN { get; set; }

    [DataMember(Name = "hostnames")]
    public string[] Hostnames { get; set; }

    [DataMember(Name = "location")]
    public LocationJson Location { get; set; }

    [DataMember(Name = "ip")]
    public uint IP { get; set; }
    
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

    [DataMember(Name = "product")]
    public string Product { get; set; }

    [DataMember(Name = "version")]
    public string Version { get; set; }

    [DataMember(Name = "hash")]
    public long Hash { get; set; }

    [DataMember(Name = "transport")]
    public string Transport { get; set; }

    [DataMember(Name = "devicetype")]
    public string DeviceType { get; set; }

    [DataMember(Name = "http")]
    public HttpJson HTTP { get; set; }

    [DataMember(Name = "smb")]
    public SmbJson SMB { get; set; }
  }
}
