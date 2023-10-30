using Dataaccesslayer;

using Hospital.Areas.Doctor.Models;

using hospitalIrepreatory;

using hospitalservess;
using hospitalVm;

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
    public class ApointmentController : Controller
    { // GET: HomeController
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
      
        private readonly UserManager<ApplicationUser> _userManager;

        public ApointmentController(UnitOfWork unitOfWork , lookupServess lookupServess , UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
            _userManager = userManager;
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





        public  IActionResult Save( int id)
        {
            


          

            if (id > 0)
             

                return View(_unitOfWork.Apointment.GetById(id));

            else


                return View();


        }



     public async Task< IActionResult > ConfimedApiontmentfordoctor() {





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
            var conappfordoc =  _unitOfWork.Apointment.GetBookingAppiontmentbydocid(userId);







            return View(conappfordoc); 
        
        
        
        }






        public async Task< IActionResult> getapientment( string id) 
        
        
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
            ViewBag.AvailableSlots = _lookupServess.AvailableAppointments(id);
          //  ViewBag.AvailableSlots = availableSlots;
            ViewBag.Visitetype = _lookupServess.Visitetype();
            var m = await _unitOfWork.Apointment.GetAvilablebydocid(id);

            return View(m);
                
                
                
                
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


            return Redirect("yourappiontisconfermed");



        }








        public IActionResult  yourappiontisconfermed()
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
