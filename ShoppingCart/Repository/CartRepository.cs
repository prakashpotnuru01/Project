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
    public class CartRepository:ICartRepository
    {
        private readonly ShoppingCartDbContext _context;

        public CartRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CartDTO>> GetAllCarts()
        {
            try
            {
                List<Cart> list = await  _context.Carts.ToListAsync();
                List<CartDTO> dtoCart = new List<CartDTO>();

                    foreach (var cart in list)
                    {
                        CartDTO cartDTO = CartToCartDTO(cart);
                        dtoCart.Add(cartDTO);
                    }
                    return dtoCart;
            }
            catch (Exception)
            {
                throw;
            } 

        }
        public async Task<CartDTO> GetCartById(int userId)
        {
            try
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(c=>c.UserId == userId);
                if(cart !=null)
                {
                    return CartToCartDTO(cart);
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<bool> AddToCart(CartDTO cartDTO)
        {
            try
            {
                if(cartDTO==null)
                {
                    return false;
                }
                    Cart cart = CartDTOToCart(cartDTO);
                    _context.Carts.Add(cart);
                    await _context.SaveChangesAsync();
                    return true;
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
                var cart = await _context.Addresses.FirstOrDefaultAsync(c=>c.UserId == cartId);
                if(cart != null)
                {
                    _context.Addresses.Remove(cart);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                throw;
            }  
        }
        public Cart CartDTOToCart(CartDTO cartDTO)
        {
            return new Cart
            {
                ProductId=cartDTO.ProductId,
                UserId=cartDTO.UserId,
                CartValue=cartDTO.CartValue
            };
        }

        public CartDTO CartToCartDTO(Cart cart)
        {
            return new CartDTO
            {
                ProductId=cart.ProductId,
                UserId=cart.UserId,
                CartValue=cart.CartValue
            };
        }
        
    }
}