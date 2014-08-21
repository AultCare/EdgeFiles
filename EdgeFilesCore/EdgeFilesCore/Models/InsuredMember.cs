using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedInsuredMember", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class InsuredMember
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("insuredMemberIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsuredMemberIdentifier { get; set; }

        [XmlElement("insuredMemberBirthDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime InsuredMemberBirthDate { get; set; }

        [XmlElement("insuredMemberGenderCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsuredMemberGenderCode { get; set; }

        [XmlElement("includedInsuredMemberProfile", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<InsuredMemberProfile> IncludedInsuredMemberProfile { get; set; }
    }
}