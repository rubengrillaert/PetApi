using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return NotFound();
        }
        #endregion
    }
}