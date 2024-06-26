using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ShoppingCartDbContext _context;

        public OrderRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            try
            {
                List<Order> list = await  _context.Orders.ToListAsync();
                List<OrderDTO> dtoorder = new List<OrderDTO>();

                    foreach (var order in list)
                    {
                        OrderDTO orderDTO = OrderToOrderDTO(order);
                        dtoorder.Add(orderDTO);
                    }
                    return dtoorder;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddOrder(OrderDTO orderDTO)
        {
            try
            {
                if(orderDTO==null)
                {
                    return false;
                }
                    Order order = OrderDTOToOrder(orderDTO);
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Order OrderDTOToOrder(OrderDTO orderDTO)
        {
            return new Order
            {
                UserId=orderDTO.UserId,
                PaymentId=orderDTO.PaymentId,
                ProductId=orderDTO.ProductId
            };
        }
        public OrderDTO OrderToOrderDTO(Order order)
        {
            return new OrderDTO

            {
                UserId=order.UserId,
                PaymentId=order.PaymentId,
                ProductId=order.ProductId
            };
        }  
    }
}