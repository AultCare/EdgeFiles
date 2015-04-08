using EdgeFilesAPI.ViewModels;
using EdgeFilesCore.Models;
using EdgeFilesCore.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace EdgeFilesAPI.Controllers
{
    public class SupplementalFileController : ApiController
    {
        public HttpResponseMessage Post(SupplementalSubmissionViewModel submitted)
        {
            var fileId = DateTime.UtcNow.ToFileTime().ToString(CultureInfo.CurrentCulture);

            var planList = new List<SupplementalDiagnosisPlan>();

            foreach (var plan in submitted.SupplementalDiagnosisDetails.GroupBy(x => x.PlanId))
            {
                var detailList = new List<SupplementalDiagnosisDetail>();

                foreach (var detail in plan)
                {
                    detailList.Add(new SupplementalDiagnosisDetail
                    {
                        SupplmentalDiagnosisDetailRecordIdentifier = detail.SupplementalDiagnosisCode,
                        AddDeleteVoidCode = detail.AddDeleteVoidCode,
                        DetailRecordProcessedDateTime = detail.DetailRecordProcessedDateTime,
                        DiagnosisTypeCode = detail.DiagnosisTypeCode,
                        OriginalClaimIdentifier = detail.OriginalClaimIdentifier,
                        OriginalSupplementalDetailId = detail.OriginalSupplementalDetailId,
                        ServiceFromDate = detail.ServiceFromDate.ToString("yyyy-MM-dd"),
                        ServiceToDate = detail.ServiceToDate.ToString("yyyy-MM-dd"),
                        SourceCode = detail.SourceCode,
                        SupplementalDiagnosisCode = detail.SupplementalDiagnosisCode,
                        InsuredMemberIdentifier = detail.InsuredMemberIdentifier,
                    });
                }

                planList.Add(new SupplementalDiagnosisPlan
                {
                    InsurancePlanIdentifier = plan.First().PlanId,
                    IncludedSupplementalDiagnosisDetail = detailList,
                    InsurancePlanFileDetailTotalQuantity = detailList.Count()
                });
            }

            var issuer = new SupplementalDiagnosisIssuer
            {
                IssuerIdentifier = submitted.IssuerIdentifier,
                IncludedSupplementalDiagnosisPlan = planList,
                IssuerClaimFileTotalQuantity = planList.Count()
            };

            var submission = new SupplementalDiagnosisSubmission
            {
                FileIdentifier = fileId,
                ExecutionZoneCode = submitted.ExecutionZoneCode,
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                SubmissionTypeCode = submitted.SubmissionTypeCode,
                InterfaceControlReleaseNumber = submitted.ExecutionZoneCode,
                IncludedSupplementalDiagnosIssuer = issuer,
                FileDetailTotalQuantity = issuer.IncludedSupplementalDiagnosisPlan.SelectMany(x => x.IncludedSupplementalDiagnosisDetail).Count()
            };

            var supplementalClaimsSubmissionXmlGenerator = new SupplementalDiagnosisSubmissionXmlGenerator();

            supplementalClaimsSubmissionXmlGenerator.SupplementalSubmission = submission;
            supplementalClaimsSubmissionXmlGenerator.HiosId = issuer.IssuerIdentifier;
            supplementalClaimsSubmissionXmlGenerator.ExecutionZone = submission.ExecutionZoneCode;

            var xmlGeneratorService = new XmlGeneratorService(supplementalClaimsSubmissionXmlGenerator);
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