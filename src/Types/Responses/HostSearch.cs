using System.Text.Json.Serialization;

using Shodan.API.Interfaces;


namespace Shodan.API.Types.Responses
{
  public class HostSearch : IPagedResults<Host>
  {
    [JsonPropertyName("matches")]
    public Host[] Matches { get; set; }

    [JsonPropertyName("total")]
    public uint Total { get; set; }
  }
}
