using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;

namespace ShoppingCart.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<bool> AddOrder(OrderDTO orderDTO);

    }
}