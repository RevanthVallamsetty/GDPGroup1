using OfficeHoursDataAccess;
using OfficeHoursEntities;
using System;
using System.Collections.Generic;
using System.Data;

namespace OfficeHoursBussinessLogic
{
    public class StudentMessageBLL
    {
        StudentMessageDBLogic studentMessageDB;

        public StudentMessageBLL()
        {
            studentMessageDB = new StudentMessageDBLogic();
        }

        public string CreateStudentMessage(StudentMessageDTO studentMessage)
        {
            return studentMessageDB.CreateStudentMessage(studentMessage);
        }

        public List<StudentMessageDTO> GetStudentMessagesByFaculty(string email)
        {
            return studentMessageDB.GetStudentMessagesByFaculty(email);
        }

        public List<StudentMessageDTO> GetStudentMessagesByFaculty(string email, string studentId)
        {
            return studentMessageDB.GetStudentMessagesByFaculty(email,studentId);
        }

        public List<StudentMessageDTO> GetStudentMessagesById(int id)
        {
            return studentMessageDB.GetStudentMessagesById(id);
        }

        public int DeleteMessageById(int id)
        {
            return studentMessageDB.DeleteMessageById(id);
        }

        public DataTable BuildMessageDataTable(List<StudentMessageDTO> studentMessages)
        {
            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("messageId", typeof(long));
            dt.Columns.Add("facultyEmail", typeof(string));
            dt.Columns.Add("studentId", typeof(string));
            dt.Columns.Add("studentName", typeof(string));
            dt.Columns.Add("message", typeof(string));
            dt.Columns.Add("dateCreated", typeof(DateTime));
            dt.Columns.Add("isArchived", typeof(string));

            foreach (var s in studentMessages)
            {
                dt.Rows.Add(s.messageId, s.facultyMail, s.studentId, s.studentName, s.message, s.DateCreated, s.isArchived);
            }
            return dt;
        }

    }
}
