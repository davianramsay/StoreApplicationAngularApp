using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApplicationAngularAppStorage.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
