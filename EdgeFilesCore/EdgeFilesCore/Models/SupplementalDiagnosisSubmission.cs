using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "edgeServerSupplementalClaimSubmission", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class SupplementalDiagnosisSubmission : Submission
    {
        [XmlElement("fileDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int FileDetailTotalQuantity { get; set; }

        [XmlElement("includedSupplementalDiagnosisIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public SupplementalDiagnosisIssuer IncludedSupplementalDiagnosisIssuer { get; set; }
    }
}