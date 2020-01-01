using petApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.DTO_s
{
    public class AppointmentInfoDTO
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Pet { get; set; }
        public string PetPicture { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Doctor { get; set; }
        public string Street { get; set; }
        public string Housenumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        #endregion
    }
}
