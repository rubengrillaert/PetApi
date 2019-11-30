using Microsoft.AspNetCore.Identity;
using petApi.Models;
using System.Threading.Tasks;

namespace eventapi.Data
{
    public class PetDataInitializer
    {
        private readonly PetContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public PetDataInitializer(PetContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                User user = new User()
                {
                    Email = "ruben.grillaert@hotmail.com",
                    City = "Wetteren",
                    Country = "België",
                    Housenumber = "3",
                    Name = "Xenox",
                    PostalCode = "9230",
                    Street = "Kalkensteenweg",
                    Username = "Wazzaaaa97"
                };
                _dbContext.User.Add(user);
                await CreateUser("Wazzaaaa97", user.Email, "P@ssword123");
            }
        }

        private async Task CreateUser(string username, string email, string password)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            await _userManager.CreateAsync(user, password);
        }

    }
}
