using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public async Task<Category> GetIdAsync(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<bool> SaveAsync(Category category)
        {
            if (category == null)
                return false;

            try
            {
                context.Entry(category).State = category.Id == default(int) ? EntityState.Added : EntityState.Modified;

                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteAsync(Category category)
        {
            if (category == null)
                return false;
            context.Categories.Remove(category);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
