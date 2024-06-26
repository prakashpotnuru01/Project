using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Services
{
    public class ProductService
    {
        private readonly IProductRepository IProduct;

        public ProductService(IProductRepository _IProduct)
        {
            IProduct=_IProduct;
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            try{
                return await IProduct.GetProducts();
            }
            catch(Exception){
                throw;
            }    
        }

        public async Task<IEnumerable<ProductDTO>> AddProduct(ProductDTO productDTO)
        {
            try{
                return await IProduct.AddProduct(productDTO);
            }
            catch (Exception){
                throw;
            }   
        }

        public async Task<ProductDTO> UpdateProduct(int id,ProductDTO p)
        {
            try{
                return await IProduct.UpdateProduct(id,p);
            }
            catch(Exception)
            {
                throw;
            }   
        }
        public async Task<bool> DeleteProduct(int id)
        {
            try{
                return await IProduct.DeleteProduct(id);
            }
            catch(Exception)
            {
                throw;
            }  
        }
    }
}