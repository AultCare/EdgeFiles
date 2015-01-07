using System;
using System.Collections.Generic;

namespace EdgeFilesAPI.ViewModels
{
    public class MedicalClaimDetailServiceLineViewModel
    {
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

        public int ServiceLineNumber { get; set; }
    }
}