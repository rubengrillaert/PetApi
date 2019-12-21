using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petApi.DTO_s
{
    public class UserInfoDTO
    {
        #region Properties
        public int Id { get; set; }
        public string Surename { get; set; }
        public string Familyname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        #endregion
    }
}
