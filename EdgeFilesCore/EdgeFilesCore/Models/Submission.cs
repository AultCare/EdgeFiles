using System;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    public class Submission
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
    }
}