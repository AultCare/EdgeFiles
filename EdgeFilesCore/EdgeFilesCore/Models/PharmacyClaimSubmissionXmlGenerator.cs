using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    public class PharmacyClaimSubmissionXmlGenerator : IXmlGenerator
    {
        public PharmacyClaimSubmission PharmacyClaimsSubmission { get; set; }

        public string GenerateXml(string filePath)
        {
            string filename = Path.Combine(filePath, "PharmacyClaims_TestFile.xml");
            var xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                ConformanceLevel = ConformanceLevel.Auto,
                Encoding = new UTF8Encoding(false),
                OmitXmlDeclaration = true
            };

            //Create namespace for the output
            const string nsUrl = "http://vo.edge.fm.cms.hhs.gov";
            const string prefix = "ns1";
            var ns = new XmlSerializerNamespaces();
            ns.Add(prefix, nsUrl);

            using (XmlWriter xmlWriter = XmlWriter.Create(filename, xmlSettings))
            {
                xmlWriter.WriteStartDocument();

                var xmlSerializer = new XmlSerializer(typeof (PharmacyClaimSubmission));
                xmlSerializer.Serialize(xmlWriter, PharmacyClaimsSubmission, ns);

                xmlWriter.WriteEndDocument();
            }

            return filename;
        }
    }
}