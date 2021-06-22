using Newtonsoft.Json;

namespace AirportApi.Services.Dto
{
    public class AirportInfoResponse
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_iata")]
        public string IataCountryCode { get; set; }

        [JsonProperty("city_iata")]
        public string IataCityCode { get; set; }

        [JsonProperty("iata")]
        public string IataCode { get; set; }

        [JsonProperty("timezone_region_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("location")]
        public LocationInfo Location { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("hubs")]
        public int HubsQuantity { get; set; }
    }

    public class LocationInfo
    {
        [JsonProperty("lon")]
        public double? Longitude { get; set; }

        [JsonProperty("lat")]
        public double? Latitude { get; set; }
    }
}
