using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedMedicalClaimPlan", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class MedicalClaimDetail
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("insuredMemberIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsuredMemberIdentifier { get; set; }

        [XmlElement("formTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string FormTypeCode { get; set; }

        [XmlElement("claimIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string ClaimIdentifier { get; set; }

        [XmlElement("originalClaimIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string OriginalClaimIdentifier { get; set; }

        [XmlElement("claimProcessedDateTime", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime ClaimProcessedDateTime { get; set; }

        [XmlElement("billTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string BillTypeCode { get; set; }

        [XmlElement("voidReplaceCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string VoidReplaceCode { get; set; }

        [XmlElement("diagnosisTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DiagnosisTypeCode { get; set; }

        [XmlElement("diagnosisCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<string> DiagnosisCode { get; set; }

        [XmlElement("dischargeStatusCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DischargeStatusCode { get; set; }

        [XmlElement("statementCoverFromDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime StatementCoverFromDate { get; set; }

        [XmlElement("statementCoverToDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime StatementCoverToDate { get; set; }

        [XmlElement("billingProviderIDQualifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string BillingProviderIdQualifier { get; set; }

        [XmlElement("billingProviderIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string BillingProviderIdentifier { get; set; }

        [XmlElement("issuerClaimPaidDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime IssuerClaimPaidDate { get; set; }

        [XmlElement("allowedTotalAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal AllowedTotalAmount { get; set; }

        [XmlElement("policyPaidTotalAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal PolicyPaidTotalAmount { get; set; }

        [XmlElement("derivedServiceClaimIndicator", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DerivedServiceClaimIndicator { get; set; }

        [XmlElement("includedDetailServiceLine", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public MedicalClaimDetailServiceLine IncludedDetailServiceLine { get; set; }

        [XmlElement("includedServiceLine", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<MedicalClaimServiceLine> IncludedServiceLine { get; set; }
    }
}