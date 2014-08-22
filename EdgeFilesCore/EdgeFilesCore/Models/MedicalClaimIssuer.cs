using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedMedicalClaimIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class MedicalClaimIssuer
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("issuerIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string IssuerIdentifier { get; set; }

        [XmlElement("issuerClaimDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int IssuerClaimDetailTotalQuantity { get; set; }

        [XmlElement("issuerClaimServiceLineTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int IssuerClaimServiceLineTotalQuantity { get; set; }

        [XmlElement("issuerPlanPaidTotalAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal IssuerPlanPaidTotalAmount { get; set; }

        [XmlElement("includedMedicalClaimPlan", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<MedicalClaimPlan> IncludedMedicalClaimPlan { get; set; }
    }
}