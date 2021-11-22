using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApplicationAngularAppStorage.Models
{
    public partial class OrderProduct
    {
        public Guid OrderProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
