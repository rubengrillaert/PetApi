using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petApi.Data.IRepository;
using petApi.DTO_s;
using petApi.Models;

namespace petApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        #region Properties
        private readonly IAppointmentRepository _appointmentRepository;
        #endregion

        #region Constructors
        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Methodes
        [HttpGet("{id}")]
        public ActionResult<AppointmentInfoDTO> GetAppointmentInfo(int id)
        {
            Appointment appointment = _appointmentRepository.GetAppointmentById(id);
            if(appointment != null)
            {
                return Ok(Appointment.MapAppointmentToAppointmentInfoDTO(appointment));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment(int id)
        {
            Appointment appointment = _appointmentRepository.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            try
            {
                _appointmentRepository.DeleteAppointment(id);
                _appointmentRepository.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }
        #endregion
    }
}