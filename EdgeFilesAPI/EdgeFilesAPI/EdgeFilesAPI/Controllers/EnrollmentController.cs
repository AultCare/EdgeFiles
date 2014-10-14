using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            // 4. Return XML generated
            var enrolleeList = new List<EnrollmentEnrollee>();
            int profileCount = 0;

            foreach (var enrollee in enrolleeSubmission.EnrolleeDetails)
            {
                // If it is not a subscriber we want to continue.
                if (!enrollee.SubscriberInd) continue;

                var e = new EnrollmentEnrollee
                {
                    InsuredMemberIdentifier = MaskService.PasswordHash.CreateHash(enrollee.MemberId),
                    InsuredMemberBirthDate = enrollee.BirthDate.ToString("yyyy-MM-dd"),
                    InsuredMemberGenderCode = enrollee.Gender,
                    IncludedInsuredMemberProfile = new List<EnrollmentEnrolleeProfile>()
                };

                EnrolleeDetailsViewModel enrollee1 = enrollee;
                var dependents = enrolleeSubmission.EnrolleeDetails.Where(x => x.SubscriberMemberId.ToString() == enrollee1.MemberId.ToString());

                var dependentProfiles = new List<EnrollmentEnrolleeProfile>();

                // TODO -- need to do this per enrollment period

                foreach (var enrolleeDetailsViewModel in dependents)
                {
                    var profile = new EnrollmentEnrolleeProfile
                    {
                        CoverageStartDate = enrolleeDetailsViewModel.CoverageStart.ToString("yyyy-MM-dd"),
                        CoverageEndDate = (enrolleeDetailsViewModel.CoverageEnd == null) ? new DateTime(enrollee.CoverageStart.Year, 12, 31).ToString("yyyy-MM-dd") : enrolleeDetailsViewModel.CoverageEnd.Value.ToString("yyyy-MM-dd"),
                        EnrollmentMaintenanceTypeCode = enrolleeDetailsViewModel.MaintenanceTypeCode,
                        InsurancePlanIdentifier = enrolleeDetailsViewModel.PlanId,
                        InsurancePlanPremiumAmount = enrolleeDetailsViewModel.PremiumAmount,
                        RateAreaIdentifier = String.IsNullOrEmpty(enrolleeDetailsViewModel.RatingArea) ? enrollee.RatingArea : enrolleeDetailsViewModel.RatingArea,
                        SubscriberIdentifier = enrolleeDetailsViewModel.SubscriberInd ? "" : MaskService.PasswordHash.CreateHash(enrolleeDetailsViewModel.SubscriberMemberId.ToString()),
                        SubscriberIndicator = enrolleeDetailsViewModel.SubscriberInd ? "S" : ""
                    };
                    profileCount += 1;
                    dependentProfiles.Add(profile);
                }

                e.IncludedInsuredMemberProfile.AddRange(dependentProfiles);
                enrolleeList.Add(e);
            }

            var issuer = new EnrollmentIssuer { IncludedInsuredMembers = new List<EnrollmentEnrollee>() };
            issuer.IncludedInsuredMembers.AddRange(enrolleeList);
            issuer.IssuerInsuredMemberProfileTotalQuantity = profileCount;
            issuer.IssuerInsuredMemberTotalQuantity = enrolleeList.Count();
            issuer.IssuerIdentifier = enrolleeSubmission.IssuerIdentifier;

            var fileId = DateTime.UtcNow.ToFileTime().ToString();

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

            EnrollmentSubmissionXmlGenerator enrollmentSubmissionXml = new EnrollmentSubmissionXmlGenerator
            {
                EnrollmentSubmission = submission,
                ExecutionZone = enrolleeSubmission.ExecutionZoneCode.First(),
                HiosId = enrolleeSubmission.IssuerIdentifier
            };

            XmlGeneratorService xmlGeneratorService = new XmlGeneratorService(enrollmentSubmissionXml);

            string path = HttpContext.Current.Request.MapPath(@"~/Output");
            var filePath = xmlGeneratorService.GenerateXml(path);

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            return filePath;
            //            var xml = doc.OuterXml;
            //File.Delete(filePath);
            //          xml = xml.Replace(@"\", @"""");
            //        return new HttpResponseMessage { Content = new StringContent(xml, Encoding.UTF8, "application/xml") };
        }
    }
}