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
        public DateTime TextToDate(string textDate)
        {
            int year = Int16.Parse(textDate.Substring(0, 4));
            int month = Int16.Parse(textDate.Substring(5, 2));
            int day = Int16.Parse(textDate.Substring(8, 2));
            int houres = Int16.Parse(textDate.Substring(11, 2));
            int minutes = Int16.Parse(textDate.Substring(14, 2));
            return new DateTime(year, month, day, houres, minutes, 0);
        }

        public string DateToText(DateTime date)
        {
            string month = date.Month < 10 ? "0" + date.Month : "" + date.Month;
            string day = date.Day < 10 ? "0" + date.Day : "" + date.Day;
            string houres = date.Hour < 10 ? "0" + date.Hour : "" + date.Hour;
            string minutes = date.Minute < 10 ? "0" + date.Minute : "" + date.Minute;

            return "" + date.Year + "-" + month + "-" + day + "-" + houres + ":" + minutes;
        }

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
                    Appointments = pet.Appointments.Select(a => Appointment.MapAppointmentToAppointmentInListDTO(a)).ToList(),
                    BirthDate = pet.DateToText(pet.BirthDate),
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
                    BirthDate = addedPet.TextToDate(addedPet.BirthDate),
                    Name = addedPet.Name,
                    Picture = addedPet.Picture
                };
            }
            return null;
        }

        public static Pet MapEditPetDTOToPet(EditPetDTO editPetDTO, Pet pet)
        {
            pet.BirthDate = editPetDTO.TextToDate(editPetDTO.BirthDate);
            pet.Description = editPetDTO.Description;
            pet.Name = editPetDTO.Name;
            pet.Picture = editPetDTO.Picture;
            return pet;
        }
        #endregion
    }
}
