using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;

namespace ShoppingCart.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> AddCategory(CategoryDTO categoryDTO);
        Task<bool> DeleteUser(int categoryId);
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetCategoryById(int categoryId);
        Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO categoryDTO);
    }
}