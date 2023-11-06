using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalservess;

using hospitalUtilities;
using hospitalVm;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Areas.Patient.Controllers
{

    [Area("Patient")]
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin},{WebSiteRoles.WebSite_Doctor}")]

    public class PatientController : Controller
    {

        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public PatientController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }





        //  GET: HomeController
        public async Task<ActionResult> Index(int? page, string search)
        {


            var pagedPatients = await _unitOfWork.Patient.Search(page, search);


            return View(pagedPatients);
        }









        public async Task<ActionResult> Details(string id)
        {
            var model = await _unitOfWork.Patient.GetBy(id);
            return View(model);
        }





        public async Task<ActionResult> Save(string id)
        {
            ViewBag.Gender = _lookupServess.Gender();
            ViewBag.Doctorspicialist = _lookupServess.Doctorspicialist();
            ViewBag.jop = _lookupServess.jop();
            ViewBag.StatusDoctorInSystem = _lookupServess.StatusDoctorInSystem();
            if (id != null)
            {

                var model = await _unitOfWork.Patient.GetBy(id);
                return View(model);
            }
            else


                return View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save( PatientVm HospitalVm)
        {
            ViewBag.Gender = _lookupServess.Gender();
            ViewBag.Doctorspicialist = _lookupServess.Doctorspicialist();
            ViewBag.jop = _lookupServess.jop();
            ViewBag.StatusDoctorInSystem = _lookupServess.StatusDoctorInSystem();
            if (ModelState.IsValid)
            {
                await _unitOfWork.Patient.Save(HospitalVm);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";

                return RedirectToAction("Index");

            }


            return View(HospitalVm);

        }





























        public async Task<IActionResult> Delete(string id)
        {
            await _unitOfWork.Patient.Delete(id);
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";
            return RedirectToAction("Index");
        }







    }
}
