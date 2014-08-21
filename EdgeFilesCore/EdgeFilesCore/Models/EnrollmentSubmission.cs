using System;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "edgeServerEnrollmentSubmission", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class EnrollmentSubmission
    {
        [XmlElement("fileIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string FileIdentifier { get; set; }

        [XmlElement("executionZoneCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string ExecutionZoneCode { get; set; }

        [XmlElement("interfaceControlReleaseNumber", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InterfaceControlReleaseNumber { get; set; }

        [XmlElement("generationDateTime", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime GenerationDateTime { get; set; }

        [XmlElement("submissionTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string SubmissionTypeCode { get; set; }

        [XmlElement("insuredMemberTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsuredMemberTotalQuantity { get; set; }

        [XmlElement("insuredMemberProfileTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsuredMemberProfileTotalQuantity { get; set; }

        [XmlElement("includedEnrollmentIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public EnrollmentIssuer IncludedEnrollmentIssuer { get; set; }
    }
}