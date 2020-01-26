using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        //[Key, ForeignKey("OrderDetail")]
        //public int OrderDetailId { get; set; }
        public virtual OrderDetail OrderDetailref { get; set; }
    }
}
