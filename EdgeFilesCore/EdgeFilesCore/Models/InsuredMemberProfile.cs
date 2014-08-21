using System;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedInsuredMemberProfile", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class InsuredMemberProfile
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("subscriberIndicator", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string SubscriberIndicator { get; set; }

        [XmlElement("subscriberIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string SubscriberIdentifier { get; set; }

        [XmlElement("insurancePlanIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsurancePlanIdentifier { get; set; }

        [XmlElement("coverageStartDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime CoverageStartDate { get; set; }

        [XmlElement("coverageEndDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public DateTime CoverageEndDate { get; set; }

        [XmlElement("enrollmentMaintenanceTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string EnrollmentMaintenanceTypeCode { get; set; }

        [XmlElement("rateAreaIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string RateAreaIdentifier { get; set; }

        [XmlElement("insurancePlanPremiumAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal InsurancePlanPremiumAmount { get; set; }
    }
}