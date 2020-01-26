using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Cart
    {
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public int Count { get; set; }

        public System.DateTime DateCreated { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
