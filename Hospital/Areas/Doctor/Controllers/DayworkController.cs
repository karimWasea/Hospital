

using Dataaccesslayer;

using hospitalservess;

using hospitalUtilities;
using hospitalVm;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Newtonsoft.Json;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hospital.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin},{WebSiteRoles.WebSite_Doctor}")]

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
        public async Task<ActionResult> Index(string doctorId)
        {
            ViewBag.getdoctorfromapplicationuserid = _lookupServess.getdoctorfromapplicationuserid();
            var model = _unitOfWork.idoctodayworinweek.getall();

            return View(model);

        }
      


        // GET: HomeController/Details/5
        public ActionResult  AllDayShifts(int? page)
        {
            var model = _unitOfWork.idoctodayworinweek.GetAll();
         int pageNumber = page ?? 1;
            var pagedPatients = _unitOfWork.idoctodayworinweek.GetPagedData(model.AsEnumerable(), pageNumber);
            return View(pagedPatients);

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
