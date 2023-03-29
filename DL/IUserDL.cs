using System.Threading.Tasks;
using WebApplication1.Models;

namespace DL
{
    public interface IUserDL
    {
        Task<User> getUser(string name, string pswd);
        Task postUser(User value);
        Task putUser(int id, User userToUpdate);
    }
}