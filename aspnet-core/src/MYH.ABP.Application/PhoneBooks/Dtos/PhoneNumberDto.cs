using Abp.AutoMapper;
using MYH.ABP.PhoneBook.PhoneNum;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace MYH.ABP.PhoneBooks.Dtos
{
    [AutoMapFrom(typeof(PhoneNumber))]
    public class PhoneNumberDto
    {
        public virtual string Number { get; set; }

        public virtual PhoneNumberType Type { get; set; }

        public virtual int PersonId { get; set; }

    }
}
