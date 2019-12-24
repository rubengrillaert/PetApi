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
    public class PetController : ControllerBase
    {
        #region Properties
        private readonly IPetRepository _petRepository;
        #endregion

        #region Constructors
        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        #endregion

        #region Methodes
        [HttpGet("{id}")]
        public ActionResult<PetInfoDTO> GetPetInfo(int id)
        {
            Pet pet = _petRepository.GetPetById(id);
            if(pet != null)
            {
                return Ok(Pet.MapPetToPetInfoDTO(pet));
            }
            return BadRequest();
        }

        [HttpGet("pet/appointments/{id}")]
        public ActionResult<List<AppointmentInListDTO>> GetAppointmentsOfPet(int id)
        {
            Pet pet = _petRepository.GetPetById(id);
            if(pet != null)
            {
                return Ok(pet.Appointments.Select(a => Appointment.MapAppointmentToAppointmentInListDTO(a)));
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult EditPet(EditPetDTO editPetDTO)
        {
            Pet pet = _petRepository.GetPetById(editPetDTO.PetId);
            if(pet == null)
            {
                return BadRequest();
            }
            try
            {
                Pet updatedPet = Pet.MapEditPetDTOToPet(editPetDTO, pet);
                _petRepository.UpdatePet(updatedPet);
                _petRepository.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            Pet pet = _petRepository.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }
            try
            {
                _petRepository.DeletePet(id);
                _petRepository.SaveChanges();
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