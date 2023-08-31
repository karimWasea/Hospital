using Dataaccesslayer;

using hospitalservess;
using hospitalVm;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Areas.Patient.Controllers
{

    [Area("Patient")]
    public class PatientHistoryController : Controller
    { // GET: HomeController
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;


        public PatientHistoryController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        public IActionResult Index(int? page, string search)
        {
            var model = _unitOfWork.patientHistory.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                    SearchProperty(patient.FamilyHistory, search) ||
                    SearchProperty(patient.Allergies, search) ||
                    SearchProperty(patient.Medications, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.LabResults, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.Assessment, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.PastMedicalHistory, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.ChiefComplaint, search, StringComparison.OrdinalIgnoreCase)
                // Add more properties for search as needed
                );
            }

            var pagedPatients = _unitOfWork.patientHistory.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

        // Helper method for case-insensitive search
        private bool SearchProperty(string propertyValue, string search, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                   propertyValue.Contains(search, comparison);
        }


        public ActionResult Details(int id)
        {
            var model =  _unitOfWork.patientHistory.GetById(id);
            return View(model);
        } 



        public ActionResult GetALLpatientHistory(string PatientId, int? page, string search)
        {
            var pagedPatients =  _unitOfWork.patientHistory.GetallPatientHistory(PatientId);
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                pagedPatients = pagedPatients.Where(patient =>
                    SearchProperty(patient.FamilyHistory, search) ||
                    SearchProperty(patient.Allergies, search) ||
                    SearchProperty(patient.Medications, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.LabResults, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.Assessment, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.PastMedicalHistory, search, StringComparison.OrdinalIgnoreCase) ||
                    SearchProperty(patient.ChiefComplaint, search, StringComparison.OrdinalIgnoreCase)
                // Add more properties for search as needed
                );
            }

            var pagedPatients2 = _unitOfWork.patientHistory.GetPagedData(pagedPatients.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients2);
        }


        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.patientHistory.Delete(id);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Save(int id)
        {
            ViewBag.allpatient = _lookupServess.allpatient();
            if (id > 0)
            {

                var model =  _unitOfWork.patientHistory.GetById(id);
                return View(model);
            }
            else


                return View();


        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Save(PatientHistoryVm HospitalVm)
        {

             _unitOfWork.patientHistory.Save(HospitalVm);


            return RedirectToAction("Index");



        }




    }
}












