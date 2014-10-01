using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedInsuredMember", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class EnrollmentEnrollee
    {
        [JsonProperty(Required = Required.Always)]
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("insuredMemberIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsuredMemberIdentifier { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("insuredMemberBirthDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsuredMemberBirthDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("insuredMemberGenderCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsuredMemberGenderCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("includedInsuredMemberProfile", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<EnrollmentEnrolleeProfile> IncludedInsuredMemberProfile { get; set; }
    }
}