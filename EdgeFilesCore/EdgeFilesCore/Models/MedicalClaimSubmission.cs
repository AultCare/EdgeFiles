using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "edgeServerMedicalClaimSubmission", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class MedicalClaimSubmission : Submission
    {
        [XmlElement("claimDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int ClaimDetailTotalQuantity { get; set; }

        [XmlElement("claimServiceLineTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int ClaimServiceLineTotalQuantity { get; set; }

        [XmlElement("insurancePlanPaidOnFileTotalAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal InsurancePlanPaidOnFileTotalAmount { get; set; }

        [XmlElement("includedMedicalClaimIssuer", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public MedicalClaimIssuer IncludedMedicalClaimIssuer { get; set; }
    }
}