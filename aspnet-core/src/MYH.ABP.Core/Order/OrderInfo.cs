using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace MYH.ABP.Order
{
    public class OrderInfo : Entity<int>
    {
        public string OrderNum { get; set; }

        public string OrderMsg { get; set; }
    }
}
