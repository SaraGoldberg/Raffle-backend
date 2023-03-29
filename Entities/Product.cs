using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CatagoryId { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

        [JsonIgnore]
        public virtual Category Catagory { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
