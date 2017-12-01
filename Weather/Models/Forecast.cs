using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Weather {
    public partial class ForecastJson
    {
        [JsonProperty("current")]
        public Current Current { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

}