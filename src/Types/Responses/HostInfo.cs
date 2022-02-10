using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
  public class HostInfo
  {
    [JsonPropertyName("region_code")]
    public string RegionCode { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("dma_code")]
    public string DmaCode { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country_code3")]
    public string CountryCode3 { get; set; }

    [JsonPropertyName("country_name")]
    public string CountryName { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("ip")]
    public uint IP { get; set; }

    [JsonPropertyName("ip_str")]
    public string IPString { get; set; }

    [JsonPropertyName("isp")]
    public string ISP { get; set; }

    [JsonPropertyName("data")]
    public Host[] Data { get; set; }
  }
}
