using OfficeHoursDataAccess;
using OfficeHoursEntities;
using System;
using System.Collections.Generic;

namespace OfficeHoursBussinessLogic
{
    public class FacultyBLL
    {
        FacultyDBLogic facultyDB;

        public FacultyBLL()
        {
            facultyDB = new FacultyDBLogic();
        }

        public string CreateFaculty(FacultyDTO user)
        {
            return facultyDB.CreateFaculty(user);
        }

        public List<FacultyDTO> GetFacultyByMail(string email)
        {
            return facultyDB.GetFacultyByMail(email);
        }

        public List<FacultyDTO> GetAllFaculties()
        {
            return facultyDB.GetAllFaculties();
        }

        public FacultyDTO isAuthunticated(string email, string password)
        {
            foreach(var fac in facultyDB.GetFacultyByMail(email))
            {
                if (fac != null && fac.Email.Equals(email) && fac.Password.Equals(password))
                    return fac;
            }

            return null;
        }
    }
}
