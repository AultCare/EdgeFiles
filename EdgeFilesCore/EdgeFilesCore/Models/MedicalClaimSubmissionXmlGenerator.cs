using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    public class MedicalClaimSubmissionXmlGenerator : IXmlGenerator
    {
        public MedicalClaimSubmission MedicalClaimSubmission { get; set; }

        public string HiosId { get; set; }

        public char ExecutionZone { get; set; }

        public string GenerateXml(string filePath)
        {
            DateTime genDate = DateTime.Now.ToUniversalTime();
            string xmlFileName = string.Concat(HiosId, ".M.D", genDate.Date.ToString("MMddyyyy"),
                "T", genDate.TimeOfDay.Hours.ToString(),
                genDate.TimeOfDay.Minutes.ToString(), genDate.TimeOfDay.Seconds.ToString(),
                ".", ExecutionZone.ToString(), ".xml");
            string fullFilename = Path.Combine(filePath, xmlFileName);
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

            using (XmlWriter xmlWriter = XmlWriter.Create(fullFilename, xmlSettings))
            {
                xmlWriter.WriteStartDocument();

                var xmlSerializer = new XmlSerializer(typeof(MedicalClaimSubmission));
                xmlSerializer.Serialize(xmlWriter, MedicalClaimSubmission, ns);

                xmlWriter.WriteEndDocument();
            }

            return fullFilename;
        }
    }
}