using OfficeHoursEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeHoursDataAccess
{
    public class FacultyScheduleDBLogic
    {
        public string CreateFacultySchedule(FacultyScheduleDTO schedule)
        {
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                officehours_schedule scheduleData = new officehours_schedule()
                {
                   faculty_email = schedule.facultyEmail,
                   schedule_color = schedule.scheduleColor,
                   schedule_note = schedule.scheduleNote,
                   schedule_start = schedule.scheduleStart,
                   schedule_end = schedule.scheduleEnd,
                   schedule_id = schedule.scheduleId,
                   schedule_group = schedule.scheduleGroup
                };

                officeHoursDB.officehours_schedule.Add(scheduleData);
                try
                {
                    officeHoursDB.SaveChanges();
                    return scheduleData.faculty_email;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return e.Message;
                }
            }
        }

        public List<FacultyScheduleDTO> GetFacultyScheduleByMail(string email)
        {
            List<FacultyScheduleDTO> facultySchedules = new List<FacultyScheduleDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var facultyData = from f in officeHoursDB.officehours_schedule
                                  where f.faculty_email == email
                                  select f;

                foreach (officehours_schedule fac in facultyData)
                {
                    if (fac != null)
                    {
                        FacultyScheduleDTO faculty = new FacultyScheduleDTO()
                        {
                            facultyEmail = fac.faculty_email,
                            scheduleColor = fac.schedule_color,
                            scheduleId = fac.schedule_id,
                            scheduleNote = fac.schedule_note,
                            scheduleStart = fac.schedule_start,
                            scheduleEnd = fac.schedule_end,
                            scheduleGroup = fac.schedule_group
                        };

                        facultySchedules.Add(faculty);
                    }
                }
                return facultySchedules;
            }
        }

        public List<FacultyScheduleDTO> GetFacultyScheduleByMailandDate(string email, DateTime startDate, DateTime endDate)
        {
            List<FacultyScheduleDTO> facultySchedules = new List<FacultyScheduleDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var facultyData = from f in officeHoursDB.officehours_schedule
                                  where f.faculty_email == email && (f.schedule_start >= startDate && f.schedule_end <= endDate )
                                  select f;

                foreach (officehours_schedule fac in facultyData)
                {
                    if (fac != null)
                    {
                        FacultyScheduleDTO faculty = new FacultyScheduleDTO()
                        {
                            facultyEmail = fac.faculty_email,
                            scheduleColor = fac.schedule_color,
                            scheduleId = fac.schedule_id,
                            scheduleNote = fac.schedule_note,
                            scheduleStart = fac.schedule_start,
                            scheduleEnd = fac.schedule_end,
                            scheduleGroup = fac.schedule_group
                        };

                        facultySchedules.Add(faculty);
                    }
                }
                return facultySchedules;
            }
        }
    }
}
