using DL;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace BL
{
    public class OrderBL : IOrderBL
    {
        Api_dataBaseContext _db;
        IOrderDL _orderDl;
        ILogger<OrderBL> _logger;

        public OrderBL(IOrderDL order, ILogger<OrderBL> logger, Api_dataBaseContext db)
        {
            _orderDl = order;
            _logger = logger;
            _db = db;
        }
        public Task<List<Order>> getOrder(int id)
        {
            return _orderDl.getOrder(id);
        }
        public async Task<Order> postOrder(Order order)
        {
            int sum = 0;
            foreach (var product in order.OrderItem)
            {
                Product p = await _db.Product.FindAsync(product.ProductId);
                sum += (int) product.Quantity * (int) p.ProductPrice;
            }
            if(order.OrderSum != sum)
            {
                _logger.LogInformation("\nPay attention!!!, the order sum were changed, check why...\n");
                order.OrderSum = sum;
            }
            return await _orderDl.postOrder(order);
        }
    }
}