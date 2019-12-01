using petApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.DTO_s
{
    public class AppointmentInListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Pet { get; set; }
    }
}
