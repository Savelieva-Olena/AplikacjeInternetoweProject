using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ICategoryRepository
    {
        Task<Category> GetIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<bool> SaveAsync(Category category);
        Task<bool> DeleteAsync(Category category);

    }
}
