using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeFilesAPI.ViewModels
{
    public class SupplementalDetailViewModel
    {
        public string PlanId { get; set; }

        public string InsuredMemberIdentifier { get; set; }

        public string OriginalClaimIdentifier { get; set; }

        public string DetailRecordProcessedDateTime { get; set; }

        public string AddDeleteVoidCode { get; set; }

        public string OriginalSupplementalDetailId { get; set; }

        public string ServiceFromDate { get; set; }

        public string ServiceToDate { get; set; }

        public string DiagnosisTypeCode { get; set; }

        public string SupplementalDiagnosisCode { get; set; }

        public string SourceCode { get; set; }
    }
}