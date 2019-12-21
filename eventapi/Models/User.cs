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
        public string Surename { get; set; }
        public string Familyname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
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
                Email = usr.Email,
                Surename = usr.Surename,
                Familyname = usr.Familyname,
                Username = usr.Username
            };
        }
        #endregion
    }
}
