using petApi.Controllers;
using petApi.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Models
{
    public class Appointment
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public Pet Pet { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Doctor { get; set; }
        public string Street { get; set; }
        public string Housenumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        #endregion

        #region Constructors
        public Appointment()
        {

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

        public static AppointmentInListDTO MapAppointmentToAppointmentInListDTO(Appointment appointment)
        {
            if(appointment != null)
            {
                return new AppointmentInListDTO()
                {
                    Id = appointment.Id,
                    Pet = appointment.Pet.Name,
                    Title = appointment.Title,
                    Date =  appointment.DateToText(appointment.Date)
                };
            }
            return null;
        }

        public static AppointmentInfoDTO MapAppointmentToAppointmentInfoDTO(Appointment appointment)
        {
            if(appointment != null)
            {
                return new AppointmentInfoDTO()
                {
                    Id = appointment.Id,
                    Title = appointment.Title,
                    Pet = appointment.Pet.Name,
                    PetPicture = appointment.Pet.Picture,
                    City = appointment.City,
                    Date = appointment.DateToText(appointment.Date),
                    Description = appointment.Description,
                    Doctor = appointment.Doctor,
                    Housenumber = appointment.Housenumber,
                    PostalCode = appointment.PostalCode,
                    Street = appointment.Street
                };
            }
            return null;
        }

        public static AppointmentInListPetInfoDTO MapAppointmentToAppointmentInListPetInfoDTO(Appointment appointment)
        {
            if(appointment != null)
            {
                return new AppointmentInListPetInfoDTO()
                {
                    Id = appointment.Id,
                    Title = appointment.Title
                };
            }
            return null;
        }

        public static Appointment MapAddAppointmentDTOToAppointment(AddAppointmentDTO addedAppointment)
        {
            if(addedAppointment != null)
            {
                return new Appointment()
                {
                    City = addedAppointment.City,
                    Date = addedAppointment.TextToDate(addedAppointment.Date),
                    Description = addedAppointment.Description,
                    Doctor = addedAppointment.Doctor,
                    Housenumber = addedAppointment.Housenumber,
                    PostalCode = addedAppointment.PostalCode,
                    Street = addedAppointment.Street,
                    Title = addedAppointment.Title
                };
            }
            return null;
        }
        #endregion
    }
}
