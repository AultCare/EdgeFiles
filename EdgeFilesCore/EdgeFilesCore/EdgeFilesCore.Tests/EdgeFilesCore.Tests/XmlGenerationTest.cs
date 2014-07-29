using System;
using System.Collections.Generic;
using EdgeFilesCore.Models;
using EdgeFilesCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EdgeFilesCore.Tests
{
    [TestClass]
    public class XmlGenerationTest
    {
        [TestMethod]
        public void EnrollmentFileTest()
        {
            EnrollmentSubmissionXmlGenerator enrollmentSubmissionXml = new EnrollmentSubmissionXmlGenerator();
            EnrollmentIssuer enrollmentIssuer = new EnrollmentIssuer
            {
                RecordIdentifier = -1,
                IssuerInsuredMemberTotalQuantity = 1,
                IssuerInsuredMemberProfileTotalQuantity = 1,
                IssuerIdentifier = "ASDF"
            };
            enrollmentSubmissionXml.IncludedEnrollmentIssuer = enrollmentIssuer;

            var insMem = new List<InsuredMemberProfile> { new InsuredMemberProfile() };
            InsuredMemberProfile mp = new InsuredMemberProfile
            {
                CoverageStartDate = DateTime.Now,
                CoverageEndDate = DateTime.Now.AddYears(1)
            };

            enrollmentSubmissionXml.IncludedMemberProfiles = insMem;

            EdgeFilesCore.Services.XmlGeneratorService xmlGeneratorService = new XmlGeneratorService(enrollmentSubmissionXml);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            xmlGeneratorService.GenerateXml(path);
        }
    }
}