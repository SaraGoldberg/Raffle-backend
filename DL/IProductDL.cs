using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DL
{
    public interface IProductDL
    {
        Task<List<Product>> getProduct();
        //Task<Product> getProduct(int productId);
        Task<List<Product>> getProduct(int category);
    }
}