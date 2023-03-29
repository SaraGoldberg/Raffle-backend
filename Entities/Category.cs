using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
