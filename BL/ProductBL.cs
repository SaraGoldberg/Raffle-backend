using DL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace BL
{
    public class ProductBL : IProductBL
    {
        IProductDL _productDl;
        public ProductBL(IProductDL product)
        {
            _productDl = product;
        }
        public async Task<List<Product>> getProduct()
        {
            return await _productDl.getProduct();
        }
        public async Task<List<Product>> getProduct(int id)
        {
            return await _productDl.getProduct(id);
        }
    }
}
