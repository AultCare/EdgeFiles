using System;
using System.Collections.Generic;
using EdgeFilesCore.Models;

namespace EdgeFilesAPI.ViewModels
{
    public class MedicalClaimsDetailViewModel
    {
        public string PlanId { get; set; }

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

        public string DerivedServiceClaimIndicator { get; set; }

        public List<MedicalClaimDetailServiceLineViewModel> MedicalClaimDetailServiceLines { get; set; }
    }
}