using System;
using System.Collections.Generic;

namespace EdgeFilesAPI.ViewModels
{
    public class MedicalClaimsDetailViewModel
    {
        public string PlanId { get; set; }

        public DateTime ServiceFromDate { get; set; }

        public DateTime ServiceToDate { get; set; }

        public string RevenueCode { get; set; }

        public string ServiceTypeCode { get; set; }

        public string ServiceCode { get; set; }

        public List<string> ServiceModifierCode { get; set; }

        public string ServiceFacilityTypeCode { get; set; }

        public string RenderingProviderIdQualifier { get; set; }

        public string RenderingProviderIdentifier { get; set; }

        public decimal AllowedAmount { get; set; }

        public decimal PolicyPaidAmount { get; set; }

        public string DerivedServiceClaimIndicator { get; set; }

        public string InsuredMemberIdentifier { get; set; }

        public string FormTypeCode { get; set; }

        public string ClaimIdentifier { get; set; }

        public string OriginalClaimIdentifier { get; set; }

        public DateTime ClaimProcessedDateTime { get; set; }

        public string BillTypeCode { get; set; }

        public string VoidReplaceCode { get; set; }

        public string DiagnosisTypeCode { get; set; }

        public List<string> DiagnosisCode { get; set; }

        public string DischargeStatusCode { get; set; }

        public DateTime StatementCoverFromDate { get; set; }

        public DateTime StatementCoverToDate { get; set; }

        public string BillingProviderIdQualifier { get; set; }

        public string BillingProviderIdentifier { get; set; }

        public DateTime IssuerClaimPaidDate { get; set; }

        public decimal AllowedTotalAmount { get; set; }

        public decimal PolicyPaidTotalAmount { get; set; }
    }
}