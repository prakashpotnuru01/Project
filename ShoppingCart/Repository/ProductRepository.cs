using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingCartDbContext _context;

        public ProductRepository(ShoppingCartDbContext context)
        {
            _context=context;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            try
            {
                List<Product> list = await _context.Products.ToListAsync();
                List<ProductDTO> DTOlist = new List<ProductDTO>();

                foreach(Product item in list)
                {
                    DTOlist.Add(ProductToDTO(item));
                }
                return DTOlist;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> AddProduct(ProductDTO productDTO)
        {
            try
            {
                Product product = DTOToProduct(productDTO);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                List<Product> list = _context.Products.ToList();
                List<ProductDTO> DTOlist = new List<ProductDTO>();

                foreach(Product item in list)
                {
                        DTOlist.Add(ProductToDTO(item));
                }
                return DTOlist;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public async Task<ProductDTO> UpdateProduct(int productId,ProductDTO p)
        {
            try
            {
                Product product = DTOToProduct(p);
                var updateProduct = _context.Products.FirstOrDefault(c=>c.ProductId == productId);
                if(updateProduct!=null)
                {
                    updateProduct.ProductName=product.ProductName;
                    updateProduct.ProductPrice=product.ProductPrice;
                    updateProduct.ProductQuantity=product.ProductQuantity;
                    updateProduct.ProductDescription=product.ProductDescription;
                    updateProduct.ProductLink=product.ProductLink;
                    updateProduct.UserId=product.UserId;
                    await _context.SaveChangesAsync();
                    return ProductToDTO(updateProduct);
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(c=>c.ProductId == productId);
                if(product!=null)
                {
                    _context.Products.Remove(product);
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

        private static ProductDTO ProductToDTO(Product product)
        {
            ProductDTO productDto = new ProductDTO();

            productDto.ProductName=product.ProductName;
            productDto.ProductLink=product.ProductLink;
            productDto.ProductDescription=product.ProductDescription;
            productDto.ProductPrice=product.ProductPrice;
            productDto.ProductQuantity=product.ProductQuantity;
            productDto.UserId=product.UserId;
            productDto.CategoryId=product.CategoryId;
            return productDto;
        }

        private static Product DTOToProduct(ProductDTO productDto)
        {
            Product product = new Product();
            product.ProductName=productDto.ProductName;
            product.ProductLink=productDto.ProductLink;
            product.ProductDescription=productDto.ProductDescription;
            product.ProductPrice=productDto.ProductPrice;
            product.ProductQuantity=productDto.ProductQuantity;
            product.UserId=productDto.UserId;
            product.CategoryId=productDto.CategoryId;
            return product;
        }
    }
}