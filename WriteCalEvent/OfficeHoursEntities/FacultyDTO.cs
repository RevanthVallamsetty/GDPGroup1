using System;

namespace OfficeHoursEntities
{
    public class FacultyDTO
    {
        public int memberId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime createDate { get; set; }
        public int accountStatus { get; set; }
        public string authCode { get; set; }
        public string phoneNumber { get; set; }
    }
}
