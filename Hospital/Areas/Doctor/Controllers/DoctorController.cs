using hospitalservess;

using hospitalUtilities;
using hospitalVm;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hospital.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]

    public class DoctorController : Controller
    { 

        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public DoctorController(UnitOfWork unitOfWork , lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }





        //  GET: HomeController
        public async Task<ActionResult> Index(int? page, string search)
        {


            var pagedPatients = await _unitOfWork.Doctor.Search(page, search);


            return View(pagedPatients);
        }




        public async Task<ActionResult> GetRegisterdoctor(int? pageget, string search)
        {
           
            var pagedPatients =  await _unitOfWork.Doctor.GetAllDoctorRegester(pageget, search);


            return View(pagedPatients);
        }


      

        public async Task<ActionResult> Details(string id)
        {
            var model = await _unitOfWork.Doctor.GetByIdasconfirmed(id);
            return View(model);
        }





        public async Task<ActionResult> Save(string id)
        {
            ViewBag.Gender = _lookupServess.Gender();
            ViewBag.Doctorspicialist=_lookupServess.Doctorspicialist();
            ViewBag.jop=_lookupServess.jop();
            ViewBag.StatusDoctorInSystem = _lookupServess.StatusDoctorInSystem();
            if (id != null )
            {

                var model = await _unitOfWork. Doctor.GetByIdasRegisterdoctor(id);
                return View(model);
            }
            else


                return View();


        }


        [HttpPost]
        public async Task<ActionResult> Save(DoctorVm HospitalVm)
        {
            ViewBag.Gender = _lookupServess.Gender();
            ViewBag.Doctorspicialist = _lookupServess.Doctorspicialist();
            ViewBag.jop = _lookupServess.jop();
            ViewBag.StatusDoctorInSystem = _lookupServess.StatusDoctorInSystem();
            if (ModelState.IsValid)
            {
                await _unitOfWork.Doctor.Save(HospitalVm);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";

                return RedirectToAction("Index");

            }
         

             return View(HospitalVm);

         }





























        public async Task<IActionResult> Delete(string id)
        {
            await _unitOfWork.Doctor.Delete(id);
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";
            return RedirectToAction("Index");
        }








    }
}
