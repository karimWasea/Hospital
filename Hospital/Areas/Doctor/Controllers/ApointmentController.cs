using Dataaccesslayer;

using Hospital.Areas.Doctor.Models;

using hospitalIrepreatory;

using hospitalservess;

using hospitalUtilities;
using hospitalVm;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Claims;

using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace Hospital.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = $"{WebSiteRoles.WebSite_SuperAdmin},{WebSiteRoles.WebSite_Doctor}")]

    public class ApointmentController : Controller
    {

        UnitOfWork _unitOfWork;




        public ApointmentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }

        //  GET: HomeController
        public ActionResult Index()
        {

            return View(_unitOfWork.Apointment.GetAll());
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_unitOfWork.genericRepositoryAppiontment.GetById(id));
        }





        public IActionResult Save(int id)
        {





            if (id > 0)


                return View(_unitOfWork.Apointment.GetById(id));

            else


                return View();


        }



        public async Task<IActionResult> ConfimedApiontmentfordoctor()
        {





            var claimsIdentity = (ClaimsIdentity)User.Identity;
            if (!claimsIdentity.IsAuthenticated)
            {
                return Redirect("/Admin/Home/Index");
            }

            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Roleregester = _unitOfWork._userManager.Users.FirstOrDefault(i => i.Id == userId).RoleRegeseter;


            if (string.IsNullOrEmpty(userId) && Roleregester != RoleRegeseter.Doctor)
            {
                // Handle the case where the user identifier is not found in claims (optional).
                return Redirect("/Admin/Home/Index");
            }
            var conappfordoc = _unitOfWork.Apointment.GetBookingAppiontmentbydocid(userId);







            return View(conappfordoc);



        }






        public async Task<IActionResult> CreatApientment(string id)


        {
         

                var claimsIdentity = (ClaimsIdentity)User.Identity;
            if (!claimsIdentity.IsAuthenticated)
            {
                return Redirect("/Admin/Home/Index");
            }

            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                // Handle the case where the user identifier is not found in claims (optional).
                return Redirect("/Admin/Home/Index");
            }
            ViewBag.AvailableSlots = _unitOfWork._lookupServess.AvailableAppointments(id);

            ViewBag.Visitetype = _unitOfWork._lookupServess.Visitetype();
            var model = await _unitOfWork.Apointment.GetAvilablebydocid(id);
        
            return View(model);




        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Save(ApointmentVm appointment)
        {



       





                var claimsIdentity = (ClaimsIdentity)User.Identity;
                if (!claimsIdentity.IsAuthenticated)
                {
                    return Redirect("/Admin/Home/Index");
                }

                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    // Handle the case where the user identifier is not found in claims (optional).
                    return Redirect("/Admin/Home/Index");
                }

                appointment.patientid = userId;


                _unitOfWork.Apointment.Save(appointment);


                return Redirect("/Admin/Appiontmentvisite/GetAllVistitsbyPatientid");

           

        }








        public IActionResult yourappiontisconfermed()
        {

            return View();




        }




















        public IActionResult Delete(int id)
        {
            _unitOfWork.ItimingSHift.Delete(id);




            return RedirectToAction("Index");
        }








    }
}
