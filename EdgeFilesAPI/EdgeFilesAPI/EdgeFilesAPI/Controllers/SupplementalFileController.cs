using EdgeFilesAPI.ViewModels;
using EdgeFilesCore.Models;
using EdgeFilesCore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace EdgeFilesAPI.Controllers
{
    public class SupplementalFileController : ApiController
    {
        // POST api/<controller>
        public HttpResponseMessage Post(SupplementalSubmissionViewModel submitted)
        {
            var planList = new List<SupplementalDiagnosisPlan>();

            foreach (var plan in submitted.SupplementalDiagnosisDetails.GroupBy(x => x.PlanId))
            {
                var detailList = new List<SupplementalDiagnosisDetail>();

                foreach (var detail in plan)
                {
                    detailList.Add(new SupplementalDiagnosisDetail
                    {
                        AddDeleteVoidCode = detail.AddDeleteVoidCode,
                        DetailRecordProcessedDateTime = detail.DetailRecordProcessedDateTime,
                        DiagnosisTypeCode = detail.DiagnosisTypeCode,
                        OriginalClaimIdentifier = detail.OriginalClaimIdentifier,
                        OriginalSupplementalDetailId = detail.OriginalSupplementalDetailId,
                        ServiceFromDate = detail.ServiceFromDate,
                        ServiceToDate = detail.ServiceToDate,
                        SourceCode = detail.SourceCode,
                        SupplementalDiagnosisCode = detail.SupplementalDiagnosisCode,
                        InsuredMemberIdentifier = detail.InsuredMemberIdentifier,
                    });
                }

                planList.Add(new SupplementalDiagnosisPlan
                {
                    InsurancePlanIdentifier = plan.First().PlanId,
                    IncludedSupplementalDiagnosisDetail = detailList
                });
            }

            var issuer = new SupplementalDiagnosisIssuer
            {
                IssuerIdentifier = submitted.IssuerIdentifier,
                IncludedSupplementalDiagnosisPlan = planList
            };

            var submission = new SupplementalDiagnosisSubmission
            {
                ExecutionZoneCode = submitted.ExecutionZoneCode,
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                SubmissionTypeCode = submitted.SubmissionTypeCode,
                InterfaceControlReleaseNumber = submitted.ExecutionZoneCode,
                IncludedSupplementalDiagnosIssuer = issuer
            };

            var supplementalClaimsSubmissionXmlGenerator = new SupplementalDiagnosisSubmissionXmlGenerator();

            supplementalClaimsSubmissionXmlGenerator.SupplementalSubmission = submission;
            supplementalClaimsSubmissionXmlGenerator.HiosId = issuer.IssuerIdentifier;
            supplementalClaimsSubmissionXmlGenerator.ExecutionZone = submission.ExecutionZoneCode;

            var xmlGeneratorService = new XmlGeneratorService(supplementalClaimsSubmissionXmlGenerator);
            var path = AppDomain.CurrentDomain.BaseDirectory;
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