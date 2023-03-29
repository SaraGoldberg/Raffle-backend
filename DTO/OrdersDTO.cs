using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrdersDTO
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? OrderSum { get; set; }
        public int UserId { get; set; }
    }
}
