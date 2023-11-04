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

        public PatientReportController(UnitOfWork unitOfWork
     )
        {

            _unitOfWork = unitOfWork;

        }

        //  GET: HomeController
        public async Task<ActionResult> Index(int? page, string search)
        {

            var pagedPatients = _unitOfWork.PatientReport.Search(page, search);


            return View(pagedPatients);
        }





        public ActionResult GetAllPatientReportsbyPatientId(string patientid, string search, int? page)
        {
            var searchTermLower = search?.ToLower();
            int pageNumber = page ?? 1;

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






        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_unitOfWork.genericRepositorypatientreport.GetById(id));
        }
        [HttpGet]

        public    IActionResult Save(  int id, int  DoctorAppointmentVIsitid) 
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


            return RedirectToAction( "Index" );



        }





























        public IActionResult Delete(int id)
        {
            _unitOfWork.genericRepositorypatientreport.Delete(id);




            return RedirectToAction("Index");
        }








    }
}
