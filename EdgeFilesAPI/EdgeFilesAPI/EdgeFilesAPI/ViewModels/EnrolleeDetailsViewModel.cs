using System;
using Newtonsoft.Json;

namespace EdgeFilesAPI.ViewModels
{
    public class EnrolleeDetailsViewModel
    {
        [JsonProperty(Required = Required.Always)]
        public string MemberId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime BirthDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Gender { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool SubscriberInd { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public int SubscriberMemberId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string PlanId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime CoverageStart { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public DateTime? CoverageEnd { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string MaintenanceTypeCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PremiumAmount { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string RatingArea { get; set; }
    }
}