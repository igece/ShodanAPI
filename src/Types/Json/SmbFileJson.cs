using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class SmbFileJson
  {
    [DataMember(Name = "directory")]
    public bool IsDirectory { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "read-only")]
    public bool ReadOnly { get; set; }

    [DataMember(Name = "size")]
    public long Size { get; set; }
  }
}
