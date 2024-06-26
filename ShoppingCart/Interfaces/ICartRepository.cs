using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;

namespace ShoppingCart.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartDTO>> GetAllCarts();
        Task<CartDTO> GetCartById(int userId);
        Task<bool> AddToCart(CartDTO cartDTO);
        Task<bool> DeleteCart(int cartId);
    }
}