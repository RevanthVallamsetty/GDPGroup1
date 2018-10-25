using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeHoursEntities
{
    public class StudentMessageDTO
    {
        public string facultyMail { get; set; }
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string message { get; set; }
        public DateTime DateCreated { get; set; }
        public int isArchived { get; set; }
        public long messageId { get; set; }
    }
}
