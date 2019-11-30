using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.Models
{
    public class Pet
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        #endregion

        #region Collections
        public ICollection<Appointment> Appointments { get; set; }
        #endregion

        #region Constructors
        public Pet()
        {
            Appointments = new List<Appointment>();
        }
        #endregion
    }
}
