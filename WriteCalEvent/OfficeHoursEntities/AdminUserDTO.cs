using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeHoursEntities
{
    public class AdminUserDTO
    {
        public int AdminUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
