using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYH.ABP.PhoneBook.Persons
{
    public class Person:FullAuditedEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
        public string Address { get; set; }
    }
}
