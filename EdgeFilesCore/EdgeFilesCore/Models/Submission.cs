using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace EdgeFilesCore.Models
{
    public class Submission
    {
        [XmlElement("fileIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        [JsonProperty(Required = Required.Always)]
        public String FileIdentifier { get; set; }

        [XmlElement("executionZoneCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        [JsonProperty(Required = Required.Always)]
        public String ExecutionZoneCode { get; set; }

        [XmlElement("interfaceControlReleaseNumber", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        [JsonProperty(Required = Required.Always)]
        public String InterfaceControlReleaseNumber { get; set; }

        [XmlElement("generationDateTime", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        [JsonProperty(Required = Required.Always)]
        public String GenerationDateTime { get; set; }

        [XmlElement("submissionTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        [JsonProperty(Required = Required.Always)]
        public String SubmissionTypeCode { get; set; }
    }
}