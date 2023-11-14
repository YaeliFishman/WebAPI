using Microsoft.Extensions.Logging;
using RESTful_API.Entities;

namespace RESTful_API
{
    public class DataContext
    {
        public List<Appointment> appointmentsList { get; set; } 
        public List<Baby> babyList { get; set; }
        public List<Nurse> nurseList { get; set; }




        public DataContext()
        {
            appointmentsList = new List<Appointment>();
            babyList = new List<Baby> { };
            nurseList = new List<Nurse> { };

            //EventList.Add(new Event { Id = 1, Title = "default" });
        }
    }
}
