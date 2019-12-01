using eventapi.Data;
using Microsoft.EntityFrameworkCore;
using petApi.Data.IRepository;
using petApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Properties
        private readonly PetContext _dbContext;
        private readonly DbSet<User> _users;
        #endregion

        #region Constructors
        public UserRepository(PetContext petContext)
        {
            _dbContext = petContext;
            _users = _dbContext.User;
        }
        #endregion

        #region Constructors
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public List<Appointment> GetAppointmentsByUserId(int id)
        {
            return _users.Include(u => u.Appointments).Include(u => u.Pets).FirstOrDefault(u => u.Id == id).Appointments.ToList();
        }

        public User GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public List<Pet> GetPetsByUserId(int id)
        {
            return _users.Include(u => u.Pets).FirstOrDefault(u => u.Id == id).Pets.ToList();
        }

        public List<User> GetUsers()
        {
            return _users.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public bool UserExists(string email)
        {
            return _dbContext.User.Where(u => u.Email == email).FirstOrDefault() != null;
        }

        public void UpdateUser(User user)
        {
            _dbContext.User.Update(user);
        }
        #endregion
    }
}
