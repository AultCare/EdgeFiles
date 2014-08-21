using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedPharmacyClaimInsurancePlan", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class PharmacyClaimInsurancePlan
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("insurancePlanIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsurancePlanIdentifier { get; set; }

        [XmlElement("insurancePlanClaimDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsurancePlanClaimDetailTotalQuantity { get; set; }

        [XmlElement("policyPaidTotalAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal PolicyPaidTotalAmount { get; set; }

        [XmlElement("includedPharmacyClaimDetail", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<PharmacyClaimLevel> IncludedPharmacyClaimDetail { get; set; }
    }
}