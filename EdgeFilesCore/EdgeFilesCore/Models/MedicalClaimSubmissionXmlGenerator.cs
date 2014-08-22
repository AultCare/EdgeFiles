using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    public class MedicalClaimSubmissionXmlGenerator : IXmlGenerator
    {
        public MedicalClaimSubmission MedicalClaimSubmission { get; set; }

        public string GenerateXml(string filePath)
        {
            string filename = Path.Combine(filePath, "MedicalClaims_TestFile.xml");
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

                var xmlSerializer = new XmlSerializer(typeof(MedicalClaimSubmission));
                xmlSerializer.Serialize(xmlWriter, MedicalClaimSubmission, ns);

                xmlWriter.WriteEndDocument();
            }

            return filename;
        }
    }
}