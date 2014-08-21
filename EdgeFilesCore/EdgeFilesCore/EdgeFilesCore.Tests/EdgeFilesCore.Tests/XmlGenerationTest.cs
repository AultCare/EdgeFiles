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
                RecordIdentifier = 22,
                IssuerIdentifier = "34567",
                IssuerInsuredMemberTotalQuantity = 2,
                IssuerInsuredMemberProfileTotalQuantity = 3
            };

            var insMemberProfile = new InsuredMemberProfile
                {
                    RecordIdentifier = 24,
                    SubscriberIndicator = "S",
                    SubscriberIdentifier = "",
                    InsurancePlanIdentifier = "34567MD001555500",
                    CoverageStartDate = new DateTime(2014, 1, 1),
                    CoverageEndDate = new DateTime(2014, 12, 31),
                    EnrollmentMaintenanceTypeCode = "021028",
                    InsurancePlanPremiumAmount = 1000.00M,
                    RateAreaIdentifier = "212"
                };

            var insMemberList1 = new List<InsuredMemberProfile> { insMemberProfile };

            var insMemberProfile2 = new InsuredMemberProfile
            {
                RecordIdentifier = 26,
                SubscriberIndicator = "S",
                SubscriberIdentifier = "",
                InsurancePlanIdentifier = "34567VA001555500",
                CoverageStartDate = new DateTime(2014, 1, 1),
                CoverageEndDate = new DateTime(2014, 03, 31),
                EnrollmentMaintenanceTypeCode = "021028",
                InsurancePlanPremiumAmount = 945M,
                RateAreaIdentifier = "212"
            };

            var insMemberProfile3 = new InsuredMemberProfile
            {
                RecordIdentifier = 27,
                SubscriberIndicator = "",
                SubscriberIdentifier = "z42r6x99w15",
                InsurancePlanIdentifier = "34567MD001555500",
                CoverageStartDate = new DateTime(2014, 4, 1),
                CoverageEndDate = new DateTime(2014, 12, 31),
                EnrollmentMaintenanceTypeCode = "021028",
                InsurancePlanPremiumAmount = 0,
                RateAreaIdentifier = "212"
            };

            var insMemberList2 = new List<InsuredMemberProfile> { insMemberProfile2, insMemberProfile3 };

            var includedInsuredMembers = new List<InsuredMember>
            {
                new InsuredMember
                {
                    RecordIdentifier = 23,
                    InsuredMemberIdentifier = "z42r6x99w15",
                    InsuredMemberBirthDate = new DateTime(1950, 01, 01),
                    InsuredMemberGenderCode = "M",
                    IncludedInsuredMemberProfile = insMemberList1
                },
                new InsuredMember{
                    RecordIdentifier = 25,
                    InsuredMemberIdentifier = "r11xtu9874j",
                    InsuredMemberBirthDate = new DateTime(1968, 01, 17),
                    InsuredMemberGenderCode = "F",
                    IncludedInsuredMemberProfile = insMemberList2
                }
            };
            enrollmentIssuer.IncludedInsuredMembers = includedInsuredMembers;
            enrollmentSubmissionXml.IncludedEnrollmentIssuer = enrollmentIssuer;

            XmlGeneratorService xmlGeneratorService = new XmlGeneratorService(enrollmentSubmissionXml);

            string path = AppDomain.CurrentDomain.BaseDirectory;
            xmlGeneratorService.GenerateXml(path);
        }
    }
}