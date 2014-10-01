using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace EdgeFilesAPI.ViewModels
{
    public class EnrollmentSubmissionViewModel : SubmissionViewModel
    {
        [JsonProperty(Required = Required.Always)]
        [XmlElement("insuredMemberTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsuredMemberTotalQuantity { get; set; }

        [JsonProperty(Required = Required.Always)]
        [XmlElement("insuredMemberProfileTotalQuantity", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public int InsuredMemberProfileTotalQuantity { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<EnrolleeDetailsViewModel> EnrolleeDetails { get; set; }
       
        [JsonProperty(Required = Required.Always)]
        public string IssuerIdentifier { get; set; }
    }
}