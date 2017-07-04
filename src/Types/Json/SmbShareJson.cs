using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class SmbShareJson
  {
    [DataMember(Name = "temporary")]
    public bool Temporary { get; set; }

    [DataMember(Name = "type")]
    public string Type { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "special")]
    public bool Special { get; set; }

    [DataMember(Name = "comments")]
    public string Comments { get; set; }

    [DataMember(Name = "files")]
    public SmbFileJson[] Files { get; set; }
  }
}
