using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DL
{
    public class OrderDL : IOrderDL
    {
        Api_dataBaseContext _db;
        public OrderDL(Api_dataBaseContext api_DataBaseContext)
        {
            _db = api_DataBaseContext;
        }
        public async Task<List<Order>> getOrder(int order)
        {
            return await _db.Order.Where(o => o.OrderId == order).ToListAsync();
        }

        public async Task<Order> postOrder(Order order)
        {
            await _db.Order.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }
    }
}
