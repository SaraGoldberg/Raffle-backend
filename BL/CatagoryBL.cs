using DL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace BL
{
    public class CatagoryBL : ICatagoryBL
    {
        ICatagoryDL _catagoryDl;
        public CatagoryBL(ICatagoryDL catagory)
        {
            _catagoryDl = catagory;
        }
        public async Task<List<Category>> getCatagory()
        {
            return await _catagoryDl.getCatagory();
        }
        public async Task<List<Category>> getCatagory(int id)
        {
            return await _catagoryDl.getCatagory(id);
        }
    }
}
