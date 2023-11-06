using hospitalIrepreatory;

using hospitalservess;

using hospitalUtilities;
using hospitalVm;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Drawing.Printing;

namespace Hospital.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin},{WebSiteRoles.WebSite_Doctor}")]

    public class RoomController : Controller
    { UnitOfWork _unitOfWork;
        public RoomController(UnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }


        public ActionResult Index(int pagnumber = 1, int pagesize = 10)
        {
            return View(_unitOfWork.IRoom.Getallpag(pagnumber, pagesize));
        }


        public ActionResult Details(int id)
        {
            return View(_unitOfWork.IRoom.GetById(id));
        }





        public IActionResult Save(int id)
        {
            ViewBag.HospitalsId = _unitOfWork.Ilookup.HospitalsId();

            if (id > 0)

                return View(_unitOfWork.IRoom.GetById(id));

            else
      

            return      View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Save(RoomVm HospitalVm)
        {
            ViewBag.HospitalsId = _unitOfWork.Ilookup.HospitalsId();

            if (ModelState.IsValid)
            {

                _unitOfWork.IRoom.Save(HospitalVm);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction("Index", new { success = true });
            }

            return View(HospitalVm);



        }


        public IActionResult Delete(int id)
        {
            _unitOfWork.IRoom.Delete(id);
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Delete";



            return RedirectToAction("Index");
        }













    }
}
