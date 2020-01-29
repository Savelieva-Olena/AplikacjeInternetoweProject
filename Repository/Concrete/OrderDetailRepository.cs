using Model;
using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class OrderDetailRepository : IOrderDatailRepository
    {
        private readonly AppDbContext context;

        public OrderDetailRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderDetail> GetAllOrder()
        {
            return context.OrderDetails;
        }

    }
}
