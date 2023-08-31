using hospitalIrepreatory;

using hospitalservess;

using hospitalVm;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Drawing.Printing;

namespace Hospital.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            
                _unitOfWork.Ihospital.Save(HospitalVm);


                return RedirectToAction("Index");
            


        }





























        public IActionResult Delete(int id )
        {
          
            _unitOfWork.Ihospital.Delete(id);




            return RedirectToAction("Index");
        }













    }
}
