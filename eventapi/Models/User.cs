using petApi.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Models
{
    public class User
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Housenumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        #endregion

        #region Collections
        public ICollection<Pet> Pets { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        #endregion

        #region Constructors
        public User()
        {
            Pets = new List<Pet>();
            Appointments = new List<Appointment>();
        }
        #endregion

        #region Methodes
        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public static UserInfoDTO MapUserToUserInfoDTO(User usr)
        {
            return new UserInfoDTO()
            {
                Id = usr.Id,
                City = usr.City,
                Country = usr.Country,
                Email = usr.Email,
                Housenumber = usr.Housenumber,
                Name = usr.Name,
                PostalCode = usr.PostalCode,
                Street = usr.Street,
                Username = usr.Username
            };
        }
        #endregion
    }
}
