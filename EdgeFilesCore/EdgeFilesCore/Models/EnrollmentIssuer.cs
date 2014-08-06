using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedEnrollmentIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class EnrollmentIssuer
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("issuerIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string IssuerIdentifier { get; set; }

        [XmlElement("issuerInsuredMemberTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int IssuerInsuredMemberTotalQuantity { get; set; }

        [XmlElement("issuerInsuredMemberProfileTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int IssuerInsuredMemberProfileTotalQuantity { get; set; }

        [XmlElement("includedInsuredMember", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<InsuredMember> IncludedInsuredMembers { get; set; }
    }
}