using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedMedicalClaimPlan", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class MedicalClaimPlan
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("insurancePlanIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsurancePlanIdentifier { get; set; }

        [XmlElement("insurancePlanClaimDetailTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsurancePlanClaimDetailTotalQuantity { get; set; }

        [XmlElement("insurancePlanClaimServiceLineTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsurancePlanClaimServiceLineTotalQuantity { get; set; }

        [XmlElement("insurancePlanPaidTotalAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public String InsurancePlanPaidTotalAmount { get; set; }

        [XmlElement("includedMedicalClaimDetail", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<MedicalClaimDetail> IncludedMedicalClaimDetail { get; set; }
    }
}