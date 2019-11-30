using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Models
{
    public class Appointment
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public Pet Pet { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Doctor { get; set; }
        public string Street { get; set; }
        public string Housenumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        #endregion

        #region Constructors
        public Appointment()
        {

        }
        #endregion
    }
}
