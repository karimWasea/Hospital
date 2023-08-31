using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalservess;

using hospitalVm;

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
    public class AppiontmentvisiteController : Controller
    {


        lookupServess _lookupServess;
        UnitOfWork _unitOfWork;
        public AppiontmentvisiteController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _lookupServess=lookupServess;
            _unitOfWork = unitOfWork;
        }

       // GET: HomeController

        public IActionResult Index(int? page, string search)
        {
            var model = _unitOfWork.Idoctorvist.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower(); // Convert the search text to lowercase

                //  Apply search filtering here based on your model properties
                model = model.Where(patient =>
                   SearchProperty(patient.DoctorName, search) ||
                   SearchProperty(patient.PatientName, search)

               );
            }

            var pagedPatients = _unitOfWork.Idoctorvist.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;
            

            return View(pagedPatients);
        }

        //  Helper method for case-insensitive search






        private bool SearchProperty(string propertyValue, string search, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                   propertyValue.IndexOf(search, comparison) >= 0;
        }
        //   GET: HomeController/Details/5
        public ActionResult Details(int DoctorAppointmentVIsitid)
        {
            return View(_unitOfWork.Idoctorvist.GetById(  DoctorAppointmentVIsitid));
        }
        public ActionResult patientvistbypatientid(string id, string search , int? page)
        {

            if (id != null)
            {
                var model2 = _unitOfWork.Idoctorvist.getvistitsbypatientid(id);
                int pageNumber2 = page ?? 1;

                var pagedPatients2 = _unitOfWork.Idoctorvist.GetPagedData(model2.AsQueryable(), pageNumber2);

                ViewBag.Search = search;

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

            var model = _unitOfWork.Idoctorvist.getvistitsbypatientid(userId);
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower(); // Convert the search text to lowercase

                //  Apply search filtering here based on your model properties
                model = model.Where(patient =>
                   SearchProperty(patient.doctorid, search) ||
                   SearchProperty(patient.PatientName, search)

               );
            }

            var pagedPatients = _unitOfWork.Idoctorvist.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }









        public ActionResult Getalldoctorvisit(string id, string search, int? page)
        {



            if (id != null)
            {
                int pageNumber2 = page ?? 1;


                var model2 = _unitOfWork.Idoctorvist.getvistitsbydoctorid(id);

                var pagedPatients2 = _unitOfWork.Idoctorvist.GetPagedData(model2.AsQueryable(), pageNumber2);

                ViewBag.Search = search;

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
           
                var model = _unitOfWork.Idoctorvist.getvistitsbydoctorid(userId);

           

          

            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower(); // Convert the search text to lowercase

                //  Apply search filtering here based on your model properties
                model = model.Where(patient =>
                   SearchProperty(patient.DoctorName, search) ||
                   SearchProperty(patient.PatientName, search)

               );
            }

            var pagedPatients = _unitOfWork.Idoctorvist.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
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
        // [ValidateAntiForgeryToken]
        public IActionResult Save(ApointmentVm HospitalVm)
        {
            
                _unitOfWork.Idoctorvist.Save(HospitalVm);

            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";
            return RedirectToAction("Index");
            


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult AddDoctorNoteForVisit(ApointmentVm HospitalVm)
        {
           var model= _unitOfWork.Idoctorvist.GetById(HospitalVm.DoctorAppointmentVIsitid);
            HospitalVm.CreateDate = model.CreateDate;
            HospitalVm.discreaption = model.discreaption;
            HospitalVm.id = model.id;
            HospitalVm.VisitStatus = VisitStatus.InProgress;

            _unitOfWork.Idoctorvist.Save(HospitalVm);


            return View(_unitOfWork.Idoctorvist.GetById(HospitalVm.DoctorAppointmentVIsitid));



        }



        public IActionResult AddDoctorNoteForVisit(int DoctorAppointmentVIsitid)
        {
            return View(_unitOfWork.Idoctorvist.GetById(DoctorAppointmentVIsitid));
        }


        




            public IActionResult ArrivedVisit( int  DoctorAppointmentVIsitid)
        {
            var appvm = new ApointmentVm();
             var getbyid= _unitOfWork. Idoctorvist.GetById(DoctorAppointmentVIsitid);

            appvm.DoctorAppointmentVIsitid = DoctorAppointmentVIsitid;
            appvm.patientid = getbyid.patientid;
            appvm.doctorid = getbyid.doctorid;
            appvm.VisitType = getbyid.VisitType;
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
            //_unitOfWork._context.DoctorAppointmentVIsit.Find(DoctorAppointmentVIsitid).VisitType;
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
            appvm.patientid = getbyid.patientid;
            appvm.doctorid = getbyid.doctorid;
            appvm.VisitType = getbyid.VisitType;
            appvm.VisitStatus= VisitStatus.Cancelled;
            //_unitOfWork._context.DoctorAppointmentVIsit.Find(DoctorAppointmentVIsitid).VisitType;
            appvm.isdeleted = getbyid.isdeleted;
            appvm.id =
            (int)_unitOfWork._context.DoctorAppointmentVIsit.Where(i => i.Id == DoctorAppointmentVIsitid).Select(i => i.AppointmentId).FirstOrDefault();
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
