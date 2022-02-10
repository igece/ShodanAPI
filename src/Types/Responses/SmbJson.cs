using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class SmbJson
  {
    [JsonPropertyName("smb_version")]
    public int Version { get; set; }

    [JsonPropertyName("anonymous")]
    public bool Anonymous { get; set; }

    [JsonPropertyName("os")]
    public string OS { get; set; }

    [JsonPropertyName("software")]
    public string Software { get; set; }

    [JsonPropertyName("shares")]
    public SmbShareJson[] Shares { get; set; }
  }

}
