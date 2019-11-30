using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using petApi.Models;

namespace eventapi.Data
{
    public class PetContext : IdentityDbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

    }
}
