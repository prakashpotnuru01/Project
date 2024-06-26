using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryService;

        public CategoryService(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<bool> AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                return await _categoryService.AddCategory(categoryDTO);
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public async Task<bool> DeleteUser(int categoryId)
        {
            try
            {
                return await _categoryService.DeleteUser(categoryId);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            try
            {
                return await _categoryService.GetAllCategories();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<CategoryDTO> GetCategoryById(int categoryId)
        {
            try
            {
                return await _categoryService.GetCategoryById(categoryId);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO categoryDTO)
        {
            try
            {
                return await _categoryService.UpdateCategory(categoryId,categoryDTO);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}