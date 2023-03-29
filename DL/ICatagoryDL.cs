using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DL
{
    public interface ICatagoryDL
    {
        Task<List<Category>> getCatagory();
        Task<List<Category>> getCatagory(int id);
    }
}