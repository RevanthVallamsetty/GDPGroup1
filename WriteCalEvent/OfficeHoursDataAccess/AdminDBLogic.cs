using OfficeHoursEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeHoursDataAccess
{
    public class AdminDBLogic
    {
        public int CreateAdmin(AdminUserDTO user)
        {
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                officehours_Admin_Users userData = new officehours_Admin_Users()
                {
                    Admin_User_Id = user.AdminUserId,
                    Date_Created = DateTime.Now,
                    Password = user.Password,
                    User_Name = user.UserName                    
                };

                officeHoursDB.officehours_Admin_Users.Add(userData);
                try
                {
                    officeHoursDB.SaveChanges();
                    return userData.Admin_User_Id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        public List<AdminUserDTO> GetAdminUserById(int id)
        {
            List<AdminUserDTO> adminUsers = new List<AdminUserDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var adminUserData = from f in officeHoursDB.officehours_Admin_Users
                                  where f.Admin_User_Id == id
                                  select f;

                foreach (officehours_Admin_Users usr in adminUserData)
                {
                    if (usr != null)
                    {
                        AdminUserDTO faculty = new AdminUserDTO()
                        {
                            AdminUserId = usr.Admin_User_Id,
                            UserName = usr.User_Name,
                            Password = usr.Password,
                            DateCreated = (DateTime)usr.Date_Created
                        };

                        adminUsers.Add(faculty);
                    }
                }
                return adminUsers;
            }
        }

        public List<AdminUserDTO> GetAllAdminUsers()
        {
            List<AdminUserDTO> adminUsers = new List<AdminUserDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var adminUserData = from f in officeHoursDB.officehours_Admin_Users
                                    select f;

                foreach (officehours_Admin_Users usr in adminUserData)
                {
                    if (usr != null)
                    {
                        AdminUserDTO faculty = new AdminUserDTO()
                        {
                            AdminUserId = usr.Admin_User_Id,
                            UserName = usr.User_Name,
                            Password = usr.Password,
                            DateCreated = (DateTime)usr.Date_Created
                        };

                        adminUsers.Add(faculty);
                    }
                }
                return adminUsers;
            }
        }
    }
}
