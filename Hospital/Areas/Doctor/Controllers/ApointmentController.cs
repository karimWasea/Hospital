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
            


            //var existingAppointments = new HashSet<DateTime>(_unitOfWork._context.DoctorAppointments.Select(da => da.Appointment.CreateDate));

            //var availableSlots = new List<SelectListItem>();
            //var availableSlotsByDoctor = new Dictionary<string, List<SelectListItem>>(); // Dictionary to store available slots for each doctor


            //// Define the start time for appointments
            //DateTime startTime = DateTime.Today.AddDays(5).AddHours(20); // 9:00 AM

            //// Generate 10 appointment slots with 30-minute intervals
            //for (int i = 0; i < 15; i++)
            //{
            //    DateTime potentialTimeSlot = startTime.AddMinutes(i * 30);

            //    if (!existingAppointments.Contains(potentialTimeSlot))
            //    {
            //        availableSlots.Add(new SelectListItem
            //        {
            //            Value = potentialTimeSlot.ToString("HH:mm"),
            //            Text = potentialTimeSlot.ToString("hh:mm tt")
            //        });
            //    }

            //}

            //ViewBag.AvailableSlots = availableSlots;
            //List<FullCalendarEvent> GetWeekdayEvents(string id, DayOfWeek weekday)
            // {
            //     // Get the doctor's existing appointments for the selected weekday
            //     var doctorExistingAppointments = _unitOfWork._context.DoctorAppointmentVIsit
            //         .Where(da => da.DoctorId == id && da.Appointment.CreateDate.DayOfWeek == weekday)
            //         .Select(da => new FullCalendarEvent
            //         {
            //             Title = "Appointment",
            //             Start = da.Appointment.CreateDate,
            //             End = da.Appointment.CreateDate.AddMinutes(30) // Adjust end time as needed
            //         })
            //         .ToList();

            //    return doctorExistingAppointments;
            //}


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

            #region workingappiontment releas
            //// Get the doctor's existing appointments
            //var doctorExistingAppointments = new HashSet<DateTime>(_unitOfWork._context.DoctorAppointmentVIsit
            //    .Where(da => da.DoctorId == id)
            //    .Select(da => da.Appointment.CreateDate));

            //var availableSlots = new List<SelectListItem>();

            //// Define the start time for appointments
            //DateTime startTime = DateTime.Today.AddHours(12); // 9:00 AM

            //for (int i = 0; i < 24; i++)
            //{
            //    DateTime potentialTimeSlot = startTime.AddMinutes(i * 30);

            //    // Check if the potentialTimeSlot is not booked for this doctor and is not booked by any other doctor
            //    if (!doctorExistingAppointments.Contains(potentialTimeSlot) &&
            //         ! _unitOfWork._context.DoctorAppointmentVIsit.All(da => da.Appointment.CreateDate == potentialTimeSlot))
            //    {
            //        // Check if the potentialTimeSlot is in the future and not exactly equal to the current time
            //        if (potentialTimeSlot > DateTime.Now)
            //        {
            //            availableSlots.Add(new SelectListItem
            //            {
            //                Value = potentialTimeSlot.ToString("HH:mm"),
            //                Text = potentialTimeSlot.ToString("yyyy-MM-dd hh:mm tt")
            //            });

            //            // Stop the loop when you have added 22 available slots
            //            if (availableSlots.Count == 24)
            //            {
            //                break;
            //            }
            //        }
            //    }
            //}


            #endregion

            #region 2
            // Get the doctor's existing appointments
            //    var doctorExistingAppointments = new HashSet<DateTime>(_unitOfWork._context.DoctorAppointments
            //.Where(da => da.DoctorId == id)
            //.Select(da => da.Appointment.CreateDate));

            //    var availableSlots = new List<SelectListItem>();

            //    // Define the start time for appointments
            //    DateTime startTime = DateTime.Today.AddHours(9); // 9:00 AM

            //    for (int i = 0; i <22; i++)
            //    {
            //        DateTime potentialTimeSlot = startTime.AddMinutes(i * 30);

            //        // Check if the potentialTimeSlot is not booked for this doctor and is not booked by any other doctor
            //        if ( !doctorExistingAppointments.Contains(potentialTimeSlot) &&
            //            _unitOfWork._context.DoctorAppointments.Any(da => da.Appointment.CreateDate == potentialTimeSlot))
            //        {
            //            //Check if the potentialTimeSlot is in the future and not exactly equal to the current time
            //            if (potentialTimeSlot <DateTime.Now && potentialTimeSlot != DateTime.Now)
            //            {
            //                availableSlots.Add(new SelectListItem
            //                {
            //                    Value = potentialTimeSlot.ToString("HH:mm"),
            //                    Text = potentialTimeSlot.ToString("yyyy-MM-dd hh:mm tt")
            //                });
            //            }
            //        }
            //    }






            //ViewBag.AvailableSlots = availableSlots;
            #endregion

            #region foreday
            ////var existingAppointments = new HashSet<DateTime>(_unitOfWork._context.DoctorAppointments.Select(da => da.Appointment.CreateDate));

            ////var availableSlots = new List<SelectListItem>();


            ////// Define the start time for appointments
            ////DateTime startTime = DateTime.Today.AddHours(9); // 9:00 AM

            ////    for (int i = 0; i < 15; i++)
            ////    {
            ////        DateTime potentialTimeSlot = startTime.AddMinutes(i * 30);

            ////        if (!existingAppointments.Contains(potentialTimeSlot))
            ////        {
            ////            availableSlots.Add(new SelectListItem
            ////            {
            ////                Value = potentialTimeSlot.ToString("HH:mm"),
            ////                Text = potentialTimeSlot.ToString("yyyy-MM-dd hh:mm tt") // Display date, time, and AM/PM
            ////            });
            ////        }


            ////}
            ////ViewBag.AvailableSlots = availableSlots;
            #endregion


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
