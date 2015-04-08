using System;

namespace EdgeFilesAPI.ViewModels
{
    public class SupplementalDetailViewModel
    {
        public String SupplementalDiagnosisDetailRecordIdentifier { get; set; }

        public string PlanId { get; set; }

        public string InsuredMemberIdentifier { get; set; }

        public string OriginalClaimIdentifier { get; set; }

        public string DetailRecordProcessedDateTime { get; set; }

        public string AddDeleteVoidCode { get; set; }

        public string OriginalSupplementalDetailId { get; set; }

        public DateTime ServiceFromDate { get; set; }

        public DateTime ServiceToDate { get; set; }

        public string DiagnosisTypeCode { get; set; }

        public string SupplementalDiagnosisCode { get; set; }

        public string SourceCode { get; set; }
    }
}