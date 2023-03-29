using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace BL
{
    public interface IOrderBL
    {
        Task<List<Order>> getOrder(int id);
        Task<Order> postOrder(Order order);
    }
}