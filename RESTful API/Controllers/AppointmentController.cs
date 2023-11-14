using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTful_API.Entities;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private DataContext _dataContext;

        // GET: api/<AppointmentController>
        [HttpGet]
        //שליפת רשימה
        public IEnumerable<Appointment> Get()
        {
            return _dataContext.appointmentsList;
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        //שליפת אוביקט בודד לפי מזהה
        public ActionResult<Appointment> Get(int id)
        {
            var appointment = _dataContext.appointmentsList.Find(x => x.Id == id);
            if (appointment == null)
                return NotFound();
            return appointment;
            //return Ok(appointment);
        }

        // GET api/<AppointmentController>/2023,11,07
        [HttpGet("{date}")]
        //שליפת אוביקטים לפי תאריך
        public ActionResult<List<Appointment>> Get(DateOnly date)
        {
            List<Appointment> temp = new List<Appointment>();
            temp = _dataContext.appointmentsList.FindAll(x => x.Date == date);
            if (temp == null)
                return NotFound();
            return temp;
        }

        // POST api/<AppointmentController>
        [HttpPost]
        //הוספה
        public void Post([FromBody] Appointment appointment)
        {
            _dataContext.appointmentsList.Add(new Appointment { Id = appointment.Id, Subject = appointment.Subject, Date = appointment.Date });
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        //עדכון
        public void Put(int id, [FromBody] Appointment updateAppointment)
        {
            //id - מציאת אוביקט עפי ה
            var a = _dataContext.appointmentsList.Find(x => x.Id == id);

            //עדכון המשתנים
            //a.Id=updateAppointment.Id;
            a.Subject = updateAppointment.Subject;
            a.Date = updateAppointment.Date;
        }
        

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        //מחיקה
        public void Delete(int id)
        {
            var a= _dataContext.appointmentsList.Find(x => x.Id == id);
            _dataContext.appointmentsList.Remove(a);
        }
    }
}