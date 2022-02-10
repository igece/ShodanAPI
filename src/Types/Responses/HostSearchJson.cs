using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class HostSearchJson : IPagedResults<HostJson>
  {
    [JsonPropertyName("matches")]
    public HostJson[] Matches { get; set; }

    [JsonPropertyName("total")]
    public uint Total { get; set; }
  }
}
