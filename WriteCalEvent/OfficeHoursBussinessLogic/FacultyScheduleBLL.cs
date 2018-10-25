using OfficeHoursDataAccess;
using OfficeHoursEntities;
using System;
using System.Collections.Generic;
using System.Data;
using Google.Apis.Calendar.v3.Data;

namespace OfficeHoursBussinessLogic
{
    public class FacultyScheduleBLL
    {
        FacultyScheduleDBLogic facultyScheduleDB;
        GoogleCalendarService.GoogleCalendarService calendarService = new GoogleCalendarService.GoogleCalendarService();

        public FacultyScheduleBLL()
        {
            facultyScheduleDB = new FacultyScheduleDBLogic();
        }

        public string CreateFacultySchedule(FacultyScheduleDTO schedule)
        {
            return facultyScheduleDB.CreateFacultySchedule(schedule);
        }

        public List<FacultyScheduleDTO> GetFacultyScheduleByMail(string email)
        {
            return facultyScheduleDB.GetFacultyScheduleByMail(email);
        }

        public List<FacultyScheduleDTO> GetFacultyScheduleByMailandDate(string email, DateTime startDate, DateTime endDate)
        {
            return facultyScheduleDB.GetFacultyScheduleByMailandDate(email, startDate, endDate);
        }

        public DataTable BuildScheduleDataTable(List<FacultyScheduleDTO> facultySchedules)
        {
            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("scheduleId", typeof(long));
            dt.Columns.Add("facultyEmail", typeof(string));
            dt.Columns.Add("scheduleNote", typeof(string));
            dt.Columns.Add("scheduleStart", typeof(DateTime));
            dt.Columns.Add("scheduleEnd", typeof(DateTime));
            dt.Columns.Add("scheduleColor", typeof(string));
            dt.Columns.Add("scheduleGroup", typeof(string));

            foreach (var s in facultySchedules)
            {
                dt.Rows.Add(s.scheduleId,s.facultyEmail,s.scheduleNote,s.scheduleStart,s.scheduleEnd,s.scheduleColor,s.scheduleGroup);
            }
            return dt;
        }

        public DataTable BuildScheduleDataTablePrototype(List<FacultyScheduleDTO> facultySchedules)
        {
            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("day", typeof(string));
            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("time", typeof(string));            

            foreach (var s in facultySchedules)
            {
                dt.Rows.Add(  s.scheduleStart.DayOfWeek, s.scheduleStart.Date, s.scheduleStart.ToString("t") + " - " + s.scheduleEnd.ToString("t") );
            }
            return dt;
        }

        public DataTable BuildDTFromGoogleCalendar()
        {
            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("day", typeof(string));
            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("time", typeof(string));

            var facultySchedules = calendarService.GetGoogleCalendarEvents();

            foreach (var s in facultySchedules.Items)
            {
                dt.Rows.Add(s.Start.DateTime.Value.DayOfWeek, s.Start.DateTime.Value.Date, s.Start.DateTime.Value.ToString("t") + " - " + s.End.DateTime.Value.ToString("t"));
            }
            return dt;
        }
    }
}
