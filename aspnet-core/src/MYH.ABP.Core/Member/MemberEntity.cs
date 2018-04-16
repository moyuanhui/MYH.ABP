using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYH.ABP.Member
{
    public class MemberEntity : FullAuditedEntity<int>
    {
        public string CompanyId;

        public string AccountId;

        public string UnionId;

        public string FakeId;

        public string CustomerId;

        public string CustomerName;

        public string Sex;

        /// <summary>
        /// 小程序OpenId
        /// </summary>
        public string OpenIdMini;

        /// <summary>
        /// 公众号OpenId
        /// </summary>
        public string OpenIdMp;

        public string NickName;

        public string HeadUrl;
    }
}
