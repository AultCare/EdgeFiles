using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedEnrollmentIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class EnrollmentIssuer
    {
        [JsonProperty(Required = Required.Always)]
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("issuerIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string IssuerIdentifier { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("issuerInsuredMemberTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int IssuerInsuredMemberTotalQuantity { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("issuerInsuredMemberProfileTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int IssuerInsuredMemberProfileTotalQuantity { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("includedInsuredMember", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<EnrollmentEnrollee> IncludedInsuredMembers { get; set; }
    }
}