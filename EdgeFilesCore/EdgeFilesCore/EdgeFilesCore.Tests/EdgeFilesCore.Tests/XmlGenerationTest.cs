using EdgeFilesCore.Models;
using EdgeFilesCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EdgeFilesCore.Tests
{
    [TestClass]
    public class XmlGenerationTest
    {
        [TestMethod]
        public void MedicalClaimsFileTest()
        {
            var medicalClaimSubmissionXmlGenerator =
                new MedicalClaimSubmissionXmlGenerator();

            var medicalClaimSubmission = new MedicalClaimSubmission
            {
                FileIdentifier = "123456780",
                ExecutionZoneCode = "T",
                InterfaceControlReleaseNumber = "02.00.00",
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                SubmissionTypeCode = "M",
                ClaimDetailTotalQuantity = 1,
                ClaimServiceLineTotalQuantity = 1,
                InsurancePlanPaidOnFileTotalAmount = 715.00M.ToString("N2"),
                IncludedMedicalClaimIssuer = new MedicalClaimIssuer()
            };

            var medicalClaimIssuer = new MedicalClaimIssuer
            {
                RecordIdentifier = 1,
                IssuerIdentifier = "",
                IssuerClaimDetailTotalQuantity = 1,
                IssuerClaimServiceLineTotalQuantity = 1,
                IssuerPlanPaidTotalAmount = 715.00M.ToString("N2"),
                IncludedMedicalClaimPlan = new List<MedicalClaimPlan>()
            };

            var medicalClaimPlan = new MedicalClaimPlan
            {
                RecordIdentifier = 2,
                InsurancePlanIdentifier = "34567MD004555500",
                InsurancePlanClaimDetailTotalQuantity = 1,
                InsurancePlanClaimServiceLineTotalQuantity = 1,
                InsurancePlanPaidTotalAmount = 715.00M.ToString("N2"),
                IncludedMedicalClaimDetail = new List<MedicalClaimDetail>()
            };

            var medicalClaimDetail = new MedicalClaimDetail
            {
                RecordIdentifier = 3,
                InsuredMemberIdentifier = "z42r6x99w15",
                FormTypeCode = "0",
                ClaimIdentifier = "12345720140401",
                OriginalClaimIdentifier = "",
                ClaimProcessedDateTime = new DateTime(2014, 4, 1),
                BillTypeCode = "113",
                VoidReplaceCode = "",
                DiagnosisTypeCode = "01",
                DiagnosisCode = new List<string> { "5559", "v1272", "1539" },
                DischargeStatusCode = "30",
                StatementCoverFromDate = new DateTime(2014, 03, 15).ToString("yyyy-MM-dd"),
                StatementCoverToDate = new DateTime(2014, 03, 15).ToString("yyyy-MM-dd"),
                BillingProviderIdQualifier = "99",
                BillingProviderIdentifier = "808401234567893",
                IssuerClaimPaidDate = new DateTime(2014, 4, 1).ToString("yyyy-MM-dd"),
                AllowedTotalAmount = 865.00M.ToString(CultureInfo.CurrentCulture),
                PolicyPaidTotalAmount = 715M.ToString("N2"),
                //  DerivedServiceClaimIndicator = "N"
            };

            var detailServiceLine = new MedicalClaimDetailServiceLine
            {
                IncludedDetailServiceLine = new List<MedicalClaimServiceLine>()
            };

            var medicalClaimSvcLine = new MedicalClaimServiceLine
            {
                RecordIdentifier = 4,
                ServiceLineNumber = 1,
                ServiceFromDate = new DateTime(2014, 03, 15).ToString("yyyy-MM-dd"),
                ServiceToDate = new DateTime(2014, 03, 15).ToString("yyyy-MM-dd"),
                RevenueCode = "0490",
                ServiceTypeCode = "03",
                ServiceCode = "45738",
                ServiceModifierCode = new List<string> { "" },
                ServiceFacilityTypeCode = "",
                RenderingProviderIdQualifier = "99",
                RenderingProviderIdentifier = "808401234567893",
                AllowedAmount = 865M.ToString("N2").Replace(",", ""),
                PolicyPaidAmount = 715M.ToString("N2").Replace(",", ""),
                DerivedServiceClaimIndicator = "N"
            };

            medicalClaimDetail.IncludedDetailServiceLine = detailServiceLine;
            medicalClaimDetail.IncludedDetailServiceLine.IncludedDetailServiceLine.Add(medicalClaimSvcLine);
            medicalClaimPlan.IncludedMedicalClaimDetail.Add(medicalClaimDetail);
            medicalClaimIssuer.IncludedMedicalClaimPlan.Add(medicalClaimPlan);
            medicalClaimSubmission.IncludedMedicalClaimIssuer = medicalClaimIssuer;

            medicalClaimSubmissionXmlGenerator.MedicalClaimSubmission = medicalClaimSubmission;
            medicalClaimSubmissionXmlGenerator.HiosId = "12345";
            medicalClaimSubmissionXmlGenerator.ExecutionZone = "T";

            var xmlGeneratorService = new XmlGeneratorService(medicalClaimSubmissionXmlGenerator);

            var path = AppDomain.CurrentDomain.BaseDirectory;
            xmlGeneratorService.GenerateXml(path);
        }

        [TestMethod]
        public void PharmacyClaimsFileTest()
        {
            var pharmacyClaimsSubmissionXmlGenerator =
                new PharmacyClaimSubmissionXmlGenerator();

            var pharmacyClaimsSubmission = new PharmacyClaimSubmission
            {
                FileIdentifier = "123456789120",
                ExecutionZoneCode = "T",
                InterfaceControlReleaseNumber = "02.00.00",
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                SubmissionTypeCode = "P",
                ClaimDetailTotalQuantity = 2,
                InsurancePlanPaidOnFileTotalAmount = 1000.10M
            };

            var pharmacyClaimIssuer = new PharmacyClaimIssuer
            {
                RecordIdentifier = 120,
                IssuerIdentifier = "01234",
                IssuerClaimDetailTotalQuantity = 2,
                IssuerPlanPaidTotalAmount = 1000.10M
                //,IncludedPharmacyClaimInsurancePlan = new PharmacyClaimInsurancePlan()
            };

            var pharmacyClaimInsurancePlan = new PharmacyClaimInsurancePlan
            {
                RecordIdentifier = 121,
                InsurancePlanIdentifier = "01234MD001555500",
                InsurancePlanClaimDetailTotalQuantity = 2,
                PolicyPaidTotalAmount = 1000.10M,
                IncludedPharmacyClaimDetail = new List<PharmacyClaimLevel>()
            };

            pharmacyClaimIssuer.IncludedPharmacyClaimInsurancePlans = new List<PharmacyClaimInsurancePlan>();
            pharmacyClaimIssuer.IncludedPharmacyClaimInsurancePlans.Add(pharmacyClaimInsurancePlan);

            var pharmacyClaim1 = new PharmacyClaimLevel
            {
                RecordIdentifier = 122,
                InsuredMemberIdentifier = "z42r6x99w15",
                ClaimIdentifier = "12323920140315A2",
                ClaimProcessedDateTime = new DateTime(2013, 3, 15),
                PrescriptionFillDate = new DateTime(2014, 3, 1).ToString("yyyy-MM-dd"),
                IssuerClaimPaidDate = new DateTime(2014, 3, 1).ToString("yyyy-MM-dd"),
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
                PrescriptionFillDate = new DateTime(2014, 2, 1).ToString("yyyy-MM-dd"),
                IssuerClaimPaidDate = new DateTime(2014, 2, 1).ToString("yyyy-MM-dd"),
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

            pharmacyClaimsSubmissionXmlGenerator.HiosId = "12345";
            pharmacyClaimsSubmissionXmlGenerator.ExecutionZone = "T";

            var xmlGeneratorService = new XmlGeneratorService(pharmacyClaimsSubmissionXmlGenerator);
            var path = AppDomain.CurrentDomain.BaseDirectory;
            xmlGeneratorService.GenerateXml(path);
        }

        [TestMethod]
        public void EnrollmentFileTest()
        {
            var enrollmentSubmissionXml = new EnrollmentSubmissionXmlGenerator();

            var enrollmentSubmission = new EnrollmentSubmission
            {
                FileIdentifier = "27",
                ExecutionZoneCode = "T",
                InterfaceControlReleaseNumber = "02.00.00",
                GenerationDateTime = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss"),
                SubmissionTypeCode = "E",
                InsuredMemberTotalQuantity = 2,
                InsuredMemberProfileTotalQuantity = 3
            };

            var enrollmentIssuer = new EnrollmentIssuer
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
                    CoverageStartDate = new DateTime(2014, 1, 1).ToString("yyyy-MM-dd"),
                    CoverageEndDate = new DateTime(2014, 12, 31).ToString("yyyy-MM-dd"),
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
                CoverageStartDate = new DateTime(2014, 1, 1).ToString("yyyy-MM-dd"),
                CoverageEndDate = new DateTime(2014, 03, 31).ToString("yyyy-MM-dd"),
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
                CoverageStartDate = new DateTime(2014, 4, 1).ToString("yyyy-MM-dd"),
                CoverageEndDate = new DateTime(2014, 12, 31).ToString("yyyy-MM-dd"),
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
                    InsuredMemberBirthDate = new DateTime(1950, 01, 01).ToString("yyyy-MM-dd"),
                    InsuredMemberGenderCode = "M",
                    IncludedInsuredMemberProfile = insMemberList1
                },
                new EnrollmentEnrollee{
                    RecordIdentifier = 25,
                    InsuredMemberIdentifier = "r11xtu9874j",
                    InsuredMemberBirthDate = new DateTime(1968, 01, 17).ToString("yyyy-MM-dd"),
                    InsuredMemberGenderCode = "F",
                    IncludedInsuredMemberProfile = insMemberList2
                }
            };
            enrollmentIssuer.IncludedInsuredMembers = includedInsuredMembers;
            enrollmentSubmission.IncludedEnrollmentIssuer = enrollmentIssuer;
            enrollmentSubmissionXml.EnrollmentSubmission = enrollmentSubmission;

            enrollmentSubmissionXml.HiosId = "12345";
            enrollmentSubmissionXml.ExecutionZone = "T";

            var xmlGeneratorService = new XmlGeneratorService(enrollmentSubmissionXml);

            var path = AppDomain.CurrentDomain.BaseDirectory;
            xmlGeneratorService.GenerateXml(path);
        }

        [TestMethod]
        public void SupplementalFileTest()
        {
            var supplementalClaimsSubmissionXmlGenerator = new SupplementalDiagnosisSubmissionXmlGenerator();

            var supplementalClaimsSubmission = new SupplementalDiagnosisSubmission
            {
                FileIdentifier = "123456789120",
                ExecutionZoneCode = "T",
                InterfaceControlReleaseNumber = "02.00.00",
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                SubmissionTypeCode = "S",
                //FileDetailTotalQuantity = 0,
                //IncludedSupplementalDiagnosIssuer = new SupplementalDiagnosisIssuer()
            };

            var issuer = new SupplementalDiagnosisIssuer
            {
                IssuerIdentifier = "44064",
                IncludedSupplementalDiagnosisPlan = new List<SupplementalDiagnosisPlan>()
            };

            var plan = new SupplementalDiagnosisPlan
            {
                InsurancePlanIdentifier = "44064MD001234400",
                IncludedSupplementalDiagnosisDetail = new List<SupplementalDiagnosisDetail>()
            };

            var detail = new SupplementalDiagnosisDetail
            {
                InsuredMemberIdentifier = "Ms1234578MK",
                OriginalClaimIdentifier = "1234591",
                DetailRecordProcessedDateTime = new DateTime(2014, 6, 24).ToString("yyyy-MM-ddTHH:mm:ss"),
                AddDeleteVoidCode = "A",
                ServiceFromDate = new DateTime(2014, 2, 15).ToString("yyyy-MM-dd"),
                ServiceToDate = new DateTime(2014, 3, 15).ToString("yyyy-MM-dd"),
                DiagnosisTypeCode = "01",
                SupplementalDiagnosisCode = "V371",
                SourceCode = "MR"
            };

            plan.IncludedSupplementalDiagnosisDetail.Add(detail);
            issuer.IncludedSupplementalDiagnosisPlan.Add(plan);
            supplementalClaimsSubmission.IncludedSupplementalDiagnosisIssuer = issuer;

            supplementalClaimsSubmissionXmlGenerator.SupplementalSubmission = supplementalClaimsSubmission;
            supplementalClaimsSubmissionXmlGenerator.HiosId = issuer.IssuerIdentifier;
            supplementalClaimsSubmissionXmlGenerator.ExecutionZone = supplementalClaimsSubmission.ExecutionZoneCode;

            var xmlGeneratorService = new XmlGeneratorService(supplementalClaimsSubmissionXmlGenerator);
            var path = AppDomain.CurrentDomain.BaseDirectory;
            xmlGeneratorService.GenerateXml(path);
        }
    }
}