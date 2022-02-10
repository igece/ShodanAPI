using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{

  public class ApiInfoJson
  {
    [JsonPropertyName("query_credits")]
    public ushort QueryCredits { get; set; }

    [JsonPropertyName("scan_credits")]
    public ushort ScanCredits { get; set; }

    [JsonPropertyName("telnet")]
    public bool Telnet { get; set; }

    [JsonPropertyName("plan")]
    public string Plan { get; set; }

    [JsonPropertyName("https")]
    public bool HTTPS { get; set; }

    [JsonPropertyName("unlocked")]
    public bool Unlocked { get; set; }
  }
}
