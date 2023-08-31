

using hospitalservess;

using hospitalVm;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Areas.Doctor.Controllers
{
    [Area("Doctor")]
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





        public IActionResult Save(int id)
        {

            ViewBag.avilabledoctoronsift = _lookupServess.avilabledoctoronsift();
            //ViewBag.GetHoursListAmFinhed = _lookupServess.GetHoursListAmFinhed();
            //ViewBag.GetHoursListAmstarted = _lookupServess.GetHoursListAmstarted();
            //ViewBag.GetHoursListPmstarted = _lookupServess.GetHoursListPmstarted();
            //ViewBag.GetHoursListPmfinsied = _lookupServess.GetHoursListPmfinsied();
            ViewBag.getdoctorfromapplicationuserid = _lookupServess.getdoctorfromapplicationuserid();

            if (id > 0)

                return View(_unitOfWork.ItimingSHift.GetById(id));

            else


                return View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Save(timingshiftVm HospitalVm)
        {

            _unitOfWork.ItimingSHift.Save(HospitalVm);


            return RedirectToAction("Index");



        }





























        public IActionResult Delete(int id)
        {
            _unitOfWork.ItimingSHift.Delete(id);




            return RedirectToAction("Index");
        }








    }
}
