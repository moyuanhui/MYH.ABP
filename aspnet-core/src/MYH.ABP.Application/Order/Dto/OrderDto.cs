using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace MYH.ABP.Order.Dto
{
    [AutoMapFrom(typeof(OrderInfo))]
    public class OrderDto : Entity<int>
    {
        public string OrderNum { get; set; }

        public string OrderMsg { get; set; }
    }
}
