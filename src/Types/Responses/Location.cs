using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
    public class Location
  {
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("region_code")]
    public string RegionCode { get; set; }

    [JsonPropertyName("area_code")]
    public string AreaCode { get; set; }

    //[JsonPropertyName("longitude")]
    //public double Longitude { get; set; }

    [JsonPropertyName("country_code3")]
    public string CountryCode3 { get; set; }

    [JsonPropertyName("country_name")]
    public string CountryName { get; set; }

    //[JsonPropertyName("postal_code")]
    //public int PostalCode { get; set; }

    [JsonPropertyName("dma_code")]
    public string DmaCode { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    //[JsonPropertyName("latitude")]
    //public double Latitude { get; set; }
  }
}
