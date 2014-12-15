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

            foreach (var claims in medicalSubmission.MedicalClaims.GroupBy(x => x.PlanId.ToLower()))
            {
                var medicalClaims = Mapper.Map<List<MedicalClaimDetail>>(claims);

                var planClaims = new MedicalClaimPlan
                {
                    IncludedMedicalClaimDetail = medicalClaims,
                    InsurancePlanClaimDetailTotalQuantity = medicalClaims.Count(),
                    InsurancePlanIdentifier = claims.First().PlanId,
                    InsurancePlanPaidTotalAmount = medicalClaims.Sum(x => x.PolicyPaidTotalAmount),
                    //InsurancePlanClaimServiceLineTotalQuantity =
                    RecordIdentifier = 0
                };

                planClaimCollection.Add(planClaims);
            }

            var medicalClaimIssuer = new MedicalClaimIssuer
            {
                RecordIdentifier = 0,
                IssuerIdentifier = medicalSubmission.IssuerIdentifier,
                IncludedMedicalClaimPlan = planClaimCollection,
                IssuerPlanPaidTotalAmount = planClaimCollection.Sum(x => x.InsurancePlanPaidTotalAmount),
                IssuerClaimDetailTotalQuantity = planClaimCollection.Count(), //todo
                IssuerClaimServiceLineTotalQuantity = planClaimCollection.Count() //todo
            };

            var submission = new MedicalClaimSubmission
            {
                ExecutionZoneCode = medicalSubmission.ExecutionZoneCode,
                ClaimDetailTotalQuantity = medicalSubmission.MedicalClaims.Count(),
                IncludedMedicalClaimIssuer = medicalClaimIssuer,
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                FileIdentifier = fileId.Substring(fileId.Length - 12, 12),
                InsurancePlanPaidOnFileTotalAmount = medicalSubmission.MedicalClaims.Sum(x => x.PolicyPaidAmount),
                InterfaceControlReleaseNumber = medicalSubmission.InterfaceControlReleaseNumber,
                SubmissionTypeCode = medicalSubmission.SubmissionTypeCode
            };

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