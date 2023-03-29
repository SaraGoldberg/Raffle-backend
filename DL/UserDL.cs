using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DL
{
    public class UserDL : IUserDL
    {
        Api_dataBaseContext _db;
        public UserDL(Api_dataBaseContext api_DataBaseContext)
        {
            _db = api_DataBaseContext;
        }

        public async Task<User> getUser(string email, string pswd)
        {
            return await _db.User.Where(u => u.UserEmail.Equals(email) && u.UserPassword.Equals(pswd)).FirstOrDefaultAsync();
        }

        public async Task putUser(int id, User userToUpdate)
        {
            var users = await _db.User.FindAsync(id);
            if (users != null)
            {
                userToUpdate.UserId = users.UserId;

                _db.Entry(users).CurrentValues.SetValues(userToUpdate);
                await _db.SaveChangesAsync();
            }
        }

        public async Task postUser(User value)
        {
            await _db.User.AddAsync(value);
            await _db.SaveChangesAsync();
        }
    }
}