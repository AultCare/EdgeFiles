using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedServiceLine", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class MedicalClaimServiceLine
    {
        [XmlElement("recordIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int RecordIdentifier { get; set; }

        [XmlElement("serviceLineNumber", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int ServiceLineNumber { get; set; }

        [XmlElement("serviceFromDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public String ServiceFromDate { get; set; }

        [XmlElement("serviceToDate", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public String ServiceToDate { get; set; }

        [XmlElement("revenueCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string RevenueCode { get; set; }

        [XmlElement("serviceTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string ServiceTypeCode { get; set; }

        [XmlElement("serviceCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string ServiceCode { get; set; }

        [XmlElement("serviceModifierCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<string> ServiceModifierCode { get; set; }

        [XmlElement("serviceFacilityTypeCode", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string ServiceFacilityTypeCode { get; set; }

        [XmlElement("renderingProviderIDQualifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string RenderingProviderIdQualifier { get; set; }

        [XmlElement("renderingProviderIdentifier", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string RenderingProviderIdentifier { get; set; }

        [XmlElement("allowedAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public String AllowedAmount { get; set; }

        [XmlElement("policyPaidAmount", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public String PolicyPaidAmount { get; set; }

        [XmlElement("derivedServiceClaimIndicator", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public string DerivedServiceClaimIndicator { get; set; }
    }
}