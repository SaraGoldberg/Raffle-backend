using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? OrderSum { get; set; }
        public int UserId { get; set; }

        //[JsonIgnore]
        public virtual User User { get; set; }
        //[JsonIgnore]
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
