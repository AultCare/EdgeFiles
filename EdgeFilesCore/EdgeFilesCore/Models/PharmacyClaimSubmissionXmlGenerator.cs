﻿using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EdgeFilesCore.Models
{
    public class PharmacyClaimSubmissionXmlGenerator : IXmlGenerator
    {
        public PharmacyClaimSubmission PharmacyClaimsSubmission { get; set; }

        public string HiosId { get; set; }

        public String ExecutionZone { get; set; }

        public string GenerateXml(string filePath)
        {
            DateTime genDate = DateTime.Now.ToUniversalTime();
            string xmlFileName = string.Concat(HiosId, ".P.D", genDate.Date.ToString("MMddyyyy"),
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

            // Set record IDs

            int recordId = 1;
            PharmacyClaimsSubmission.IncludedPharmacyClaimIssuer.RecordIdentifier = recordId++;

            foreach (var includedInsuredMember in PharmacyClaimsSubmission.IncludedPharmacyClaimIssuer.IncludedPharmacyClaimInsurancePlans)
            {
                includedInsuredMember.RecordIdentifier = recordId++;
                var insMem = includedInsuredMember;
                insMem.IncludedPharmacyClaimDetail.ForEach(x => x.RecordIdentifier = recordId++);
            }


            using (XmlWriter xmlWriter = XmlWriter.Create(fullFilename, xmlSettings))
            {
                xmlWriter.WriteStartDocument();

                var xmlSerializer = new XmlSerializer(typeof(PharmacyClaimSubmission));
                xmlSerializer.Serialize(xmlWriter, PharmacyClaimsSubmission, ns);

                xmlWriter.WriteEndDocument();
            }

            return fullFilename;
        }
    }
}