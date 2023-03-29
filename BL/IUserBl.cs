using System.Threading.Tasks;
using WebApplication1.Models;

namespace BL
{
    public interface IUserBL
    {
        Task<User> getUser(string name, string pswd);
        Task postUser(User value);
        Task putUser(int id, User userToUpdate);
    }
}