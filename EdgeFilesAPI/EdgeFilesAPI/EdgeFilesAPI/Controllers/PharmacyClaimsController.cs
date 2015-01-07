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
    public class PharmacyClaimsController : ApiController
    {
        // POST api/<controller>
        public HttpResponseMessage Post(PharmacySubmissionViewModel pharmacySubmission)
        {
            // todo -- move this
            Mapper.CreateMap<PharmacyClaimLevelViewModel, PharmacyClaimLevel>();

            var fileId = DateTime.UtcNow.ToFileTime().ToString(CultureInfo.CurrentCulture);

            var planClaimCollection = new List<PharmacyClaimInsurancePlan>();

            foreach (var claim in pharmacySubmission.PharmacyClaims)
            {
                claim.PrescriptionFillDate = DateTime.Parse(claim.PrescriptionFillDate).ToString("yyyy-MM-dd");
                claim.IssuerClaimPaidDate = DateTime.Parse(claim.IssuerClaimPaidDate).ToString("yyyy-MM-dd");
                claim.InsuredMemberIdentifier = MaskService.PasswordHash.CreateHash(claim.InsuredMemberIdentifier);
                claim.ClaimIdentifier = MaskService.PasswordHash.CreateHash(claim.ClaimIdentifier);
            }

            //pharmacySubmission.PharmacyClaims
            //    .ForEach(x => x.PrescriptionFillDate = DateTime.Parse(x.PrescriptionFillDate).ToString("yyyy-MM-dd"));
            //pharmacySubmission.PharmacyClaims.ForEach(x => x.IssuerClaimPaidDate = DateTime.Parse(x.IssuerClaimPaidDate).ToString("yyyy-MM-dd"));

            foreach (var claims in pharmacySubmission.PharmacyClaims.GroupBy(x => x.PlanId.ToLower()))
            {
                var pharmclaims = Mapper.Map<List<PharmacyClaimLevel>>(claims);
                //pharmClaims.Add(pharmclaim);

                var planClaims = new PharmacyClaimInsurancePlan
                {
                    IncludedPharmacyClaimDetail = pharmclaims,
                    InsurancePlanClaimDetailTotalQuantity = pharmclaims.Count(),
                    InsurancePlanIdentifier = claims.First().PlanId,
                    PolicyPaidTotalAmount = pharmclaims.Sum(x => x.PolicyPaidAmount),
                    RecordIdentifier = 0
                };

                planClaimCollection.Add(planClaims);
            }

            var issuer = new PharmacyClaimIssuer
            {
                IssuerIdentifier = pharmacySubmission.IssuerIdentifier,
                IncludedPharmacyClaimInsurancePlans = planClaimCollection,
                IssuerClaimDetailTotalQuantity = planClaimCollection.Sum(x => x.InsurancePlanClaimDetailTotalQuantity),
                IssuerPlanPaidTotalAmount = pharmacySubmission.PharmacyClaims.Sum(x => x.PolicyPaidAmount)
            };
            //foreach (var insurancePlan in issuer.IncludedPharmacyClaimInsurancePlans)
            //{
            //}

            var submission = new PharmacyClaimSubmission
            {
                ExecutionZoneCode = pharmacySubmission.ExecutionZoneCode,
                ClaimDetailTotalQuantity = pharmacySubmission.PharmacyClaims.Count(),
                IncludedPharmacyClaimIssuer = issuer,
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                FileIdentifier = fileId.Substring(fileId.Length - 12, 12),
                InsurancePlanPaidOnFileTotalAmount = pharmacySubmission.PharmacyClaims.Sum(x => x.PolicyPaidAmount),
                InterfaceControlReleaseNumber = pharmacySubmission.InterfaceControlReleaseNumber,
                SubmissionTypeCode = pharmacySubmission.SubmissionTypeCode
            };

            var pharmacySubmissionXml = new PharmacyClaimSubmissionXmlGenerator
            {
                PharmacyClaimsSubmission = submission,
                ExecutionZone = pharmacySubmission.ExecutionZoneCode,
                HiosId = pharmacySubmission.IssuerIdentifier
            };

            var xmlGeneratorService = new XmlGeneratorService(pharmacySubmissionXml);

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