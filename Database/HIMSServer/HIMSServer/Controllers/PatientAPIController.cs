//using HIMSServer.Models;
using PatientLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatient;
using NuGet.Protocol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HIMSServer.Controllers
{
    //enables all call use the cors of program.cs
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        //we inject patientDbcontext from program.cs
        //we can assign a private field and use dbContext 
        private readonly PatientDbContext dbContext;

        public PatientAPIController(PatientDbContext DbContext)//(datatype  name)
        {
            dbContext = DbContext;
        }

        // GET: api/<PatientAPIController>
        [HttpGet]
        public IActionResult GetAllPatient()
        {
            return Ok(dbContext.Patients.ToList());
        }

        // GET api/<PatientAPIController>/5
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
           var p= dbContext.Patients.Find(id);
            if(p is null)
            {
               return NotFound();
            }
            return Ok(p);
        }

        // POST api/<PatientAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Patient value)//(PatientModel nameoranything)
        {
            if (value.age>100)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"You cannot enter age more than 100");
            }
            value.name=value.name.ToUpper();
            //PatientDbContext p = new PatientDbContext();
            //p.Patients.Add(value);//in memory
          //  p.SaveChanges();//in physical commit
          dbContext.Patients.Add(value);
          dbContext.SaveChanges();
            return Ok(value);
        }

        // PUT api/<PatientAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Patient value)
        {
            var p = dbContext.Patients.Find(id);
            if(p is null)
            {
                return NotFound();
            }
            p.name = value.name;
            p.code=value.code;
            p.age=value.age;
           
            dbContext.SaveChanges();
            return Ok(p);
        }

        // DELETE api/<PatientAPIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var p=dbContext.Patients.Find(id);
            if(p is null)
            {
                return NotFound();
            }
            dbContext.Patients.Remove(p);
            dbContext.SaveChanges();
            return Ok($"id : \"{id}\" is deleted");
        }
    }
}
