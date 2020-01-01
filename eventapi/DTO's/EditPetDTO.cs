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
        public string BirthDate { get; set; }
        public string Description { get; set; }

        public DateTime TextToDate(string textDate)
        {
            int year = Int16.Parse(textDate.Substring(0, 4));
            int month = Int16.Parse(textDate.Substring(5, 2));
            int day = Int16.Parse(textDate.Substring(8, 2));
            int houres = Int16.Parse(textDate.Substring(11, 2));
            int minutes = Int16.Parse(textDate.Substring(14, 2));
            return new DateTime(year, month, day, houres, minutes, 0);
        }

        public string DateToText(DateTime date)
        {
            return "" + date.Year + "-" + date.Month + "-" + date.Day + "-" + date.Hour + "-" + date.Minute;
        }
    }
}
