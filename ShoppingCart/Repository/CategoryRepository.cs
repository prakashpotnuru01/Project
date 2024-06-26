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
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ShoppingCartDbContext _context;

        public CategoryRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                if(categoryDTO==null)
                {
                    return false;
                }
                    Category category = CategoryDTOToCategory(categoryDTO);
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();
                    return true;
            }
            catch(Exception)
            {
                throw;
            }

        }
        public async Task<bool> DeleteUser(int categoryId)
        {
            try
            {
                var category =await  _context.Categories.FirstOrDefaultAsync(c=>c.CategoryId == categoryId);
                if(category != null)
                {
                    _context.Categories.Remove(category);
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
        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            try
            {
                List<Category> list = await  _context.Categories.ToListAsync();
                List<CategoryDTO> dtocategories = new List<CategoryDTO>();

                foreach (var category in list)
                {
                    CategoryDTO categoryDTO = CategoryToCategoryDTO(category);
                    dtocategories.Add(categoryDTO);
                }
                return dtocategories;
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
                var category =await  _context.Categories.FirstOrDefaultAsync(c=>c.CategoryId == categoryId);
                if(category !=null)
                {
                    return CategoryToCategoryDTO(category);
                }
                return null!;
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
                var updatedCategory = await _context.Categories.FirstOrDefaultAsync(c=>c.CategoryId == categoryId);
                if(updatedCategory != null)
                {
                    updatedCategory.CategoryName=categoryDTO.CategoryName;
                    await _context.SaveChangesAsync();

                    return CategoryToCategoryDTO(updatedCategory);
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Category CategoryDTOToCategory(CategoryDTO categoryDTO)
        {
            return new Category
            {
                CategoryName=categoryDTO.CategoryName
            };
        }

        public CategoryDTO CategoryToCategoryDTO(Category category)
        {
            return new CategoryDTO
            {
                CategoryName=category.CategoryName
            };
        }
    }
}