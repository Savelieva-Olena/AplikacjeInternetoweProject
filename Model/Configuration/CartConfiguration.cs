using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configuration
{
    public class CartConfiguration: EntityTypeConfiguration<Cart>
    {
        public CartConfiguration()
        {
            Property(x => x.RecordId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            HasMany(x => x.Products).WithRequired(x => x.Cart).HasForeignKey(x => x.Id);
        }
    }
}
