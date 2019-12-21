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
    public class PetRepository : IPetRepository
    {
        private readonly PetContext _dbContext;
        private readonly DbSet<Pet> _pets;

        public PetRepository(PetContext petContext)
        {
            _dbContext = petContext;
            _pets = _dbContext.Pet;
        }

        public void AddPet(Pet pet)
        {
            _pets.Add(pet);
        }

        public void DeletePet(int id)
        {
            Pet pet = _pets.FirstOrDefault(p => p.Id == id);
            _pets.Remove(pet);
        }

        public Pet GetPetById(int id)
        {
            return _pets.Include(p => p.Appointments).FirstOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePet(Pet pet)
        {
            _pets.Update(pet);
        }
    }
}
