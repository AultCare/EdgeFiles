using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedSupplementalDiagnosisIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class SupplementalDiagnosisIssuer
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("issuerIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string IssuerIdentifier { get; set; }

        [XmlElement("issuerFileDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int IssuerFileDetailTotalQuantity { get; set; }

        [XmlElement("includedSupplementalDiagnosisPlan", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<SupplementalDiagnosisPlan> IncludedSupplementalDiagnosisPlan { get; set; }
    }
}