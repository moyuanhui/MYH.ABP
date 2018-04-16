using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MYH.ABP.Member
{
    public class MemberEntity : Entity<int>
    {
        [StringLength(50)]
        [Required]
        public string CompanyId { get; set; }
        [StringLength(50)]
        [Required]

        public string AccountId { get; set; }

        public string UnionId { get; set; }

        public string FakeId { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Sex { get; set; }

        /// <summary>
        /// 小程序OpenId
        /// </summary>
        public string OpenIdMini { get; set; }

        /// <summary>
        /// 公众号OpenId
        /// </summary>
        public string OpenIdMp { get; set; }

        public string NickName { get; set; }

        public string HeadUrl { get; set; }

    }
}
