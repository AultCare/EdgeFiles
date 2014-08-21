using System;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedPharmacyClaimDetail", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class PharmacyClaimLevel
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("insuredMemberIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsuredMemberIdentifier { get; set; }

        [XmlElement("claimIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string ClaimIdentifier { get; set; }

        [XmlElement("claimProcessedDateTime", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime ClaimProcessedDateTime { get; set; }

        /// <summary>
        ///     ICD specifies this as a Date field.
        /// </summary>
        [XmlElement("prescriptionFillDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime PrescriptionFillDate { get; set; }

        /// <summary>
        ///     ICD specifies this as a Date field.
        /// </summary>
        [XmlElement("issuerClaimPaidDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime IssuerClaimPaidDate { get; set; }

        [XmlElement("prescriptionServiceReferenceNumber", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string PrescriptionServiceReferenceNumber { get; set; }

        [XmlElement("nationalDrugCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string NationalDrugCode { get; set; }

        [XmlElement("dispensingProviderIDQualifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DispensingProviderIdQualifier { get; set; }

        [XmlElement("dispensingProviderIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DispensingProviderIdentifier { get; set; }

        [XmlElement("prescriptionFillNumber", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int PrescriptionFillNumber { get; set; }

        [XmlElement("dispensingStatusCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DispensingStatusCode { get; set; }

        [XmlElement("voidReplaceCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string VoidReplaceCode { get; set; }

        [XmlElement("allowedTotalCostAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal AllowedTotalCostAmount { get; set; }

        [XmlElement("policyPaidAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal PolicyPaidAmount { get; set; }

        [XmlElement("derivedServiceClaimIndicator", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DerivedServiceClaimIndicator { get; set; }
    }
}