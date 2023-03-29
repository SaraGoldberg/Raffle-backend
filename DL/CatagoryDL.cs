using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DL
{
    public class CatagoryDL : ICatagoryDL
    {
        Api_dataBaseContext _db;
        public CatagoryDL(Api_dataBaseContext api_DataBaseContext)
        {
            _db = api_DataBaseContext;
        }
        public async Task<List<Category>> getCatagory()
        {
            List<Category> categories = await _db.Category.ToListAsync();
            return categories;
        }
        public async Task<List<Category>> getCatagory(int id)
        {
            List<Category> categories = await _db.Category.Where(c => c.CatagoryId == id).ToListAsync();
            return categories;
        }
    }
}
