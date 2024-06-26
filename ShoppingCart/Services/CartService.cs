using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Services
{
    public class CartService
    {
        private readonly ICartRepository _cartService;

        public CartService(ICartRepository cartService)
        {
            _cartService = cartService;
        }
        public async Task<bool> AddToCart(CartDTO cartDTO)
        {
            try
            {
                return await _cartService.AddToCart(cartDTO);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            try
            {
                return await _cartService.DeleteCart(cartId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CartDTO>> GetAllCarts()
        {
            try
            {
                return await _cartService.GetAllCarts();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<CartDTO> GetCartById(int cartId)
        {
            try
            {
                return await _cartService.GetCartById(cartId);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}