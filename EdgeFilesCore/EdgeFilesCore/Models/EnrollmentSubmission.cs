using System;

namespace EdgeFilesCore.Models
{
    public class EnrollmentSubmission
    {
        public string FileIdentifier { get; set; }

        public string ExecutionZoneCode { get; set; }

        public string InterfaceControlReleaseNumber { get; set; }

        public DateTime GenerationDateTime { get; set; }

        public string SubmissionTypeCode { get; set; }

        public int InsuredMemberTotalQuantity { get; set; }

        public int InsuredMemberProfileTotalQuantity { get; set; }

        public EnrollmentIssuer IncludedEnrollmentIssuer { get; set; }
    }
}