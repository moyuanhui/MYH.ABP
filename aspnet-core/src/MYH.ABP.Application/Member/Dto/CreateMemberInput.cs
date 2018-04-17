using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MYH.ABP.Member.Dto
{
    /// <summary>
    /// 创建用户InputDto
    /// </summary>
    [AutoMapTo(typeof(MemberEntity))]
    public class CreateMemberInput
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        [Required]
        public string CompanyId { get; set; }

        /// <summary>
        /// 账户ID
        /// </summary>
        [Required]
        public string AccountId { get; set; }

        /// <summary>
        /// 公众号OpenId
        /// </summary>
        [Required]
        public string OpenIdMp { get; set; }
    }
}
