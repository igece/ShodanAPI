using System.Runtime.Serialization;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class Error
  {
    [DataMember(Name = "error")]
    public string Message { get; set; }
  }
}
