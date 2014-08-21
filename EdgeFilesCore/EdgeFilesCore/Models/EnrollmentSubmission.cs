using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "edgeServerEnrollmentSubmission", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class EnrollmentSubmission : Submission
    {
        [XmlElement("insuredMemberTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsuredMemberTotalQuantity { get; set; }

        [XmlElement("insuredMemberProfileTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsuredMemberProfileTotalQuantity { get; set; }

        [XmlElement("includedEnrollmentIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public EnrollmentIssuer IncludedEnrollmentIssuer { get; set; }
    }
}