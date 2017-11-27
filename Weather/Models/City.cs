using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Weather {
  public partial class City
    {
   [JsonProperty("current")]
   public Current Current {
    get;
    set;
   }

   [JsonProperty("location")]
   public Location Location {
    get;
    set;
   }

   public string Id
    {
        get;
        set;
    }
  }

  public partial class Location {
   [JsonProperty("country")]
   public string Country {
    get;
    set;
   }

   [JsonProperty("lat")]
   public double Lat {
    get;
    set;
   }

   [JsonProperty("localtime")]
   public string Localtime {
    get;
    set;
   }

   [JsonProperty("localtime_epoch")]
   public long LocaltimeEpoch {
    get;
    set;
   }

   [JsonProperty("lon")]
   public double Lon {
    get;
    set;
   }

   [JsonProperty("name")]
   public string Name {
    get;
    set;
   }

   [JsonProperty("region")]
   public string Region {
    get;
    set;
   }

   [JsonProperty("tz_id")]
   public string TzId {
    get;
    set;
   }
  }

  public partial class Current {
   [JsonProperty("cloud")]
   public long Cloud {
    get;
    set;
   }

   [JsonProperty("condition")]
   public Condition Condition {
    get;
    set;
   }

   [JsonProperty("feelslike_c")]
   public double FeelslikeC {
    get;
    set;
   }

   [JsonProperty("feelslike_f")]
   public double FeelslikeF {
    get;
    set;
   }

   [JsonProperty("humidity")]
   public long Humidity {
    get;
    set;
   }

   [JsonProperty("is_day")]
   public long IsDay {
    get;
    set;
   }

   [JsonProperty("last_updated")]
   public string LastUpdated {
    get;
    set;
   }

   [JsonProperty("last_updated_epoch")]
   public long LastUpdatedEpoch {
    get;
    set;
   }

   [JsonProperty("precip_in")]
   public long PrecipIn {
    get;
    set;
   }

   [JsonProperty("precip_mm")]
   public long PrecipMm {
    get;
    set;
   }

   [JsonProperty("pressure_in")]
   public double PressureIn {
    get;
    set;
   }

   [JsonProperty("pressure_mb")]
   public long PressureMb {
    get;
    set;
   }

   [JsonProperty("temp_c")]
   public long TempC {
    get;
    set;
   }

   [JsonProperty("temp_f")]
   public double TempF {
    get;
    set;
   }

   [JsonProperty("vis_km")]
   public long VisKm {
    get;
    set;
   }

   [JsonProperty("vis_miles")]
   public long VisMiles {
    get;
    set;
   }

   [JsonProperty("wind_degree")]
   public long WindDegree {
    get;
    set;
   }

   [JsonProperty("wind_dir")]
   public string WindDir {
    get;
    set;
   }

   [JsonProperty("wind_kph")]
   public double WindKph {
    get;
    set;
   }

   [JsonProperty("wind_mph")]
   public double WindMph {
    get;
    set;
   }
  }

  public partial class Condition {
   [JsonProperty("code")]
   public long Code {
    get;
    set;
   }

   [JsonProperty("icon")]
   public string Icon {
    get;
    set;
   }

   [JsonProperty("text")]
   public string Text {
    get;
    set;
   }
  }

}