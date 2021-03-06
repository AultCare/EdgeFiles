﻿using System.Xml.Serialization;
using Newtonsoft.Json;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "edgeServerEnrollmentSubmission", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class EnrollmentSubmission : Submission
    {
        [JsonProperty(Required = Required.Always)]
        [XmlElement("insuredMemberTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsuredMemberTotalQuantity { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("insuredMemberProfileTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsuredMemberProfileTotalQuantity { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("includedEnrollmentIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public EnrollmentIssuer IncludedEnrollmentIssuer { get; set; }
    }
}