using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class OptsJson
  {
    [JsonPropertyName("screenshot")]
    public ScreenshotJson Screenshot { get; set; }
  }
}
