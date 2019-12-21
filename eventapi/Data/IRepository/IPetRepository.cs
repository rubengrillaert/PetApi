using petApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Data.IRepository
{
    public interface IPetRepository
    {
        Pet GetPetById(int id);
        void UpdatePet(Pet pet);
        void AddPet(Pet pet);
        void DeletePet(int id);
        void SaveChanges();
    }
}
