using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class Error
  {
    [JsonPropertyName("error")]
    public string Message { get; set; }
  }
}
