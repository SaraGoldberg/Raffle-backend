using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DL
{
    public class ProductDL : IProductDL
    {
        Api_dataBaseContext _db;
        public ProductDL(Api_dataBaseContext api_DataBaseContext)
        {
            _db = api_DataBaseContext;
        }
        public async Task<List<Product>> getProduct()
        {
            List<Product> products = await _db.Product.ToListAsync();
            return products;
        }
        public async Task<List<Product>> getProduct(int category)
        {
            List<Product> products = await _db.Product.Where(p => p.CatagoryId == category).ToListAsync();
            return products;
        }
    }
}
