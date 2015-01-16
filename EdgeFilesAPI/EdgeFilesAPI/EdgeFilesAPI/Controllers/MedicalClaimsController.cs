using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using AutoMapper;
using EdgeFilesAPI.ViewModels;
using EdgeFilesCore.Models;
using EdgeFilesCore.Services;

namespace EdgeFilesAPI.Controllers
{
    public class MedicalClaimsController : ApiController
    {
        // POST api/<controller>
        public HttpResponseMessage Post(MedicalClaimsSubmissionViewModel medicalSubmission)
        {
            Mapper.CreateMap<MedicalClaimsDetailViewModel, MedicalClaimDetail>();

            var fileId = DateTime.UtcNow.ToFileTime().ToString(CultureInfo.CurrentCulture);

            var planClaimCollection = new List<MedicalClaimPlan>();
            int serviceLineCount = 0;
            int planServiceLineCount = 0;

            #region Build Medical Claim Submission Object

            foreach (var planClaims in medicalSubmission.MedicalClaims.GroupBy(x => x.PlanId.ToLower()))
            {
                var medicalClaims = Mapper.Map<List<MedicalClaimDetail>>(planClaims);
                planServiceLineCount = 0;

                #region Medical Claim Plan

                //var planServiceLineCount = 0;
                //foreach (var medicalClaimDetail in medicalClaims)
                //{
                //    planServiceLineCount = planServiceLineCount + medicalClaimDetail.IncludedDetailServiceLine.IncludedDetailServiceLine.Count();
                //}

                var medicalClaimPlan = new MedicalClaimPlan
                {
                    InsurancePlanClaimDetailTotalQuantity = medicalClaims.Count(),
                    InsurancePlanIdentifier = planClaims.First().PlanId,
                    InsurancePlanPaidTotalAmount = medicalClaims.Sum(x => Decimal.Parse(x.PolicyPaidTotalAmount)).ToString("N2").Replace(",", ""),
                    IncludedMedicalClaimDetail = new List<MedicalClaimDetail>(),
                    RecordIdentifier = 1,
                    //InsurancePlanClaimServiceLineTotalQuantity =
                };

                #endregion Medical Claim Plan

                //var serviceLineCount = new Dictionary<string, int>();

                IGrouping<string, MedicalClaimsDetailViewModel> claims = planClaims;
                foreach (var claim in medicalSubmission.MedicalClaims.Where(x => x.PlanId == claims.First().PlanId).GroupBy(x => x.ClaimIdentifier))
                {
                    #region Medical Claim Detail

                    foreach (var indClaim in claim)
                    {
                        var mcslList = new List<MedicalClaimServiceLine>();

                        indClaim.ClaimIdentifier = MaskService.PasswordHash.CreateHash(indClaim.ClaimIdentifier);
                        indClaim.InsuredMemberIdentifier = MaskService.PasswordHash.CreateHash(indClaim.InsuredMemberIdentifier);

                        #region Medical Claim Service Line

                        foreach (var claimLine in indClaim.MedicalClaimDetailServiceLines.OrderBy(x => x.ServiceLineNumber))
                        {
                            mcslList.Add(new MedicalClaimServiceLine
                            {
                                AllowedAmount = claimLine.AllowedAmount.ToString("N2").Replace(",", ""),
                                DerivedServiceClaimIndicator = claimLine.DerivedServiceClaimIndicator,
                                PolicyPaidAmount = claimLine.PolicyPaidAmount.ToString("N2").Replace(",", ""),
                                RenderingProviderIdQualifier = claimLine.RenderingProviderIdQualifier,
                                RenderingProviderIdentifier = claimLine.RenderingProviderIdentifier,
                                RevenueCode = claimLine.RevenueCode,
                                ServiceCode = claimLine.ServiceCode,
                                ServiceFacilityTypeCode = claimLine.ServiceFacilityTypeCode,
                                ServiceFromDate = claimLine.ServiceFromDate.ToString("yyyy-MM-dd"),
                                ServiceToDate = claimLine.ServiceToDate.ToString("yyyy-MM-dd"),
                                ServiceModifierCode = claimLine.ServiceModifierCode,
                                ServiceTypeCode = claimLine.ServiceTypeCode.Length == 2 ? claimLine.ServiceTypeCode : claimLine.ServiceTypeCode.PadLeft(2, '0'),
                                ServiceLineNumber = claimLine.ServiceLineNumber
                            });
                        }

                        serviceLineCount += mcslList.Count();
                        planServiceLineCount += mcslList.Count();

                        #endregion Medical Claim Service Line

                        var medicalClaimDetail = new MedicalClaimDetail
                        {
                            IncludedDetailServiceLine = new MedicalClaimDetailServiceLine { IncludedDetailServiceLine = mcslList },
                            AllowedTotalAmount = mcslList.Sum(x => Decimal.Parse(x.AllowedAmount)).ToString("N2").Replace(",", ""),
                            BillTypeCode = indClaim.BillTypeCode, // double check that all in a group are the same
                            BillingProviderIdQualifier = indClaim.BillingProviderIdQualifier,
                            BillingProviderIdentifier = indClaim.BillingProviderIdentifier,
                            ClaimIdentifier = indClaim.ClaimIdentifier,
                            ClaimProcessedDateTime = indClaim.ClaimProcessedDateTime,
                            DerivedServiceClaimIndicator = indClaim.DerivedServiceClaimIndicator,
                            DiagnosisCode = indClaim.DiagnosisCode,
                            DiagnosisTypeCode = indClaim.DiagnosisTypeCode.Length == 2 ? indClaim.DiagnosisTypeCode : indClaim.DiagnosisTypeCode.PadLeft(2, '0'),
                            DischargeStatusCode = indClaim.DischargeStatusCode,
                            FormTypeCode = indClaim.FormTypeCode,
                            VoidReplaceCode = indClaim.VoidReplaceCode,
                            InsuredMemberIdentifier = indClaim.InsuredMemberIdentifier,
                            IssuerClaimPaidDate = indClaim.IssuerClaimPaidDate.ToString("yyyy-MM-dd"),
                            OriginalClaimIdentifier = indClaim.OriginalClaimIdentifier,
                            PolicyPaidTotalAmount = mcslList.Sum(x => Decimal.Parse(x.PolicyPaidAmount)).ToString("N2").Replace(",", ""),
                            StatementCoverFromDate = indClaim.StatementCoverFromDate.ToString("yyyy-MM-dd"),
                            StatementCoverToDate = indClaim.StatementCoverToDate.ToString("yyyy-MM-dd")
                            //,DerivedServiceClaimIndicator = indClaim.DerivedServiceClaimIndicator,
                        };

                        medicalClaimPlan.IncludedMedicalClaimDetail.Add(medicalClaimDetail);
                    }

                    #endregion Medical Claim Detail
                }
                medicalClaimPlan.InsurancePlanClaimServiceLineTotalQuantity = planServiceLineCount;
                planClaimCollection.Add(medicalClaimPlan);
            }

            #region Medical Claim Issuer

            var medicalClaimIssuer = new MedicalClaimIssuer
            {
                RecordIdentifier = 1,
                IssuerIdentifier = medicalSubmission.IssuerIdentifier,
                IncludedMedicalClaimPlan = planClaimCollection,
                IssuerPlanPaidTotalAmount = planClaimCollection.Sum(x => Decimal.Parse(x.InsurancePlanPaidTotalAmount)).ToString("N2").Replace(",", ""),
                IssuerClaimDetailTotalQuantity = medicalSubmission.MedicalClaims.Count(), //todo
                IssuerClaimServiceLineTotalQuantity = serviceLineCount
            };

            #endregion Medical Claim Issuer

            #region Medical Claim Submission

            var submission = new MedicalClaimSubmission
            {
                ExecutionZoneCode = medicalSubmission.ExecutionZoneCode,
                ClaimDetailTotalQuantity = medicalSubmission.MedicalClaims.Count(),
                IncludedMedicalClaimIssuer = medicalClaimIssuer,
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                FileIdentifier = fileId.Substring(fileId.Length - 12, 12),
                InterfaceControlReleaseNumber = medicalSubmission.InterfaceControlReleaseNumber,
                SubmissionTypeCode = medicalSubmission.SubmissionTypeCode,
                InsurancePlanPaidOnFileTotalAmount = medicalClaimIssuer.IssuerPlanPaidTotalAmount,
                ClaimServiceLineTotalQuantity = medicalClaimIssuer.IssuerClaimServiceLineTotalQuantity
            };

            #endregion Medical Claim Submission

            #endregion Build Medical Claim Submission Object

            var medicalSubmissionXml = new MedicalClaimSubmissionXmlGenerator
            {
                ExecutionZone = medicalSubmission.ExecutionZoneCode,
                HiosId = medicalSubmission.IssuerIdentifier,
                MedicalClaimSubmission = submission
            };

            // Return file
            var xmlGeneratorService = new XmlGeneratorService(medicalSubmissionXml);

            var path = HttpContext.Current.Request.MapPath(@"~/Output");
            var filePath = xmlGeneratorService.GenerateXml(path);
            var filename = filePath.Replace(path, "");
            filename = filename.Replace('"', ' ');
            filename = filename.Replace('\\', ' ');

            Stream result = new FileStream(filePath, FileMode.Open);
            result.Position = 0;
            var response = new HttpResponseMessage { Content = new StreamContent(result) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = filename
            };
            return response;
        }
    }
}