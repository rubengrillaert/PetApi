using petApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Data.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetById(int id);
        User GetByEmail(string email);
        void AddUser(User user);
        void SaveChanges();
        bool UserExists(string email);
    }
}
