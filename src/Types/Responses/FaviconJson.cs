using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class FaviconJson
  {
    [JsonPropertyName("data")]
    public string Data { get; set; }

    [JsonPropertyName("hash")]
    public long Hash { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }
  }
}
