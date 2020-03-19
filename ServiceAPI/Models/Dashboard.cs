using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiceAPI.Models
{
    public class Dashboard
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("update_date_time")] public DateTime UpdatedDateTime { get; set; }
        [JsonProperty("local_new_cases")] public int LocalNewCases { get; set; }
        [JsonProperty("local_total_cases")] public int LocalTotalCases { get; set; }
        [JsonProperty("local_deaths")] public int LocalDeaths { get; set; }
        [JsonProperty("local_new_deaths")] public int LocalNewDeaths { get; set; }
        [JsonProperty("local_recovered")] public int LocalRecovered { get; set; }
        [JsonProperty("global_new_cases")] public int GlobalNewCases { get; set; }
        [JsonProperty("global_total_cases")] public int GlobalTotalCases { get; set; }
        [JsonProperty("global_deaths")] public int GlobalDeaths { get; set; }
        [JsonProperty("global_new_deaths")] public int GlobalNewDeaths { get; set; }
        [JsonProperty("global_recovered")] public int GlobalRecovered { get; set; }
        [JsonProperty("hospital_data")] public List<HospitalData> HospitalData { get; set; }

    }
}
