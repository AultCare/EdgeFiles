using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedInsuredMemberProfile", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class EnrollmentEnrolleeProfile
    {
        [JsonProperty(Required = Required.Always)]
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        [XmlElement("subscriberIndicator", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string SubscriberIndicator { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        [XmlElement("subscriberIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string SubscriberIdentifier { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("insurancePlanIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string InsurancePlanIdentifier { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("coverageStartDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string CoverageStartDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("coverageEndDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string CoverageEndDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("enrollmentMaintenanceTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string EnrollmentMaintenanceTypeCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("insurancePlanPremiumAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public decimal InsurancePlanPremiumAmount { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("rateAreaIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string RateAreaIdentifier { get; set; }
    }
}