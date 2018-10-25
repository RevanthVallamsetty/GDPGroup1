using OfficeHoursEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeHoursDataAccess
{
    public class FacultyDBLogic
    {
        public string CreateFaculty(FacultyDTO user)
        {
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                officehours_faculty facultyData = new officehours_faculty()
                {
                    member_id = user.memberId,
                    first_Name = user.firstName,
                    last_Name = user.lastName,
                    Email = user.Email,
                    Password = user.Password,
                    account_status = user.accountStatus,
                    auth_code = user.authCode,
                    create_date = DateTime.Now,
                    phone_number = user.phoneNumber
                };

                officeHoursDB.officehours_faculty.Add(facultyData);
                try
                {
                    officeHoursDB.SaveChanges();
                    return facultyData.Email;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return e.Message;
                }
            }
        }

        public bool UpdateFaculty(FacultyDTO user)
        {
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var facultyData = (from f in officeHoursDB.officehours_faculty
                                 where f.member_id == user.memberId
                                 select f).FirstOrDefault();


                facultyData.member_id = user.memberId;
                facultyData.first_Name = user.firstName;
                facultyData.last_Name = user.lastName;
                facultyData.Email = user.Email;
                facultyData.Password = user.Password;
                facultyData.account_status = user.accountStatus;
                facultyData.auth_code = user.authCode;
                facultyData.create_date = DateTime.Now;
                facultyData.phone_number = user.phoneNumber;

                officeHoursDB.Entry(facultyData).State = EntityState.Modified;
                try
                {
                    officeHoursDB.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<FacultyDTO> GetFacultyByMail(string email)
        {
            List<FacultyDTO> faculties = new List<FacultyDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var facultyData = from f in officeHoursDB.officehours_faculty
                                                  where f.Email == email
                                                  select f;

                

                foreach (officehours_faculty fac in facultyData)
                {
                    if (fac != null)
                    {
                        FacultyDTO faculty = new FacultyDTO() {
                            memberId = fac.member_id,
                            Email = fac.Email,
                            accountStatus = Convert.ToInt32(fac.account_status),
                            authCode = fac.auth_code,
                            createDate = (DateTime)fac.create_date,
                            firstName = fac.first_Name,
                            lastName = fac.last_Name,
                            Password = fac.Password,
                            phoneNumber = fac.phone_number
                        };

                        faculties.Add(faculty);
                    }
                }
                return faculties;
            }
        }

        public List<FacultyDTO> GetAllFaculties()
        {
            List<FacultyDTO> faculties = new List<FacultyDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var facultyData = from f in officeHoursDB.officehours_faculty select f;

                foreach (officehours_faculty fac in facultyData)
                {
                    if (fac != null)
                    {
                        FacultyDTO faculty = new FacultyDTO()
                        {
                            memberId = fac.member_id,
                            Email = fac.Email,
                            accountStatus = Convert.ToInt32(fac.account_status),
                            authCode = fac.auth_code,
                            createDate = (DateTime)fac.create_date,
                            firstName = fac.first_Name,
                            lastName = fac.last_Name,
                            Password = fac.Password,
                            phoneNumber = fac.phone_number
                        };

                        faculties.Add(faculty);
                    }
                }
                return faculties;
            }
        }

        public int DeleteFacultyById(int id)
        {
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var deleteFaculty = from f in officeHoursDB.officehours_faculty where f.member_id == id select f;

                foreach (var item in deleteFaculty)
                {
                    officeHoursDB.officehours_faculty.Remove(item);
                }
                try
                {
                    officeHoursDB.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        public int DeleteFacultyByMail(string email)
        {
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var deleteFaculty = from f in officeHoursDB.officehours_faculty where f.Email == email select f;

                foreach (var item in deleteFaculty)
                {
                    officeHoursDB.officehours_faculty.Remove(item);
                }
                try
                {
                    officeHoursDB.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }
}
