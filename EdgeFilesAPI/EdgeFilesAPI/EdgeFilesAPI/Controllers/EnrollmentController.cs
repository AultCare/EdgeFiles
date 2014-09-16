using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml;
using EdgeFilesAPI.ViewModels;
using EdgeFilesCore.Models;
using EdgeFilesCore.Services;

namespace EdgeFilesAPI.Controllers
{
    public class EnrollmentController : ApiController
    {
        // POST api/<controller>
        public string Post(EnrollmentSubmissionViewModel enrolleeSubmission)
        {
            // 1. Accept list of enrollees
            // 2. Use Core classes to create list of enrollees/member profiles
            // 3. Create the headers, etc.
            // 4. Return XML generated?
            var enrolleeList = new List<EnrollmentEnrollee>();

            foreach (var enrollee in enrolleeSubmission.EnrolleeDetails)
            {
                var e = new EnrollmentEnrollee
                {
                    InsuredMemberBirthDate = enrollee.BirthDate,
                    InsuredMemberGenderCode = enrollee.Gender,

                    // TODO -- one EnrollmentEnrolleeProfile per enrollment period
                    IncludedInsuredMemberProfile = new List<EnrollmentEnrolleeProfile>()
                };

                var profile = new EnrollmentEnrolleeProfile
                {
                    CoverageStartDate = enrollee.CoverageStart,
                    CoverageEndDate = enrollee.CoverageEnd ?? new DateTime(enrollee.CoverageStart.Year, 12, 31),
                    EnrollmentMaintenanceTypeCode = enrollee.MaintenanceTypeCode,
                    InsurancePlanIdentifier = enrollee.PlanId,
                    InsurancePlanPremiumAmount = enrollee.PremiumAmount,
                    RateAreaIdentifier = enrollee.RatingArea,
                    SubscriberIdentifier = enrollee.SubscriberInd ? "" : enrollee.SubscriberMemberId.ToString(), // TODO - masked ID
                    SubscriberIndicator = enrollee.SubscriberInd ? "S" : ""
                };

                e.IncludedInsuredMemberProfile.Add(profile);
                enrolleeList.Add(e);
            }

            var issuer = new EnrollmentIssuer();
            issuer.IncludedInsuredMembers = new List<EnrollmentEnrollee>();
            issuer.IncludedInsuredMembers.AddRange(enrolleeList);

            var submission = new EnrollmentSubmission
            {
                ExecutionZoneCode = "",
                GenerationDateTime = DateTime.Now,
                IncludedEnrollmentIssuer = issuer
            };

            //enrolleeSubmission.FileIdentifier = "00";
            //enrolleeSubmission.ExecutionZoneCode = ;
            //enrolleeSubmission.GenerationDateTime = DateTime.Now.ToUniversalTime();
            //enrolleeSubmission.InterfaceControlReleaseNumber = "02.00.00";
            //enrolleeSubmission.SubmissionTypeCode = "E";
            enrolleeSubmission.InsuredMemberProfileTotalQuantity = enrolleeList.Count();
            enrolleeSubmission.InsuredMemberProfileTotalQuantity = 0; // TODO

            EnrollmentSubmissionXmlGenerator enrollmentSubmissionXml = new EnrollmentSubmissionXmlGenerator
            {
                EnrollmentSubmission = submission,
                ExecutionZone = enrolleeSubmission.ExecutionZoneCode.First(),
                HiosId = ""
            };

            XmlGeneratorService xmlGeneratorService = new XmlGeneratorService(enrollmentSubmissionXml);

            string path = HttpContext.Current.Request.MapPath(@"~/");
            var filePath = xmlGeneratorService.GenerateXml(path);

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            var xml = doc.OuterXml;
            File.Delete(filePath);

            return xml;
        }
    }
}