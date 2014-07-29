using System;

namespace EdgeFilesCore.Models
{
    public class InsuredMember
    {
        public int RecordIdentifier { get; set; }

        public string InsuredMemberIdentifier { get; set; }

        public DateTime InsuredMemberBirthDate { get; set; }

        public string InsuredMemberGenderCode { get; set; }

        public InsuredMemberProfile IncludedInsuredMemberProfile { get; set; }
    }
}