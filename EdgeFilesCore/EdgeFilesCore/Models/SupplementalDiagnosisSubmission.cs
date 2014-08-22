using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "edgeServerSupplmentalDiagnosisSubmission", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class SupplementalDiagnosisSubmission : Submission
    {
        [XmlElement("fileDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int FileDetailTotalQuantity { get; set; }

        [XmlElement("includedSupplementalDiagnosIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public SupplementalDiagnosisIssuer IncludedSupplementalDiagnosIssuer { get; set; }
    }
}