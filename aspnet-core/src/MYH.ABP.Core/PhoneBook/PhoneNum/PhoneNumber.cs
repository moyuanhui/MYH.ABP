using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities.Auditing;
using MYH.ABP.PhoneBook.Persons;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace MYH.ABP.PhoneBook.PhoneNum
{
    public class PhoneNumber :Entity<long>, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength]
        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}
