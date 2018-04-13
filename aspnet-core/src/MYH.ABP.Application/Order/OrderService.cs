using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using AutoMapper;
using MYH.ABP.Order.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MYH.ABP.Order
{
    public class OrderService : ABPAppServiceBase, IOrderService
    {
        public readonly IRepository<OrderInfo> _orderRepository;

        public OrderService(
            IRepository<OrderInfo> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// 订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OrderDto> Create(OrderDto input)
        {

            var order = ObjectMapper.Map<OrderInfo>(input);
            for (int i = 0; i < 100000;i++)
            {
                order.OrderNum = i.ToString() ;
                order.OrderMsg = "test" + i.ToString();
                await _orderRepository.InsertAsync(order);
            }
            
            return input;
        }
    }
}
