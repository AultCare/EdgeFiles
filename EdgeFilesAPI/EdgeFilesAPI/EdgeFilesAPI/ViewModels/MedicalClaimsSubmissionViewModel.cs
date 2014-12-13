using System.Collections.Generic;

namespace EdgeFilesAPI.ViewModels
{
    public class MedicalClaimsSubmissionViewModel : SubmissionViewModel
    {
        public List<MedicalClaimsDetailViewModel> MedicalClaims { get; set; }
    }
}