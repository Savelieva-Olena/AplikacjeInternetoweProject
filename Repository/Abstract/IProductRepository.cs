using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IProductRepository
    {
        Task<Product> GetIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<bool> SaveAsync(Product product);
        Task<bool> DeleteAsync(Product product);
    }
}
