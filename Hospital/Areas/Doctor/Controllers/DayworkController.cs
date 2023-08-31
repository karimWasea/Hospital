

using Dataaccesslayer;

using hospitalservess;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Newtonsoft.Json;

namespace Hospital.Areas.Doctor.Controllers
{
    [Area("Doctor")]

    public class DayworkController : Controller
    { // GET: HomeController
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        UserManager<ApplicationUser> _UserManager;
        public DayworkController(UnitOfWork unitOfWork, lookupServess lookupServess , UserManager<ApplicationUser> UserManager)
        {
            _UserManager = UserManager;
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        //  GET: HomeController
        public ActionResult Index( string doctorId)
        {
            ViewBag.getdoctorfromapplicationuserid = _lookupServess.getdoctorfromapplicationuserid();

            return View(_unitOfWork.idoctodayworinweek.getall());
        }

        // GET: HomeController/Details/5
        public ActionResult  AllDayShifts()
        {
            return View(_unitOfWork.idoctodayworinweek.GetAll());
        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Save([FromBody] List<DoctorDayworkVM> HospitalVm)
        {


            DoctorDayworkVM doctorDayworkVM = new();

            foreach (var xday in HospitalVm)


            {
                if (xday.ispm == true)
                {
                    doctorDayworkVM.Hifts= SHifts.nightSiftfrrom5pmto8Am;
                    doctorDayworkVM.WeekDaystId = xday.WeekDaystId;
                    doctorDayworkVM.DoctorId = xday.DoctorId;
                    doctorDayworkVM.DoctorDayworkId = xday.DoctorDayworkId;


                }
                else if (xday.isam == true)
                {
                    xday.Hifts = SHifts.morinimgSiftfrrom8Amto5pm;
                    doctorDayworkVM.WeekDaystId = xday.WeekDaystId;
                    doctorDayworkVM.DoctorId = xday.DoctorId;
                    doctorDayworkVM.DoctorDayworkId = xday.DoctorDayworkId;
                }
                else {


                    doctorDayworkVM.WeekDaystId = xday.WeekDaystId;
                    doctorDayworkVM.DoctorId = xday.DoctorId;
                    doctorDayworkVM.DoctorDayworkId = xday.DoctorDayworkId;

                    doctorDayworkVM.Hifts =SHifts.HasNosifits;
                }
                   
                 
                _unitOfWork.idoctodayworinweek.Save(doctorDayworkVM);
                TempData["Message"] = $"  successfully!";
                TempData["MessageType"] = "updated";


            }


            return View();



        }

        public IActionResult SaveGET(string id)
        {

            //ViewBag.DAyWeekId = _lookupServess.DAyWeekId();

            //ViewBag.getdoctorfromapplicationuserid = _lookupServess.Shifts();
            ViewBag.getdoctorfromapplicationuserid = _UserManager.Users.Where(r => r.Id == id).Select(p=>p.UserName).FirstOrDefault();
            ViewBag.id= id;
            return View(_unitOfWork.idoctodayworinweek.getall());





        }


     





























        public IActionResult Delete(int id)
        {
            _unitOfWork.ItimingSHift.Delete(id);




            return RedirectToAction("Index");
        }








    }
}
