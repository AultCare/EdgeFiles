using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeFilesAPI.ViewModels
{
    public class SupplementalSubmissionViewModel : SubmissionViewModel
    {
        public List<SupplementalDetailViewModel> SupplementalDiagnosisDetails { get; set; }
    }
}