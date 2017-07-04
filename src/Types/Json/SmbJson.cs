using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class SmbJson
  {
    [DataMember(Name = "smb_version")]
    public int Version { get; set; }

    [DataMember(Name = "anonymous")]
    public bool Anonymous { get; set; }

    [DataMember(Name = "os")]
    public string OS { get; set; }

    [DataMember(Name = "software")]
    public string Software { get; set; }

    [DataMember(Name = "shares")]
    public SmbShareJson[] Shares { get; set; }
  }

}
