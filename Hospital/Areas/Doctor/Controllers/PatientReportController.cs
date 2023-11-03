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


        UnitOfWork _unitOfWork;

        public PatientReportController(UnitOfWork unitOfWork, lookupServess lookupServess, UserManager<ApplicationUser> userManager
     )
        {

            _unitOfWork = unitOfWork;

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

        public    IActionResult Save(  int id, int  DoctorAppointmentVIsitid) //dd88ca62-be8a-483b-822b-02d2daa9b5e0"
        {


            //var claimsIdentity = (ClaimsIdentity)User.Identity;

            //if (!claimsIdentity.IsAuthenticated)
            //{
            //    return Redirect("/Admin/Home/Index");
            //}

            //var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (string.IsNullOrEmpty(userId))
            //{
            //    // Handle the case where the user identifier is not found in claims (optional).
            //    return Redirect("/Admin/Home/Index");
            //}

            //ViewBag.doctorName = _unitOfWork._userManager.Users.FirstOrDefault(i => i.Id == userId).UserName;
            //ViewBag.doctorid = userId;
            //ViewBag.DoctorAppointmentVIsitid = DoctorAppointmentVIsitid;
            //ViewBag.patientid = patientid;
            // var m = _userManager.FindByIdAsync(userId); 
            //ViewBag.patientname =
            //   _unitOfWork. _userManager.Users. Where(i => i.Id == patientid).Select(i=>i.UserName).FirstOrDefault();
            //int numberToPass = DoctorAppointmentVIsitid; // The number you want to pass
            //TempData["Number"] = numberToPass;
            //ViewBag.Appiontmentvisiid = _unitOfWork._context.DoctorAppointmentVIsit.

         var model=   _unitOfWork.Idoctorvist.GetById(DoctorAppointmentVIsitid);
            var patientrteort = new patientreportVm()
            {

                doctorname = model.DoctorName,
                patientName= model.PatientName,
                 DoctorAppointmentVIsitid= model.DoctorAppointmentVIsitid,  
                  
                 patientid= model.patientid,
                 doctorid =model.doctorid,
                  
            
            };

            if (id > 0)

                return View(_unitOfWork.genericRepositorypatientreport.GetById(id));

            else


                return View(patientrteort);


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Save(patientreportVm HospitalVm)
        {
            var model = _unitOfWork.Idoctorvist.GetById(HospitalVm.DoctorAppointmentVIsitid);
            var patientrteort = new patientreportVm()
            {

                doctorname = model.DoctorName,
                patientName = model.PatientName,
                DoctorAppointmentVIsitid = model.DoctorAppointmentVIsitid,

                patientid = model.patientid,
                doctorid = model.doctorid,


            };


            _unitOfWork.genericRepositorypatientreport.Save(HospitalVm);


            return View( "index");



        }





























        public IActionResult Delete(int id)
        {
            _unitOfWork.genericRepositorypatientreport.Delete(id);




            return RedirectToAction("Index");
        }








    }
}
