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
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]

    public class HospitailController : Controller
    { UnitOfWork _unitOfWork;
        public HospitailController(UnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

      //  GET: HomeController
        public ActionResult Index()
        {
            return View(_unitOfWork.Ihospital.GetAll());
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_unitOfWork.Ihospital.GetById(id));
        }





        public IActionResult Save(int id)
        {


            if (id > 0)

                return View(_unitOfWork.Ihospital.GetById(id));

            else
      

            return View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Save(HospitalVm HospitalVm)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Ihospital.Save(HospitalVm);



                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction("Index");
            }
      
return View(HospitalVm);


        }





























        public IActionResult Delete(int id )
        {
          
            _unitOfWork.Ihospital.Delete(id);


            TempData["Message"] = $"Delete successfully!";
            TempData["MessageType"] = "Delete";


            return RedirectToAction("Index");
        }













    }
}
