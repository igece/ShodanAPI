using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class SmbShare
  {
    [JsonPropertyName("temporary")]
    public bool Temporary { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("special")]
    public bool Special { get; set; }

    [JsonPropertyName("comments")]
    public string Comments { get; set; }

    [JsonPropertyName("files")]
    public SmbFile[] Files { get; set; }
  }
}
