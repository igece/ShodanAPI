using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class HttpJson
  {
    [JsonPropertyName("favicon")]
    public FaviconJson Favicon { get; set; }

    [JsonPropertyName("html")]
    public string HTML { get; set; }

    [JsonPropertyName("html_hash")]
    public long? HTMLHash { get; set; }

    [JsonPropertyName("server")]
    public string Server { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
  }
}
