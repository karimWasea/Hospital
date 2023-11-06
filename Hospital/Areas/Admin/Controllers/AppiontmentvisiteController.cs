using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalservess;

using hospitalUtilities;
using hospitalUtilities.SystemEnums;

using hospitalVm;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PagedList;

using System.Drawing.Printing;
using System.Linq;
using System.Security.Claims;

namespace Hospital.Areas.Admin.Controllers
{
    //<partial name = "_AlertMessage" />
     
    [Area("Admin")]
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}") ]
    public class AppiontmentvisiteController : Controller
    {


        lookupServess _lookupServess;
        UnitOfWork _unitOfWork;
        public AppiontmentvisiteController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _lookupServess=lookupServess;
            _unitOfWork = unitOfWork;
        }
        public async Task<ActionResult> Index(int? page, string search)
        {

            var pagedPatients =   _unitOfWork.Idoctorvist.GetAllVaisits(page, search);


            return View(pagedPatients);
        }

       







     
        public ActionResult Details(int DoctorAppointmentVIsitid)
        {
            return View(_unitOfWork.Idoctorvist.GetById(  DoctorAppointmentVIsitid));
        }




        [Authorize(Roles = WebSiteRoles.WebSite_patient )]
        [Authorize(Roles = WebSiteRoles.WebSite_Doctor )]


        public ActionResult GetAllVistitsbyPatientid(string id, string search, int? page)
        {
            var searchTermLower = search?.ToLower();
            int pageNumber = page ?? 1;

            if (id != null)
            {
                var pagedPatientss = _unitOfWork.Idoctorvist.GetAllVistitsbyPatientid(id, page, search);


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

            var pagedPatients = _unitOfWork.Idoctorvist.GetAllVistitsbyPatientid(userId, pageNumber, searchTermLower);


            return View(pagedPatients);
        }






        [Authorize(Roles = $"{WebSiteRoles.WebSite_Doctor}")]


        public ActionResult GettAllVistitsByDoctorid(string id, string ? search, int? page)
        
        
        {
            int pageNumber = page ?? 1;



            if (id != null)
            {
                var pagedPatients2 = _unitOfWork.Idoctorvist.GettAllVistitsByDoctorid(id, pageNumber, search);



                return View(pagedPatients2);


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

            var model = _unitOfWork.Idoctorvist.GettAllVistitsByDoctorid(userId, pageNumber, search   );





          

            return View(model);
        }





        public IActionResult Save(int  DoctorAppointmentVIsitid)
        {

            ViewBag.Visitetype = _lookupServess.Visitetype();
          ViewBag. viststuts=_lookupServess.viststuts();
            ViewBag.doctordam=_lookupServess.getdoctorfromapplicationuserid();
            ViewBag.allpatient = _lookupServess.allpatient();
            ViewBag.AvailableSlots =
                _lookupServess.AvailableAppointments(_unitOfWork.Idoctorvist.GetById(DoctorAppointmentVIsitid).doctorid);

            if (DoctorAppointmentVIsitid > 0)

                return View(_unitOfWork.Idoctorvist.GetById(DoctorAppointmentVIsitid));

            else


                return View();


        }


        [HttpPost]

        public IActionResult Save(ApointmentVm HospitalVm)
        {

            ViewBag.Visitetype = _lookupServess.Visitetype();
            ViewBag.viststuts = _lookupServess.viststuts();
            ViewBag.doctordam = _lookupServess.getdoctorfromapplicationuserid();
            ViewBag.allpatient = _lookupServess.allpatient();
            ViewBag.AvailableSlots =
                _lookupServess.AvailableAppointments(HospitalVm.doctorid);
            _unitOfWork.Idoctorvist.Save(HospitalVm);

            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";
            return RedirectToAction("Index");
            


        }


        [HttpPost]

        public IActionResult AddDoctorNoteForVisit(ApointmentVm HospitalVm)
        {
           var model= _unitOfWork.Idoctorvist.GetById(HospitalVm.DoctorAppointmentVIsitid);
            HospitalVm.CreateDate = model.CreateDate;
            HospitalVm.discreaption = model.discreaption;
            HospitalVm.id = model.id;
            HospitalVm.VisitStatus = VisitStatus.InProgress;

            _unitOfWork.Idoctorvist.Save(HospitalVm);
            TempData["Message"] = $" Note created successfully!";
            TempData["MessageType"] = "Save";

            return View(_unitOfWork.Idoctorvist.GetById(HospitalVm.DoctorAppointmentVIsitid));



        }



        public IActionResult AddDoctorNoteForVisit(int DoctorAppointmentVIsitid)
        {
            return View(_unitOfWork.Idoctorvist.GetById(DoctorAppointmentVIsitid));
        }


        




            public IActionResult ArrivedVisit(int DoctorAppointmentVIsitid)
        {
            var appvm = new ApointmentVm();
             var getbyid= _unitOfWork. Idoctorvist.GetById(DoctorAppointmentVIsitid);

            appvm.DoctorAppointmentVIsitid = DoctorAppointmentVIsitid;
            appvm.patientid = getbyid.patientid;
            appvm.doctorid = getbyid.doctorid;
            appvm.VisitType = getbyid.VisitType;
            //appvm.VisitType = getbyid.VisitType;
            //_unitOfWork._context.DoctorAppointmentVIsit.Find(DoctorAppointmentVIsitid).VisitType;
            appvm.isdeleted = getbyid.isdeleted;
            appvm.id =
            (int)_unitOfWork._context.DoctorAppointmentVIsit.Where(i=>i.Id== DoctorAppointmentVIsitid).Select(i=>i.AppointmentId).FirstOrDefault();


            appvm.VisitStatus = VisitStatus.Arrived;

            _unitOfWork.Idoctorvist.Save(appvm);
            return RedirectToAction("Index");


        }











        public IActionResult completed(int DoctorAppointmentVIsitid)
        {
            var appvm = new ApointmentVm();
            var getbyid = _unitOfWork.Idoctorvist.GetById(DoctorAppointmentVIsitid);

            appvm.DoctorAppointmentVIsitid = DoctorAppointmentVIsitid;
            appvm.patientid = getbyid.patientid;
            appvm.doctorid = getbyid.doctorid;
            appvm.VisitType = getbyid.VisitType;
            appvm.isdeleted = getbyid.isdeleted;
            appvm.id =
            (int)_unitOfWork._context.DoctorAppointmentVIsit.Where(i => i.Id == DoctorAppointmentVIsitid).Select(i => i.AppointmentId).FirstOrDefault();


            appvm.VisitStatus = VisitStatus.Completed;

            _unitOfWork.Idoctorvist.Save(appvm);
            return RedirectToAction("Index");


        }













        public IActionResult  CancelledVisitSt( int DoctorAppointmentVIsitid)
        {
            var appvm = new ApointmentVm();
            var getbyid = _unitOfWork.Idoctorvist.GetById(DoctorAppointmentVIsitid);

            appvm.DoctorAppointmentVIsitid = DoctorAppointmentVIsitid;
           
            appvm.VisitStatus= VisitStatus.Cancelled;
        
            _unitOfWork.Idoctorvist.Save(appvm);


            return RedirectToAction("Index");


        }
























        public IActionResult Delete(int id )
        {
          
            _unitOfWork.Idoctorvist.Delete(id);


            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Delete";

            return RedirectToAction("Index");
        }













    }
}
