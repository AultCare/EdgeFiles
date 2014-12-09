using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using EdgeFilesCore.Models;

namespace EdgeFilesAPI.ViewModels
{
    public class PharmacySubmissionViewModel : SubmissionViewModel
    {
        public List<PharmacyClaimLevelViewModel> PharmacyClaims { get; set; }
    }
}