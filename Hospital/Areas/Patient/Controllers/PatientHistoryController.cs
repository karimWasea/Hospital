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
            var model = _unitOfWork.patientHistory.Search(page,search);
           

            return View(model);
        }

    



        public ActionResult Details(int id)
        {
            var model =  _unitOfWork.patientHistory.GetById(id);
            return View(model);
        } 



        public ActionResult GetALLpatientHistory(string PatientId, int? page, string search)
        {
            var pagedPatients =  _unitOfWork.patientHistory.GetallPatientHistory(PatientId,page,search);
           

       

            return View(pagedPatients);
        }


        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.patientHistory.Delete(id);
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Delete";
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

        public ActionResult Save(PatientHistoryVm HospitalVm)
        {
            ViewBag.allpatient = _lookupServess.allpatient();


            _unitOfWork.patientHistory.Save(HospitalVm);
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";

            return RedirectToAction("Index");



        }




    }
}












