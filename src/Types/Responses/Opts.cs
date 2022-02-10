using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class Opts
  {
    [JsonPropertyName("screenshot")]
    public Screenshot Screenshot { get; set; }
  }
}
