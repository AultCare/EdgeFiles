using System.Net.Http;
using System.Web.Http;
using EdgeFilesAPI.ViewModels;

namespace EdgeFilesAPI.Controllers
{
    public class MedicalClaimsController : ApiController
    {
        // POST api/<controller>
        public HttpResponseMessage Post(MedicalClaimsSubmissionViewModel medicalSubmission)
        {
            return null;

            //// todo -- move this
            //Mapper.CreateMap<PharmacyClaimLevelViewModel, PharmacyClaimLevel>();

            //var fileId = DateTime.UtcNow.ToFileTime().ToString(CultureInfo.CurrentCulture);

            //var planClaimCollection = new List<PharmacyClaimInsurancePlan>();

            //// todo--split out by planid
            //foreach (var claims in pharmacySubmission.PharmacyClaims.GroupBy(x => x.PlanId.ToLower()))
            //{
            //    var pharmclaims = Mapper.Map<List<PharmacyClaimLevel>>(claims);
            //    //pharmClaims.Add(pharmclaim);

            //    var planClaims = new PharmacyClaimInsurancePlan
            //    {
            //        IncludedPharmacyClaimDetail = pharmclaims,
            //        InsurancePlanClaimDetailTotalQuantity = pharmclaims.Count(),
            //        InsurancePlanIdentifier = claims.First().PlanId,
            //        PolicyPaidTotalAmount = pharmclaims.Sum(x => x.PolicyPaidAmount),
            //        RecordIdentifier = 0
            //    };

            //    planClaimCollection.Add(planClaims);
            //}

            //var issuer = new PharmacyClaimIssuer
            //{
            //    IssuerIdentifier = pharmacySubmission.IssuerIdentifier,
            //    //RecordIdentifier =
            //    IncludedPharmacyClaimInsurancePlans = planClaimCollection
            //};

            //var submission = new PharmacyClaimSubmission
            //{
            //    ExecutionZoneCode = pharmacySubmission.ExecutionZoneCode,
            //    ClaimDetailTotalQuantity = pharmacySubmission.PharmacyClaims.Count(),
            //    IncludedPharmacyClaimIssuer = issuer,
            //    GenerationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            //    FileIdentifier = fileId.Substring(fileId.Length - 12, 12),
            //    //InsurancePlanPaidOnFileTotalAmount = null,
            //    InterfaceControlReleaseNumber = pharmacySubmission.InterfaceControlReleaseNumber,
            //    SubmissionTypeCode = pharmacySubmission.SubmissionTypeCode
            //};

            //var pharmacySubmissionXml = new PharmacyClaimSubmissionXmlGenerator
            //{
            //    PharmacyClaimsSubmission = submission,
            //    ExecutionZone = pharmacySubmission.ExecutionZoneCode,
            //    HiosId = pharmacySubmission.IssuerIdentifier
            //};

            //var xmlGeneratorService = new XmlGeneratorService(pharmacySubmissionXml);

            //var path = HttpContext.Current.Request.MapPath(@"~/Output");
            //var filePath = xmlGeneratorService.GenerateXml(path);
            //var filename = filePath.Replace(path, "");
            //filename = filename.Replace('"', ' ');
            //filename = filename.Replace('\\', ' ');

            //Stream result = new FileStream(filePath, FileMode.Open);
            //result.Position = 0;
            //var response = new HttpResponseMessage { Content = new StreamContent(result) };
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            //{
            //    FileName = filename
            //};
            //return response;
        }
    }
}