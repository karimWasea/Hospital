using hospitalservess;

using hospitalUtilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin},{WebSiteRoles.WebSite_Doctor},{WebSiteRoles.WebSite_patient}")]

    public class HomeController : Controller
    {








        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public HomeController(UnitOfWork unitOfWork, lookupServess lookupServess)
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



        public IActionResult Privacy()
        {
            return View();
        }
        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
