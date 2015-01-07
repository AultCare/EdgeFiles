using System;
using Newtonsoft.Json;

namespace EdgeFilesAPI.ViewModels
{
    public class SubmissionViewModel
    {
        [JsonProperty(Required = Required.Always)]
        public String ExecutionZoneCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public String InterfaceControlReleaseNumber { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime GenerationDateTime { get; set; }

        [JsonProperty(Required = Required.Always)]
        public String SubmissionTypeCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public String IssuerIdentifier { get; set; }
    }
}