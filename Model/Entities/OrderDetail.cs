﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class OrderDetail
    {
        //[Key, Column("OrderDetailID")]
        //[ForeignKey("Product")]
        public int Id { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        //public int ProductId { get; set; }
        //public virtual Product Product { get; set; }
    }
}
