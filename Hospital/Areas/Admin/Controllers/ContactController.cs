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
    //<partial name = "_AlertMessage" />

    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]

    public class ContactController : Controller
    { UnitOfWork _unitOfWork;
        public ContactController(UnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }


        public ActionResult Index(int pagnumber = 1, int pagesize = 10)
        {
            return View(_unitOfWork.Contact.Getallpag(pagnumber, pagesize));
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_unitOfWork.Contact.GetById(id));
        }





        public IActionResult Save(int id)
        {

            ViewBag.HospitalsId = _unitOfWork.Ilookup.HospitalsId();

            if (id > 0)
              
            return View(_unitOfWork.Contact.GetById(id));

            else

              
            return View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Save(ContactVm HospitalVm)
        { if(ModelState.IsValid)
            {

                ViewBag.HospitalsId = _unitOfWork.Ilookup.HospitalsId();

                _unitOfWork.Contact.Save(HospitalVm);

                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";

                return RedirectToAction("Index");

            }

            return View(HospitalVm);


        }





























        public IActionResult Delete(int id)
        {
            _unitOfWork.Contact.Delete(id);


            TempData["Message"] = $"Delete successfully!";
            TempData["MessageType"] = "Delete";

            return RedirectToAction("Index");
        }













    }
}
