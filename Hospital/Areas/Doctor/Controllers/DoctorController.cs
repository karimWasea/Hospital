using hospitalservess;
using hospitalVm;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorController : Controller
    { // GET: HomeController
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public DoctorController(UnitOfWork unitOfWork , lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }





        //  GET: HomeController
        public  async  Task< ActionResult> Index()
        {
            var model = await  _unitOfWork.Doctor.GetallconfirmedDoctor();
            return View(model);
        }
        




        public async Task< ActionResult > GetRegisterdoctor()
        {
            var model = await _unitOfWork.Doctor.GetAllDoctorRegester();
            return View(model);
        }

        // GET: HomeController/Details/5
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
            if (id != null)
            {

                var model = await _unitOfWork. Doctor.GetByIdasRegisterdoctor(id);
                return View(model);
            }
            else


                return View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(DoctorVm HospitalVm)
        {

           await  _unitOfWork.Doctor.Save(HospitalVm);


            return RedirectToAction("Index");



         }





























        public async Task<IActionResult> Delete(string id)
        {
            await _unitOfWork.Doctor.Delete(id);
            return RedirectToAction("Index");
        }








    }
}
