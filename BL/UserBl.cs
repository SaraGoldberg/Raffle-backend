using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DL;
using WebApplication1.Models;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL _userDl;
        public UserBL(IUserDL u)
        {
            _userDl = u;
        }
        public Task<User> getUser(string name, string pswd)
        {
            return _userDl.getUser(name, pswd);
        }
        public Task postUser(User value)
        {
            return _userDl.postUser(value);
        }
        public Task putUser(int id, User userToUpdate)
        {
            return _userDl.putUser(id, userToUpdate);
        }
    }
}
