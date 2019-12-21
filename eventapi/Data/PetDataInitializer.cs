using Microsoft.AspNetCore.Identity;
using petApi.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eventapi.Data
{
    public class PetDataInitializer
    {
        private readonly PetContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PetDataInitializer(PetContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                await CreateRoles();
                Pet pet = new Pet()
                {
                    BirthDate = new DateTime(),
                    Description = "Test pet",
                    Name = "Nap",
                    Picture = "picture url"
                };

                Appointment appointment = new Appointment()
                {
                    City = "Oosterzele",
                    Date = new DateTime(),
                    Description = "Test appointment",
                    Doctor = "O'Mels",
                    Housenumber = "31",
                    Pet = pet,
                    PostalCode = "9860",
                    Street = "Patrijzenstraat",
                    Title = "Laserpen gameplay"
                };

                User user = new User()
                {
                    Email = "ruben.grillaert@hotmail.com",
                    Surename = "Ruben",
                    Familyname = "Grillaert",
                    Username = "Wazzaaaa97"
                };

                user.AddAppointment(appointment);
                user.AddPet(pet);


                _dbContext.User.Add(user);
                await CreateUser("Wazzaaaa97", user.Email, "P@ssword123");
            }

            _dbContext.SaveChanges();
        }

        private async Task CreateUser(string username, string email, string password)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "USER"));
            await _userManager.AddToRoleAsync(user, "USER");
        }

        private async Task CreateRoles() {
            await _roleManager.CreateAsync(new IdentityRole("USER"));
        }

    }
}
