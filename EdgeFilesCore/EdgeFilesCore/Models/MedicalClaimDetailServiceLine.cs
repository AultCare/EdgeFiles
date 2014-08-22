using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    [XmlRoot(ElementName = "includedDetailServiceLine", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
    public class MedicalClaimDetailServiceLine
    {
        [XmlElement("includedServiceLine", Namespace = "http://vo.edge.fm.cms.hhs.gov")]
        public List<MedicalClaimServiceLine> IncludedDetailServiceLine { get; set; }
    }
}