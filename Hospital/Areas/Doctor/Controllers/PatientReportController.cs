using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalservess;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Claims;
using System.Text.Json;
using System.Xml.Linq;

using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace Hospital.Areas.Doctor.Controllers
{
    [Area("Doctor")]

    public class PatientReportController : Controller
    {

        UserManager<ApplicationUser> _userManager;
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public PatientReportController(UnitOfWork unitOfWork, lookupServess lookupServess, UserManager<ApplicationUser> userManager
     )
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        //  GET: HomeController
        public ActionResult Index()
        {
            return View(_unitOfWork.genericRepositorypatientreport.GetAll());
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_unitOfWork.genericRepositorypatientreport.GetById(id));
        }
        [HttpGet]

        public    IActionResult Save( string patientid, int id, int  DoctorAppointmentVIsitid) //dd88ca62-be8a-483b-822b-02d2daa9b5e0"
        {
       //     string?  myObject = JsonSerializer.Deserialize<string>(patientid);
       // var pd=patientid.Trim();
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            if (!claimsIdentity.IsAuthenticated)
            {
                return Redirect("/Admin/Home/Index");
            }
        
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                // Handle the case where the user identifier is not found in claims (optional).
                return Redirect("/Admin/Home/Index");
            }
           
            ViewBag.doctorName = _userManager.Users.FirstOrDefault(i => i.Id == userId).UserName;
            ViewBag.doctorid = userId;
            ViewBag.DoctorAppointmentVIsitid = DoctorAppointmentVIsitid;
            ViewBag.patientid = patientid;
           // var m = _userManager.FindByIdAsync(userId); 
            ViewBag.patientname = 
                _userManager.Users. Where(i => i.Id == patientid).Select(i=>i.UserName).FirstOrDefault();
            int numberToPass = DoctorAppointmentVIsitid; // The number you want to pass
            TempData["Number"] = numberToPass;
            //ViewBag.Appiontmentvisiid = _unitOfWork._context.DoctorAppointmentVIsit.


            if (id > 0)

                return View(_unitOfWork.genericRepositorypatientreport.GetById(id));

            else


                return View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Save(patientreportVm HospitalVm)
        {
            if (TempData.ContainsKey("Number") && TempData["Number"] is int number)
            {
                ViewBag.DoctorAppointmentVIsitid = number;
            }

                _unitOfWork.genericRepositorypatientreport.Save(HospitalVm);


            return View();



        }





























        public IActionResult Delete(int id)
        {
            _unitOfWork.genericRepositorypatientreport.Delete(id);




            return RedirectToAction("Index");
        }








    }
}
