using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Weather {
    public partial class SearchModel
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}