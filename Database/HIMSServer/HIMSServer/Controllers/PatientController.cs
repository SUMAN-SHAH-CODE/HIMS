using PatientLibrary;
using Microsoft.AspNetCore.Mvc;

namespace HIMSServer.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult DisplayTOAddPatientUI()//load the ui  ahrf addpatient click garda 
        {
            return View("AddPatient");//show hunxa addpatient.cshtml show hunxa with input field
        }
        public IActionResult AddPatient(Patient Obj )//button click   ; button click garda  Patient/AddPatient(Patient model class take garxa)
        {
            return View("DisplayPatient",Obj);//display DisplayAddPatient=>AddPatient 
        }
    }
}
