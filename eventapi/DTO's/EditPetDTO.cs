using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.DTO_s
{
    public class EditPetDTO
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
    }
}
