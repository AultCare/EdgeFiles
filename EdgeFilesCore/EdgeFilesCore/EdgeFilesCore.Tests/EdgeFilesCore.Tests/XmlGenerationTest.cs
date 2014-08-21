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
        public void PharmacyClaimsFileTest()
        {
            PharmacyClaimsSubmissionXmlGenerator pharmacyClaimsSubmissionXmlGenerator =
                new PharmacyClaimsSubmissionXmlGenerator();

            var pharmacyClaimsSubmission = new PharmacyClaimsSubmission
            {
                FileIdentifier = "123456789120",
                ExecutionZoneCode = "T",
                InterfaceControlReleaseNumber = "02.00.00",
                GenerationDateTime = DateTime.Now,
                SubmissionTypeCode = "P",
                ClaimDetailTotalQuantity = 2,
                InsurancePlanPaidOnFileTotalAmount = 1000.10M
            };

            var pharmacyClaimIssuer = new PharmacyClaimIssuer
            {
                RecordIdentifier = 120,
                IssuerIdentifier = "01234",
                IssuerClaimDetailTotalQuantity = 2,
                IssuerPlanPaidTotalAmount = 1000.10M,
                IncludedPharmacyClaimInsurancePlan = new PharmacyClaimInsurancePlan()
            };

            var pharmacyClaimInsurancePlan = new PharmacyClaimInsurancePlan
            {
                RecordIdentifier = 121,
                InsurancePlanIdentifier = "01234MD001555500",
                InsurancePlanClaimDetailTotalQuantity = 2,
                PolicyPaidTotalAmount = 1000.10M,
                IncludedPharmacyClaimDetail = new List<PharmacyClaimLevel>()
            };

            pharmacyClaimIssuer.IncludedPharmacyClaimInsurancePlan = pharmacyClaimInsurancePlan;

            var pharmacyClaim1 = new PharmacyClaimLevel
            {
                RecordIdentifier = 122,
                InsuredMemberIdentifier = "z42r6x99w15",
                ClaimIdentifier = "12323920140315A2",
                ClaimProcessedDateTime = new DateTime(2013, 3, 15),
                PrescriptionFillDate = new DateTime(2014, 3, 1),
                IssuerClaimPaidDate = new DateTime(2014, 3, 1),
                PrescriptionServiceReferenceNumber = "01",
                NationalDrugCode = "1659084390",
                DispensingProviderIdQualifier = "XX",
                DispensingProviderIdentifier = "808401234567893",
                PrescriptionFillNumber = 2,
                DispensingStatusCode = "C",
                VoidReplaceCode = "",
                AllowedTotalCostAmount = 10000.01M,
                PolicyPaidAmount = 500.05M,
                DerivedServiceClaimIndicator = ""
            };

            var pharmacyClaim2 = new PharmacyClaimLevel
            {
                RecordIdentifier = 123,
                InsuredMemberIdentifier = "r11xtu9874j",
                ClaimIdentifier = "12324020140215A1",
                ClaimProcessedDateTime = new DateTime(2013, 2, 15),
                PrescriptionFillDate = new DateTime(2014, 2, 1),
                IssuerClaimPaidDate = new DateTime(2014, 2, 1),
                PrescriptionServiceReferenceNumber = "01",
                NationalDrugCode = "6353923479",
                DispensingProviderIdQualifier = "XX",
                DispensingProviderIdentifier = "808401234567893",
                PrescriptionFillNumber = 2,
                DispensingStatusCode = "C",
                VoidReplaceCode = "R",
                AllowedTotalCostAmount = 10000.01M,
                PolicyPaidAmount = 500.05M,
                DerivedServiceClaimIndicator = "Y"
            };

            pharmacyClaimInsurancePlan.IncludedPharmacyClaimDetail.Add(pharmacyClaim1);
            pharmacyClaimInsurancePlan.IncludedPharmacyClaimDetail.Add(pharmacyClaim2);

            pharmacyClaimsSubmission.IncludedPharmacyClaimIssuer = pharmacyClaimIssuer;

            pharmacyClaimsSubmissionXmlGenerator.PharmacyClaimsSubmission = pharmacyClaimsSubmission;
            XmlGeneratorService xmlGeneratorService = new XmlGeneratorService(pharmacyClaimsSubmissionXmlGenerator);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            xmlGeneratorService.GenerateXml(path);
        }

        [TestMethod]
        public void EnrollmentFileTest()
        {
            EnrollmentSubmissionXmlGenerator enrollmentSubmissionXml = new EnrollmentSubmissionXmlGenerator();

            var enrollmentSubmission = new EnrollmentSubmission
            {
                FileIdentifier = "27",
                ExecutionZoneCode = "T",
                InterfaceControlReleaseNumber = "02.00.00",
                GenerationDateTime = DateTime.Now.ToUniversalTime(),
                SubmissionTypeCode = "E",
                InsuredMemberTotalQuantity = 2,
                InsuredMemberProfileTotalQuantity = 3
            };

            EnrollmentIssuer enrollmentIssuer = new EnrollmentIssuer
            {
                RecordIdentifier = 22,
                IssuerIdentifier = "34567",
                IssuerInsuredMemberTotalQuantity = 2,
                IssuerInsuredMemberProfileTotalQuantity = 3
            };

            var insMemberProfile = new EnrollmentEnrolleeProfile
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

            var insMemberList1 = new List<EnrollmentEnrolleeProfile> { insMemberProfile };

            var insMemberProfile2 = new EnrollmentEnrolleeProfile
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

            var insMemberProfile3 = new EnrollmentEnrolleeProfile
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

            var insMemberList2 = new List<EnrollmentEnrolleeProfile> { insMemberProfile2, insMemberProfile3 };

            var includedInsuredMembers = new List<EnrollmentEnrollee>
            {
                new EnrollmentEnrollee
                {
                    RecordIdentifier = 23,
                    InsuredMemberIdentifier = "z42r6x99w15",
                    InsuredMemberBirthDate = new DateTime(1950, 01, 01),
                    InsuredMemberGenderCode = "M",
                    IncludedInsuredMemberProfile = insMemberList1
                },
                new EnrollmentEnrollee{
                    RecordIdentifier = 25,
                    InsuredMemberIdentifier = "r11xtu9874j",
                    InsuredMemberBirthDate = new DateTime(1968, 01, 17),
                    InsuredMemberGenderCode = "F",
                    IncludedInsuredMemberProfile = insMemberList2
                }
            };
            enrollmentIssuer.IncludedInsuredMembers = includedInsuredMembers;
            enrollmentSubmission.IncludedEnrollmentIssuer = enrollmentIssuer;
            enrollmentSubmissionXml.EnrollmentSubmission = enrollmentSubmission;
            XmlGeneratorService xmlGeneratorService = new XmlGeneratorService(enrollmentSubmissionXml);

            string path = AppDomain.CurrentDomain.BaseDirectory;
            xmlGeneratorService.GenerateXml(path);
        }
    }
}