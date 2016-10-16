using System.Runtime.Serialization;


namespace Shodan.API.JsonTypes
{
  [DataContract]
  public class LocationJson
  {
    [DataMember(Name = "city")]
    public string City { get; set; }

    [DataMember(Name = "region_code")]
    public string RegionCode { get; set; }

    [DataMember(Name = "area_code")]
    public string AreaCode { get; set; }

    //[DataMember(Name = "longitude")]
    //public double Longitude { get; set; }

    [DataMember(Name = "country_code3")]
    public string CountryCode3 { get; set; }

    [DataMember(Name = "country_name")]
    public string CountryName { get; set; }

    //[DataMember(Name = "postal_code")]
    //public int PostalCode { get; set; }

    [DataMember(Name = "dma_code")]
    public string DmaCode { get; set; }

    [DataMember(Name = "country_code")]
    public string CountryCode { get; set; }

    //[DataMember(Name = "latitude")]
    //public double Latitude { get; set; }
  }
}
