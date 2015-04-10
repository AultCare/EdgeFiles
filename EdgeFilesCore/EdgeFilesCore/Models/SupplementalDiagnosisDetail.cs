using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedSupplementalDiagnosisDetail", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class SupplementalDiagnosisDetail
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("insuredMemberIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsuredMemberIdentifier { get; set; }

        [XmlElement("supplementalDiagnosisDetailRecordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string SupplementalDiagnosisDetailRecordIdentifier { get; set; }

        [XmlElement("originalClaimIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string OriginalClaimIdentifier { get; set; }

        [XmlElement("detailRecordProcessedDateTime", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DetailRecordProcessedDateTime { get; set; }

        [XmlElement("addDeleteVoidCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string AddDeleteVoidCode { get; set; }

        [XmlElement("originalSupplementalDetailID", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string OriginalSupplementalDetailId { get; set; }

        [XmlElement("serviceFromDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string ServiceFromDate { get; set; }

        [XmlElement("serviceToDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string ServiceToDate { get; set; }

        [XmlElement("diagnosisTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DiagnosisTypeCode { get; set; }

        [XmlElement("supplementalDiagnosisCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string SupplementalDiagnosisCode { get; set; }

        [XmlElement("sourceCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string SourceCode { get; set; }
    }
}