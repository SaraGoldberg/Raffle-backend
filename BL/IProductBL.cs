using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace BL
{
    public interface IProductBL
    {
        Task<List<Product>> getProduct();
        Task<List<Product>> getProduct(int category);
    }
}