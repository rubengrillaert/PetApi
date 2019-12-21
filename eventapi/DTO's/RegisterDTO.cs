using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eventapi.DTO_s
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        public string Surename { get; set; }
        [Required]
        public string Familyname { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
