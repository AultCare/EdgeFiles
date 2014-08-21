using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "edgeServerPharmacyClaimSubmission", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class PharmacyClaimsSubmission : Submission
    {
        [XmlElement("claimDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int ClaimDetailTotalQuantity { get; set; }

        [XmlElement("insurancePlanPaidOnFileTotalAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal InsurancePlanPaidOnFileTotalAmount { get; set; }

        [XmlElement("includedPharmacyClaimIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public PharmacyClaimIssuer IncludedPharmacyClaimIssuer { get; set; }
    }
}