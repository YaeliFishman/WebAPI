﻿using Microsoft.AspNetCore.Mvc;
using RESTful_API.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private DataContext _dataContext;

        public NurseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        // GET: api/<NurseController>
        [HttpGet]
        public IEnumerable<Nurse> Get()
        {
            return _dataContext.nurseList;
        }

        // GET api/<NurseController>/5
        [HttpGet("{id}")]
        public ActionResult<Nurse> Get(int id)
        {
            var nurse = _dataContext.nurseList.Find(x => x.Id == id);
            if (nurse == null)
                return NotFound();
            return nurse;
            //return Ok(nurse);
        }

        // POST api/<NurseController>
        [HttpPost]
        public void Post([FromBody] Nurse nurse)
        {
            _dataContext.nurseList.Add(new Nurse { Id = nurse.Id, Name = nurse.Name, Price = nurse.Price , CountHours = nurse.CountHours });
        }

        // PUT api/<NurseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Nurse updateNurse)
        {
            var n = _dataContext.nurseList.Find(x => x.Id == id);
            n.Id = updateNurse.Id;
            n.Name = updateNurse.Name;
            n.CountHours = updateNurse.CountHours;
            n.Price = updateNurse.Price;
        }

        // DELETE api/<NurseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var n = _dataContext.nurseList.Find(x => x.Id == id);
            _dataContext.nurseList.Remove(n);
        }
    }
}
