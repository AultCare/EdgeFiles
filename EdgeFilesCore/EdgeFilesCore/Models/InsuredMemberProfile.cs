using System;

namespace EdgeFilesCore.Models
{
    public class InsuredMemberProfile
    {
        public int RecordIdentifier { get; set; }

        public string SubscriberIndicator { get; set; }

        public string SubscriberIdentifier { get; set; }

        public string InsurancePlanIdentifier { get; set; }

        public DateTime CoverageStartDate { get; set; }

        public DateTime CoverageEndDate { get; set; }

        public string EnrollmentMaintenanceTypeCode { get; set; }

        public string RateAreaIdentifier { get; set; }
    }
}