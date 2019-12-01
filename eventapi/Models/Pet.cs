using petApi.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Models
{
    public class Pet
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        #endregion

        #region Collections
        public ICollection<Appointment> Appointments { get; set; }
        #endregion

        #region Constructors
        public Pet()
        {
            Appointments = new List<Appointment>();
        }
        #endregion

        #region Methodes
        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public static PetInListDTO MapPetToPetInListDTO(Pet pet){
            if(pet != null)
            {
                return new PetInListDTO()
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Picture = pet.Picture
                };
            }
            return null;
        }

        public static PetInfoDTO MapPetToPetInfoDTO(Pet pet)
        {
            if (pet != null)
            {
                return new PetInfoDTO()
                {
                    Id = pet.Id,
                    Picture = pet.Picture,
                    Name = pet.Name,
                    Appointments = pet.Appointments.Select(a => Appointment.MapAppointmentToAppointmentInListPetInfoDTO(a)).ToList(),
                    BirthDate = pet.BirthDate,
                    Description = pet.Description
                };
            }
            return null;
        }

        public static Pet MapAddPetDTOToPet(AddPetDTO addedPet)
        {
            if(addedPet != null)
            {
                return new Pet()
                {
                    Description = addedPet.Description,
                    BirthDate = addedPet.BirthDate,
                    Name = addedPet.Name,
                    Picture = addedPet.Picture
                };
            }
            return null;
        }
        #endregion
    }
}
