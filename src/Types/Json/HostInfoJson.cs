using System.Runtime.Serialization;

using Shodan.API.JsonTypes;


namespace Shodan.API.Types.Json
{
  [DataContract]
  public class HostInfoJson
  {
    [DataMember(Name = "region_code")]
    public string RegionCode { get; set; }

    [DataMember(Name = "country_code")]
    public string CountryCode { get; set; }

    [DataMember(Name = "dma_code")]
    public string DmaCode { get; set; }

    [DataMember(Name = "city")]
    public string City { get; set; }

    [DataMember(Name = "country_code3")]
    public string CountryCode3 { get; set; }

    [DataMember(Name = "country_name")]
    public string CountryName { get; set; }

    [DataMember(Name = "latitude")]
    public double Latitude { get; set; }

    [DataMember(Name = "longitude")]
    public double Longitude { get; set; }

    [DataMember(Name = "ip")]
    public uint IP { get; set; }

    [DataMember(Name = "ip_str")]
    public string IPString { get; set; }

    [DataMember(Name = "isp")]
    public string ISP { get; set; }

    [DataMember(Name = "data")]
    public HostJson[] Data { get; set; }
  }
}
