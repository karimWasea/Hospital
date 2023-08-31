using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalservess;
using hospitalVm;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Areas.Patient.Controllers
{

    [Area("Patient")]
    public class PatientController : Controller
    { // GET: HomeController
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;


        public PatientController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }


        public async Task<IActionResult> Index(int? page, string search)
        {
            var model = await _unitOfWork.Patient.Getall();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                    SearchProperty(patient.username, search) ||
                    SearchProperty(patient.Email, search) ||
                    SearchProperty(patient.Phonenumber, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.PostalCode, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.Nationality, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.StreetAddress, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.City, search, StringComparison.OrdinalIgnoreCase)
                // Add more properties for search as needed
                );
            }

            var pagedPatients = _unitOfWork.Patient.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

        // Helper method for case-insensitive search
        private bool SearchProperty(string propertyValue, string search, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                   propertyValue.Contains(search, comparison);
        }

        //  GET: HomeController


        //public async Task<IActionResult> Index(int? page)
        //{
        //    var model = await _unitOfWork.Patient.Getall();
        //    int pageNumber = page ?? 1;

        //    var pagedPatients = _unitOfWork.Patient.GetPagedData(model.AsQueryable(), pageNumber);

        //    return View(pagedPatients);
        //}




        //public async Task<IActionResult> _Pagnatination(int? page)
        //{
        //    var model = await _unitOfWork.Patient.Getall();
        //    var pagedPatients = _unitOfWork.Patient.GetPagedData(model.AsQueryable(), page ?? 1);





        //    return PartialView("_Pagnatination", pagedPatients);
        //}









        // GET: HomeController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var model = await _unitOfWork.Patient.GetById(id);
            return View(model);
        }




        public async Task<ActionResult> Save(string id)
        {
            ViewBag.jop = _lookupServess.jop();
            ViewBag.Gender = _lookupServess.Gender();
            if (id != null)
            {

                var model = await _unitOfWork.Patient.GetById(id);
                return View(model);
            }
            else


                return View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(DoctorVm HospitalVm)
        {

            await _unitOfWork.Doctor.Save(HospitalVm);


            return RedirectToAction("Index");



        }





























        public async Task<IActionResult> Delete(string id)
        {
            await _unitOfWork.Patient.Delete(id);
            return RedirectToAction("Index");
        }








    }
}
