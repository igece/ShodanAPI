using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class Screenshot
  {
    [JsonPropertyName("data")]
    public string Data { get; set; }

    [JsonPropertyName("labels")]
    public string[] Labels { get; set; }

    [JsonPropertyName("mime")]
    public string MIME { get; set; }
  }
}
