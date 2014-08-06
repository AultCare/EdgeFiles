using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    public class EnrollmentSubmissionXmlGenerator : IXmlGenerator
    {
        public EnrollmentIssuer IncludedEnrollmentIssuer { get; set; }

        public List<InsuredMember> IncludedInsuredMembers { get; set; }

        public List<InsuredMemberProfile> IncludedMemberProfiles { get; set; }

        #region IXmlGenerator Members

        public string GenerateXml(string filePath)
        {
            string filename = Path.Combine(filePath, "TestFile.xml");
            var xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                ConformanceLevel = ConformanceLevel.Auto,
                Encoding = new UTF8Encoding(false),
                OmitXmlDeclaration = true
            };

            //Create namespace for the output
            string nsUrl = "http://vo.edge.fm.cms.hhs.gov";
            string prefix = "ns1";
            var ns = new XmlSerializerNamespaces();
            ns.Add(prefix, nsUrl);

            using (XmlWriter xmlWriter = XmlWriter.Create(filename, xmlSettings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(prefix, "edgeServerEnrollmentSubmission", nsUrl);
                xmlWriter.WriteElementString(prefix, "fileIdentifier", nsUrl, "27");
                xmlWriter.WriteElementString(prefix, "executionZoneCode", nsUrl, "T");
                xmlWriter.WriteElementString(prefix, "interfaceControlReleaseNumber", nsUrl, "02.00.00");
                xmlWriter.WriteElementString(prefix, "generationDateTime", nsUrl, "2014-02-05T00:00:00");
                xmlWriter.WriteElementString(prefix, "submissionTypeCode", nsUrl, "E");
                xmlWriter.WriteElementString(prefix, "insuredMemberTotalQuantity", nsUrl, "2");
                xmlWriter.WriteElementString(prefix, "insuredMemberProfileTotalQuantity", nsUrl, "3");

                if (IncludedEnrollmentIssuer != null)
                    GenerateIncludedEnrollmentIssuer(xmlWriter, ns);

                if (IncludedInsuredMembers != null && IncludedInsuredMembers.Any())
                    GenerateIncludedInsuredMembers(xmlWriter, ns);

                // end edgeServerEnrollmentSubmission
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
                xmlWriter.Flush();
            }

            return filename;
        }

        private void GenerateIncludedInsuredMembers(XmlWriter xmlWriter, XmlSerializerNamespaces ns)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<InsuredMember>));
            xmlSerializer.Serialize(xmlWriter, IncludedInsuredMembers, ns);

            //if (IncludedMemberProfiles != null && IncludedMemberProfiles.Any())
            //    GenerateIncludedMemberProfiles(xmlWriter, ns);
        }

        #endregion IXmlGenerator Members

        private void GenerateIncludedEnrollmentIssuer(XmlWriter xmlWriter, XmlSerializerNamespaces ns)
        {
            var xmlSerializer = new XmlSerializer(typeof(EnrollmentIssuer));
            xmlSerializer.Serialize(xmlWriter, IncludedEnrollmentIssuer, ns);
            //GenerateIncludedMemberProfiles(xmlWriter, ns);
        }

        private void GenerateIncludedMemberProfiles(XmlWriter xmlWriter, XmlSerializerNamespaces ns)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<InsuredMemberProfile>));
            xmlSerializer.Serialize(xmlWriter, IncludedMemberProfiles, ns);
        }
    }
}