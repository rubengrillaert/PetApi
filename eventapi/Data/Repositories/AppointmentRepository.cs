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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly PetContext _dbContext;
        private readonly DbSet<Appointment> _appointments;

        public AppointmentRepository(PetContext petContext)
        {
            _dbContext = petContext;
            _appointments = _dbContext.Appointment;
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public void DeleteAppointment(int id)
        {
            Appointment appointment = _appointments.FirstOrDefault(a => a.Id == id);
            _appointments.Remove(appointment);
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointments.Include(a => a.Pet).FirstOrDefault(a => a.Id == id);
        }

        public List<Appointment> GetAppointments()
        {
            return _appointments.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
