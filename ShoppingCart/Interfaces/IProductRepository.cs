using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Models;

namespace ShoppingCart.Interfaces
{
    public interface IProductRepository

    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductDTO>> AddProduct(ProductDTO product);
        Task<bool> DeleteProduct(int id);
        Task<ProductDTO> UpdateProduct(int id,ProductDTO product);
    }
}