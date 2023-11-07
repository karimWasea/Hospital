using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalservess;

using hospitalUtilities;
using hospitalVm;

using Microsoft.AspNetCore.Authorization;
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

        public PatientReportController(UnitOfWork unitOfWork
     )
        {

            _unitOfWork = unitOfWork; 

        }

        [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]
        public async Task<ActionResult> Index(int? page, string search)
        {

            var pagedPatients = _unitOfWork.PatientReport.Search(page, search);


            return View(pagedPatients);
        }



        [Authorize(policy: $"{WebSiteRoles.WebSite_DoctorAndPatientandsuperadmin}")]


        public ActionResult GetAllPatientReportsbyPatientId(string patientid, string ?search, int? page)
        {
            


            if (patientid != null)
            {
                var pagedPatientss = _unitOfWork.PatientReport.GetAllReportsbyPatientid(patientid, page, search);


                return View(pagedPatientss);

            }








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

            var pagedPatients 
                = _unitOfWork.PatientReport.GetAllReportsbyPatientid(userId, page, search);



            return View(pagedPatients);
        }




        [Authorize(policy: $"{WebSiteRoles.WebSite_DoctorAndPatientandsuperadmin} ")]


        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_unitOfWork.genericRepositorypatientreport.GetById(id));
        }
        [HttpGet]
        [Authorize(policy: $"{WebSiteRoles.WebSite_DoctorAndSuperadmin} ")]

        public IActionResult Save(  int id, int  DoctorAppointmentVIsitid) 
        {

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
        [Authorize(policy: $"{WebSiteRoles.WebSite_DoctorAndSuperadmin} ")]

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


            if (ModelState.IsValid) {


               

                _unitOfWork.genericRepositorypatientreport.Save(HospitalVm);

                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                //return RedirectToAction("Index");




                return View(patientrteort);
            }

            return View(HospitalVm);

        }




























        [Authorize(policy: $"{WebSiteRoles.WebSite_DoctorAndSuperadmin} ")]

        public IActionResult Delete(int id)
        {
            _unitOfWork.genericRepositorypatientreport.Delete(id);


            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Delete";

            return RedirectToAction("Index");
        }








    }
}
