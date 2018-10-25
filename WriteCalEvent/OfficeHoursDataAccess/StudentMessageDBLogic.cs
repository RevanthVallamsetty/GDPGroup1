using OfficeHoursEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeHoursDataAccess
{
    public class StudentMessageDBLogic
    {
        public string CreateStudentMessage(StudentMessageDTO studentMessage)
        {
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                officehours_messages messageData = new officehours_messages()
                {
                    faculty_mail = studentMessage.facultyMail,
                    Date_Created = DateTime.Now,
                    is_archived = studentMessage.isArchived,
                    message = studentMessage.message,
                    student_id = studentMessage.studentId,
                    student_Name = studentMessage.studentName,
                    message_id = studentMessage.messageId
                };

                officeHoursDB.officehours_messages.Add(messageData);
                try
                {
                    officeHoursDB.SaveChanges();
                    return messageData.faculty_mail;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return e.Message;
                }
            }
        }

        public List<StudentMessageDTO> GetStudentMessagesByFaculty(string email)
        {
            List<StudentMessageDTO> studentMessages = new List<StudentMessageDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var adminUserData = from f in officeHoursDB.officehours_messages
                                    where f.faculty_mail == email
                                    select f;

                foreach (officehours_messages usr in adminUserData)
                {
                    if (usr != null)
                    {
                        StudentMessageDTO studentMessage = new StudentMessageDTO()
                        {
                            studentName = usr.student_Name,
                            studentId = usr.student_id,
                            DateCreated = (DateTime)usr.Date_Created,
                            facultyMail = usr.faculty_mail,
                            isArchived = Convert.ToInt32(usr.is_archived),
                            message = usr.message,
                            messageId = usr.message_id
                        };

                        studentMessages.Add(studentMessage);
                    }
                }
                return studentMessages;
            }
        }

        public List<StudentMessageDTO> GetStudentMessagesById(int id)
        {
            List<StudentMessageDTO> studentMessages = new List<StudentMessageDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var adminUserData = from f in officeHoursDB.officehours_messages
                                    where f.message_id == id
                                    select f;

                foreach (officehours_messages usr in adminUserData)
                {
                    if (usr != null)
                    {
                        StudentMessageDTO studentMessage = new StudentMessageDTO()
                        {
                            studentName = usr.student_Name,
                            studentId = usr.student_id,
                            DateCreated = (DateTime)usr.Date_Created,
                            facultyMail = usr.faculty_mail,
                            isArchived = Convert.ToInt32(usr.is_archived),
                            message = usr.message,
                            messageId = usr.message_id
                        };

                        studentMessages.Add(studentMessage);
                    }
                }
                return studentMessages;
            }
        }

        public List<StudentMessageDTO> GetStudentMessagesByFaculty(string email, string studentId)
        {
            List<StudentMessageDTO> studentMessages = new List<StudentMessageDTO>();
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var adminUserData = from f in officeHoursDB.officehours_messages
                                    where f.faculty_mail == email && f.student_id == studentId
                                    select f;

                foreach (officehours_messages usr in adminUserData)
                {
                    if (usr != null)
                    {
                        StudentMessageDTO studentMessage = new StudentMessageDTO()
                        {
                            studentName = usr.student_Name,
                            studentId = usr.student_id,
                            DateCreated = (DateTime)usr.Date_Created,
                            facultyMail = usr.faculty_mail,
                            isArchived = Convert.ToInt32(usr.is_archived),
                            message = usr.message,
                            messageId = usr.message_id
                        };

                        studentMessages.Add(studentMessage);
                    }
                }
                return studentMessages;
            }
        }

        public int DeleteMessageById(int id)
        {
            using (officehoursEntities officeHoursDB = new officehoursEntities())
            {
                var deleteMessage = from f in officeHoursDB.officehours_messages where f.message_id == id select f;

                foreach (var item in deleteMessage)
                {
                    officeHoursDB.officehours_messages.Remove(item);
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
