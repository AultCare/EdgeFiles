﻿using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    public class EnrollmentSubmissionXmlGenerator : IXmlGenerator
    {
        public EnrollmentSubmission EnrollmentSubmission { get; set; }

        public String HiosId { get; set; }

        public String ExecutionZone { get; set; }

        public String GenerateXml(string filePath)
        {
            DateTime fileNameGenDate = DateTime.Now;
            string xmlFileName = string.Concat(HiosId, ".E.D", fileNameGenDate.Date.ToString("MMddyyyy"),
                "T",
                fileNameGenDate.ToString("HH:mm:ss").Replace(":", ""),
                ".",
                ExecutionZone.ToString(CultureInfo.CurrentCulture), ".xml");
            string fullFilename = Path.Combine(filePath, xmlFileName);
            var xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                ConformanceLevel = ConformanceLevel.Auto,
                Encoding = new UTF8Encoding(false),
                OmitXmlDeclaration = true
            };

            // Set record IDs
            int recordId = 1;

            EnrollmentSubmission.IncludedEnrollmentIssuer.RecordIdentifier = recordId++;

            foreach (var includedInsuredMember in EnrollmentSubmission.IncludedEnrollmentIssuer.IncludedInsuredMembers)
            {
                includedInsuredMember.RecordIdentifier = recordId++;
                var insMem = includedInsuredMember;
                insMem.IncludedInsuredMemberProfile.ForEach(x => x.RecordIdentifier = recordId++);
            }

            //Create namespace for the output
            const string nsUrl = "http://vo.edge.fm.cms.hhs.gov";
            const string prefix = "ns1";
            var ns = new XmlSerializerNamespaces();
            ns.Add(prefix, nsUrl);

            using (XmlWriter xmlWriter = XmlWriter.Create(fullFilename, xmlSettings))
            {
                xmlWriter.WriteStartDocument();

                var xmlSerializer = new XmlSerializer(typeof(EnrollmentSubmission));
                xmlSerializer.Serialize(xmlWriter, EnrollmentSubmission, ns);

                xmlWriter.WriteEndDocument();
            }

            return fullFilename;
        }
    }
}