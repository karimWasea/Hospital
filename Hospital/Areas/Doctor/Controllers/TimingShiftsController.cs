

using Dataaccesslayer;

using hospitalservess;

using hospitalUtilities;
using hospitalVm;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

using System.Runtime.InteropServices;

namespace Hospital.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]

    public class TimingShiftsController : Controller
    { // GET: HomeController
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public TimingShiftsController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        //  GET: HomeController
        public ActionResult Index(int pagnumber = 1, int pagesize = 10)
        {
            return View(_unitOfWork.ItimingSHift.Getallpag(pagnumber, pagesize));
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_unitOfWork.ItimingSHift.GetById(id));
        }




        public IActionResult Save(int id, [Optional] string Doctorname , [Optional] string DoctoId)
        {
            ViewBag.avilabledoctoronsift = _lookupServess.avilabledoctoronsift();

            if (id > 0)
            {
                var existingTimingShift = _unitOfWork.ItimingSHift.GetById(id);
                if (existingTimingShift == null)
                {
                    // Handle the case where the timing shift with the specified ID is not found.
                    return NotFound();
                }
                return View(existingTimingShift);
            }
            else
            {
                var timingshiftVms = new timingshiftVm
                {
                    doctorName = Doctorname,
                    applicatinUserdictorid= DoctoId
                    // Initialize other properties as needed
                };
                return View(timingshiftVms);
            }
        }



        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Save(timingshiftVm HospitalVm)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.ItimingSHift.Save(HospitalVm);

                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction("Index");
            }

            ViewBag.avilabledoctoronsift = _lookupServess.avilabledoctoronsift();

            return View(HospitalVm);


        }





























        public IActionResult Delete(int id)
        {
            _unitOfWork.ItimingSHift.Delete(id);

            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Delete";


            return RedirectToAction("Index");
        }








    }
}
