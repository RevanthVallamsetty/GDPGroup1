using OfficeHoursDataAccess;
using OfficeHoursEntities;
using System.Collections.Generic;

namespace OfficeHoursBussinessLogic
{
    public class AdminBLL
    {
        AdminDBLogic adminDB;

        public AdminBLL()
        {
            adminDB = new AdminDBLogic();
        }

        public int CreateFaculty(AdminUserDTO user)
        {
            return adminDB.CreateAdmin(user);
        }

        public List<AdminUserDTO> GetAdminUserById(int id)
        {
            return adminDB.GetAdminUserById(id);
        }

        public List<AdminUserDTO> GetAllAdminUsers()
        {
            return adminDB.GetAllAdminUsers();
        }
    }
}
