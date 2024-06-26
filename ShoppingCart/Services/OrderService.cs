using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderService;

        public OrderService(IOrderRepository orderService)
        {
            _orderService = orderService;
        }
        public async Task<bool> AddOrder(OrderDTO orderDTO)
        {
            try
            {
                return await _orderService.AddOrder(orderDTO);
            }
            catch(Exception)
            {
               throw; 
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            try
            {
                return await _orderService.GetAllOrders();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}