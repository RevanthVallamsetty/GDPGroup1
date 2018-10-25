using System;

namespace OfficeHoursEntities
{
    public class FacultyScheduleDTO
    {
        public long scheduleId { get; set; }
        public string facultyEmail { get; set; }
        public string scheduleNote { get; set; }
        public DateTime scheduleStart { get; set; }
        public DateTime scheduleEnd { get; set; }
        public string scheduleColor { get; set; }
        public string scheduleGroup { get; set; }
    }
}
