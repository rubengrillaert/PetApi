using petApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Data.IRepository
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAppointments();
        Appointment GetAppointmentById(int id);
        void AddAppointment(Appointment appointment);
        void DeleteAppointment(int id);
        void SaveChanges();
    }
}
