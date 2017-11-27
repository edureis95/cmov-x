using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Weather {
    public partial class PastDay
    {
        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }

        [JsonProperty("location")]
        public PastLocation PastLocation { get; set; }
    }

    public partial class PastLocation
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("localtime")]
        public string Localtime { get; set; }

        [JsonProperty("localtime_epoch")]
        public long LocaltimeEpoch { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("tz_id")]
        public string TzId { get; set; }
    }

    public partial class Forecast
    {
        [JsonProperty("forecastday")]
        public Forecastday[] Forecastday { get; set; }
    }

    public partial class Forecastday
    {
        [JsonProperty("astro")]
        public Astro Astro { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("date_epoch")]
        public long DateEpoch { get; set; }

        [JsonProperty("day")]
        public Day Day { get; set; }

        [JsonProperty("hour")]
        public Hour[] Hour { get; set; }
    }

    public partial class Hour
    {
        [JsonProperty("chance_of_rain")]
        public string ChanceOfRain { get; set; }

        [JsonProperty("chance_of_snow")]
        public string ChanceOfSnow { get; set; }

        [JsonProperty("cloud")]
        public long Cloud { get; set; }

        [JsonProperty("condition")]
        public PastCondition Condition { get; set; }

        [JsonProperty("dewpoint_c")]
        public double DewpointC { get; set; }

        [JsonProperty("dewpoint_f")]
        public double DewpointF { get; set; }

        [JsonProperty("feelslike_c")]
        public double FeelslikeC { get; set; }

        [JsonProperty("feelslike_f")]
        public double FeelslikeF { get; set; }

        [JsonProperty("heatindex_c")]
        public double HeatindexC { get; set; }

        [JsonProperty("heatindex_f")]
        public double HeatindexF { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("is_day")]
        public long IsDay { get; set; }

        [JsonProperty("precip_in")]
        public long PrecipIn { get; set; }

        [JsonProperty("precip_mm")]
        public long PrecipMm { get; set; }

        [JsonProperty("pressure_in")]
        public double PressureIn { get; set; }

        [JsonProperty("pressure_mb")]
        public long PressureMb { get; set; }

        [JsonProperty("temp_c")]
        public double TempC { get; set; }

        [JsonProperty("temp_f")]
        public double TempF { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("time_epoch")]
        public long TimeEpoch { get; set; }

        [JsonProperty("vis_km")]
        public long VisKm { get; set; }

        [JsonProperty("vis_miles")]
        public long VisMiles { get; set; }

        [JsonProperty("will_it_rain")]
        public long WillItRain { get; set; }

        [JsonProperty("will_it_snow")]
        public long WillItSnow { get; set; }

        [JsonProperty("wind_degree")]
        public long WindDegree { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }

        [JsonProperty("wind_kph")]
        public double WindKph { get; set; }

        [JsonProperty("wind_mph")]
        public double WindMph { get; set; }

        [JsonProperty("windchill_c")]
        public double WindchillC { get; set; }

        [JsonProperty("windchill_f")]
        public double WindchillF { get; set; }
    }

    public partial class Day
    {
        [JsonProperty("avghumidity")]
        public long Avghumidity { get; set; }

        [JsonProperty("avgtemp_c")]
        public double AvgtempC { get; set; }

        [JsonProperty("avgtemp_f")]
        public double AvgtempF { get; set; }

        [JsonProperty("avgvis_km")]
        public long AvgvisKm { get; set; }

        [JsonProperty("avgvis_miles")]
        public long AvgvisMiles { get; set; }

        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        [JsonProperty("maxtemp_c")]
        public long MaxtempC { get; set; }

        [JsonProperty("maxtemp_f")]
        public double MaxtempF { get; set; }

        [JsonProperty("maxwind_kph")]
        public double MaxwindKph { get; set; }

        [JsonProperty("maxwind_mph")]
        public double MaxwindMph { get; set; }

        [JsonProperty("mintemp_c")]
        public double MintempC { get; set; }

        [JsonProperty("mintemp_f")]
        public double MintempF { get; set; }

        [JsonProperty("totalprecip_in")]
        public long TotalprecipIn { get; set; }

        [JsonProperty("totalprecip_mm")]
        public long TotalprecipMm { get; set; }

        [JsonProperty("uv")]
        public long Uv { get; set; }
    }

    public partial class PastCondition
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Astro
    {
        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }

        [JsonProperty("moonset")]
        public string Moonset { get; set; }

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }
    

}