using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cart_Administration.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public int CategoryID { get; set; }
        public short Quantity { get; set; }
    }
}