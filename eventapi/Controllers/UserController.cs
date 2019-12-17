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
    public class UserController : ControllerBase
    {
        #region Properties
        private readonly IUserRepository _userRepository;
        private readonly IPetRepository _petRepository;
        #endregion

        #region Constructors
        public UserController(IUserRepository userRepository, IPetRepository petRepository)
        {
            _userRepository = userRepository;
            _petRepository = petRepository;
        }
        #endregion

        #region Methodes
        [HttpGet("{username}")]
        public ActionResult<UserInfoDTO> GetUserInfo(string username)
        {
            User user = _userRepository.GetByUsername(username);
            if (user != null)
            {
                return Ok(Models.User.MapUserToUserInfoDTO(user));
            }
            return NotFound();
        }

        [HttpGet("pets/{id}")]
        public ActionResult<List<PetInListDTO>> GetUserPets(int id){
            List<Pet> pets = _userRepository.GetPetsByUserId(id);
            return Ok(pets.Select(p => Pet.MapPetToPetInListDTO(p)));
        }

        [HttpGet("appointments/{id}")]
        public ActionResult<List<AppointmentInListDTO>> GetUserAppointments(int id)
        {
            List<Appointment> appointments = _userRepository.GetAppointmentsByUserId(id);
            return Ok(appointments.Select(a => Appointment.MapAppointmentToAppointmentInListDTO(a)));
        }

        [Route("add/pet")]
        [HttpPost]
        public ActionResult AddPetToUser(AddPetDTO addedPet)
        {
            if(addedPet != null)
            {
                User user = _userRepository.GetById(addedPet.UserId);
                if(user != null)
                {
                    Pet pet = Pet.MapAddPetDTOToPet(addedPet);
                    if(pet != null)
                    {
                        user.AddPet(pet);
                        _userRepository.UpdateUser(user);
                        _userRepository.SaveChanges();
                        return Ok();
                    }
                }
            }
            return BadRequest();
        }

        [Route("add/appointment")]
        [HttpPost]
        public IActionResult AddAppointmentToUserPet(AddAppointmentDTO addedAppointment)
        {
            if(addedAppointment != null)
            {
                User user = _userRepository.GetById(addedAppointment.UserId);
                if(user != null)
                {
                    Pet pet = _petRepository.GetPetById(addedAppointment.PetId);
                    if(pet != null)
                    {
                        Appointment appointment = Appointment.MapAddAppointmentDTOToAppointment(addedAppointment);
                        if(appointment != null)
                        {
                            user.AddAppointment(appointment);
                            _userRepository.UpdateUser(user);
                            pet.AddAppointment(appointment);
                            _petRepository.UpdatePet(pet);
                            _userRepository.SaveChanges();
                            return Ok();
                        }
                    }
                }
            }
            return BadRequest();
        }
        #endregion
    }
}