using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedSupplementalDiagnosisPlan", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class SupplementalDiagnosisPlan
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("insurancePlanIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsurancePlanIdentifier { get; set; }

        [XmlElement("insurancePlanFileDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsurancePlanFileDetailTotalQuantity { get; set; }

        [XmlElement("IncludedSupplementalDiagnosisDetail", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<SupplementalDiagnosisDetail> IncludedSupplementalDiagnosisDetail { get; set; }
    }
}