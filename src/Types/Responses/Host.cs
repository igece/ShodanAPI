using System;
using System.Text.Json.Serialization;


namespace Shodan.API.Types.Responses
{
    public class Host
    {
        [JsonPropertyName("os")]
        public string OS { get; set; }

        [JsonPropertyName("server")]
        public string Server { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime? TimeStamp { get; set; }

        [JsonPropertyName("isp")]
        public string ISP { get; set; }

        [JsonPropertyName("asn")]
        public string ASN { get; set; }

        [JsonPropertyName("hostnames")]
        public string[] Hostnames { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("ip")]
        public uint IP { get; set; }

        [JsonPropertyName("domains")]
        public string[] Domains { get; set; }

        [JsonPropertyName("org")]
        public string Organization { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("screenshot")]
        public Screenshot Screenshot { get; set; }

        [JsonPropertyName("port")]
        public int Port { get; set; }

        [JsonPropertyName("ip_str")]
        public string IPString { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("hash")]
        public long Hash { get; set; }

        [JsonPropertyName("transport")]
        public string Transport { get; set; }

        [JsonPropertyName("devicetype")]
        public string DeviceType { get; set; }

        [JsonPropertyName("http")]
        public Http HTTP { get; set; }

        [JsonPropertyName("smb")]
        public Smb SMB { get; set; }
    }
}
