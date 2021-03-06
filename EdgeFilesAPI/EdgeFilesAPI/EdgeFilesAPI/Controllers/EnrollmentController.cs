﻿using EdgeFilesAPI.ViewModels;
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
    public class EnrollmentController : ApiController
    {
        // POST api/<controller>
        public HttpResponseMessage Post(EnrollmentSubmissionViewModel enrolleeSubmission)
        {
            // 1. Accept list of enrollees
            // 2. Use Core classes to create list of enrollees/member profiles
            // 3. Create the headers, etc.
            // 4. Return XML generated
            var enrolleeList = new List<EnrollmentEnrollee>();
            var profileCount = 0;

            foreach (var enrollee in enrolleeSubmission.EnrolleeDetails)
            {
                var memberId = enrollee.MemberId;
                var check = enrolleeList.Where(x => x.InsuredMemberIdentifier == memberId);
                if (check.Any()) continue;

                var e = new EnrollmentEnrollee
                {
                    InsuredMemberIdentifier = memberId,
                    InsuredMemberBirthDate = enrollee.BirthDate.ToString("yyyy-MM-dd"),
                    InsuredMemberGenderCode = enrollee.Gender,
                    IncludedInsuredMemberProfile = new List<EnrollmentEnrolleeProfile>()
                };

                var enrollee1 = enrollee;
                var otherRecordsForthisMember = enrolleeSubmission.EnrolleeDetails.Where(x => x.MemberId == enrollee1.MemberId);

                var profilesForThisMember = new List<EnrollmentEnrolleeProfile>();

                foreach (var enrolleeDetailsViewModel in otherRecordsForthisMember)
                {
                    var profile = new EnrollmentEnrolleeProfile
                    {
                        CoverageStartDate = enrolleeDetailsViewModel.CoverageStart.ToString("yyyy-MM-dd"),
                        CoverageEndDate = (enrolleeDetailsViewModel.CoverageEnd == null) ? new DateTime(enrollee.CoverageStart.Year, 12, 31).ToString("yyyy-MM-dd") : enrolleeDetailsViewModel.CoverageEnd.Value.ToString("yyyy-MM-dd"),
                        EnrollmentMaintenanceTypeCode = enrolleeDetailsViewModel.MaintenanceTypeCode,
                        InsurancePlanIdentifier = enrolleeDetailsViewModel.PlanId,
                        InsurancePlanPremiumAmount = enrolleeDetailsViewModel.PremiumAmount,
                        RateAreaIdentifier = String.IsNullOrEmpty(enrolleeDetailsViewModel.RatingArea) ? enrollee.RatingArea : enrolleeDetailsViewModel.RatingArea,
                        SubscriberIdentifier = enrolleeDetailsViewModel.SubscriberInd ? "" : enrolleeDetailsViewModel.SubscriberMemberId,
                        SubscriberIndicator = enrolleeDetailsViewModel.SubscriberInd ? "S" : ""
                    };
                    profileCount += 1;
                    profilesForThisMember.Add(profile);
                }

                e.IncludedInsuredMemberProfile.AddRange(profilesForThisMember);
                enrolleeList.Add(e);
            }

            var issuer = new EnrollmentIssuer { IncludedInsuredMembers = new List<EnrollmentEnrollee>() };
            issuer.IncludedInsuredMembers.AddRange(enrolleeList);
            issuer.IssuerInsuredMemberProfileTotalQuantity = profileCount;
            issuer.IssuerInsuredMemberTotalQuantity = enrolleeList.Count();
            issuer.IssuerIdentifier = enrolleeSubmission.IssuerIdentifier;

            var fileId = DateTime.UtcNow.ToFileTime().ToString(CultureInfo.CurrentCulture);

            var submission = new EnrollmentSubmission
            {
                ExecutionZoneCode = enrolleeSubmission.ExecutionZoneCode,
                GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                IncludedEnrollmentIssuer = issuer,
                InsuredMemberProfileTotalQuantity = profileCount,
                InsuredMemberTotalQuantity = enrolleeList.Count(),
                FileIdentifier = fileId.Substring(fileId.Length - 12, 12),
                InterfaceControlReleaseNumber = enrolleeSubmission.InterfaceControlReleaseNumber,
                SubmissionTypeCode = enrolleeSubmission.SubmissionTypeCode
            };

            var enrollmentSubmissionXml = new EnrollmentSubmissionXmlGenerator
            {
                EnrollmentSubmission = submission,
                ExecutionZone = enrolleeSubmission.ExecutionZoneCode,
                HiosId = enrolleeSubmission.IssuerIdentifier
            };

            var xmlGeneratorService = new XmlGeneratorService(enrollmentSubmissionXml);

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