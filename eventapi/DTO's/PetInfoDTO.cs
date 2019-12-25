using petApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.DTO_s
{
    public class PetInfoDTO
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public IEnumerable<AppointmentInListDTO> Appointments { get; set; }
        #endregion
    }
}
