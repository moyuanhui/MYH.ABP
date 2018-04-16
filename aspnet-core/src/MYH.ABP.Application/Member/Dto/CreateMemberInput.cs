using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MYH.ABP.Member.Dto
{
    public class CreateMemberInput
    {
        [Required]
        public string CompanyId { get; set; }

        [Required]
        public string AccountId { get; set; }

        [Required]
        public string OpenIdMp { get; set; }
    }
}
