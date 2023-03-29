using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DL
{
    public interface IOrderDL
    {
        Task<List<Order>> getOrder(int order);
        Task<Order> postOrder(Order order);
    }
}