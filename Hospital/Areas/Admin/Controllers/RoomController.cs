using hospitalIrepreatory;

using hospitalservess;

using hospitalVm;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Drawing.Printing;

namespace Hospital.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    { UnitOfWork _unitOfWork;
        public RoomController(UnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

      //  GET: HomeController
        public ActionResult Index(int pagnumber = 1, int pagesize = 10)
        {
            return View(_unitOfWork.IRoom.Getallpag(pagnumber, pagesize));
        }

        // GET: HomeController/Details/5
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
            
                _unitOfWork.IRoom.Save(HospitalVm);

            return RedirectToAction("Index" , new { success = true });



        }


        public IActionResult Delete(int id)
        {
            _unitOfWork.IRoom.Delete(id);




            return RedirectToAction("Index");
        }













    }
}
