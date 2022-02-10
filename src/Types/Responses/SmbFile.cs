using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class SmbFile
  {
    [JsonPropertyName("directory")]
    public bool IsDirectory { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("read-only")]
    public bool ReadOnly { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }
  }
}
