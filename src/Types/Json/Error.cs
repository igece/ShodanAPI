using System.Runtime.Serialization;


namespace Shodan.API.JsonTypes
{
  [DataContract]
  public class Error
  {
    [DataMember(Name = "error")]
    public string Message { get; set; }
  }
}
