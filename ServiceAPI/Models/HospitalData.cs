using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiceAPI.Models
{
    public class HospitalData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("hospital_id")]
        public int HospitalId { get; set; }
        [JsonProperty("cumulative_local")]
        public int CumulativeLocal { get; set; }
        [JsonProperty("cumulative_foreign")]
        public int CumulativeForeign { get; set; }
        [JsonProperty("treatment_local")]
        public int TreatmentLocal { get; set; }
        [JsonProperty("treatment_foreign")]
        public int TreatmentForeign { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("cumulative_total")]
        public int CumulativeTotal { get; set; }
        [JsonProperty("treatment_total")]
        public int TreatmentTotal { get; set; }

    }
}
