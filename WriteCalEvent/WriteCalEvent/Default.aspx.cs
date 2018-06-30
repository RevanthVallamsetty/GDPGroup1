using Google.Apis.Calendar.v3.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using GoogleCalendarService;

namespace WriteCalEvent
{
    public partial class _Default : Page
    {
        GoogleCalendarService.GoogleCalendarService calendarService = new GoogleCalendarService.GoogleCalendarService();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void createEvent_Click(object sender, EventArgs e)
        {
            var sTime = Convert.ToDateTime(starttimepickerTB.Text);
            string startTime = sTime.ToString("HH:mm:ss", CultureInfo.CurrentCulture);
            var eTime = Convert.ToDateTime(endTimepickerTB.Text);
            string endTime = eTime.ToString("HH:mm:ss", CultureInfo.CurrentCulture);
            DateTime startDate = DateTime.Parse(startdatepickerTB.Text);
            DateTime endDate = DateTime.Parse(enddatepickerTB.Text);
            DateTime startDateTime = Convert.ToDateTime(startdatepickerTB.Text + " " + startTime);
            //DateTime.ParseExact(startdatepickerTB.Text + " " + startTime, "dd/MM/yy HH:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime endDateTime = Convert.ToDateTime(enddatepickerTB.Text + " " + endTime);
            //DateTime.ParseExact(enddatepickerTB.Text + " " + endTime, "dd/MM/yy HH:mm:ss tt", CultureInfo.InvariantCulture);

            var client = new RestClient("https://maps.googleapis.com");
            var request = new RestRequest("maps/api/timezone/json", Method.GET);
            request.AddParameter("location", "40.351437, -94.883272");
            request.AddParameter("timestamp", ToTimestamp(DateTime.UtcNow));
            request.AddParameter("sensor", "false");
            var response = client.Execute<GoogleTimeZone>(request);

            Event newEvent = new Event()
            {
                Summary = txtAppointmentName.Text,
                Location = txtLocation.Text,
                Description = txtAppointmentDescription.Text,
                Start = new EventDateTime()
                {
                    DateTime = startDateTime,
                    TimeZone = response.Data.timeZoneId,
                },
                End = new EventDateTime()
                {
                    DateTime = endDateTime,
                    TimeZone = response.Data.timeZoneId,
                },
                Recurrence = new String[] { "RRULE:FREQ=DAILY;COUNT=1" },
                Attendees = GetEventAttendees(),
                Reminders = new Event.RemindersData()
                {
                    UseDefault = true,
                    //Overrides = new EventReminder[] {
                    //    new EventReminder() { Method = "email", Minutes = 24 * 60 },
                    //    new EventReminder() { Method = "sms", Minutes = 10 },
                    //}
                }
            };

            lnkEventLink.Text = calendarService.CreateGoogleCalendarEvent(newEvent);

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Write(Request.RawUrl.ToString());
        }

        public EventAttendee[] GetEventAttendees()
        {
            var attendeesArray = new List<EventAttendee>();

            foreach (var attendee in txtAttendee.Text.Split(';'))
            {
                var eventAttendee = new EventAttendee() { Email = attendee };
                attendeesArray.Add(eventAttendee);
            }

            return attendeesArray.ToArray();
        }

        public double ToTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}