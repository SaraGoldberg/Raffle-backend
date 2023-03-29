using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace BL
{
    public interface ICatagoryBL
    {
        Task<List<Category>> getCatagory();
        Task<List<Category>> getCatagory(int id);
    }
}