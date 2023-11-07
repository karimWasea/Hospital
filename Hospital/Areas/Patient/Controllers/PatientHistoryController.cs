using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalservess;

using hospitalUtilities;
using hospitalVm;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Text;

namespace Hospital.Areas.Patient.Controllers
{

    [Area("Patient")]

    public class PatientHistoryController : Controller
    {

        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;


        public PatientHistoryController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }
        [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]

        public IActionResult Index(int? page, string search)
        {
            var model = _unitOfWork.patientHistory.Search(page,search);
           

            return View(model);
        }



        [Authorize(policy: $"{WebSiteRoles.WebSite_DoctorAndSuperadmin}")]


        public ActionResult Details(int id)
        {
            var model =  _unitOfWork.patientHistory.GetById(id);
            return View(model);
        }



        [Authorize(policy:  $"{WebSiteRoles.WebSite_DoctorAndSuperadmin}")]


        public ActionResult GetALLpatientHistory(string PatientId, int? page, string search)
        {
            var pagedPatients =  _unitOfWork.patientHistory.GetallPatientHistory(PatientId,page,search);
           

       

            return View(pagedPatients);
        }

        [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]

        public async Task<IActionResult> Delete(int id)
        {
         
            _unitOfWork.patientHistory.Delete(id);
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Delete";
            return RedirectToAction("Index");
        }



        [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]

        public async Task<ActionResult> Save(int id, string patientId)
    {
        ViewBag.allpatient = _lookupServess. allpatient();
        StringBuilder sb = new StringBuilder();

        if (id > 0)
        {
            var model = _unitOfWork.patientHistory.GetById(id);
            return View(model);
        }
        else
        {
            var user = _unitOfWork._userManager.Users.FirstOrDefault(i => i.Id == patientId);

            if (user != null)
            {
                sb.Append(user.UserName);
                // You can append more information to the string if needed
                // sb.Append(" Additional Information");
            }
        }

        return View(new PatientHistoryVm() { PatientName = sb.ToString() });
    }


    [HttpPost]
        [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin}")]

        public ActionResult Save(PatientHistoryVm HospitalVm)
        {
            ViewBag.allpatient = _lookupServess.allpatient();
            if (ModelState.IsValid)
            {
                _unitOfWork.patientHistory.Save(HospitalVm);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";

                return RedirectToAction("Index");
            }

            return View(HospitalVm);




        }




    }
}












