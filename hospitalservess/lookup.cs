using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities.SystemEnums;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace hospitalservess
{






    //Ahned.n.1995@gmail.com

    //AQAAAAIAAYagAAAAEL62iRnr0hKk72XXS6LlUMffzEr8D+WnI0zpqvtdgNceAhF983w47CDFwTxx1O0alQ==

    public class lookupServess : Ilookup
    {
        private readonly ApplicationDBcontext _applicationDBcontext; 

        private readonly UserManager<ApplicationUser> _user;


        public lookupServess(UserManager<ApplicationUser> userManager, ApplicationDBcontext applicationDBcontext) { 
            _applicationDBcontext = applicationDBcontext;
            _user = userManager;



        }
        public IQueryable<SelectListItem> HospitalsId()
        {

            IQueryable<SelectListItem>? Category = _applicationDBcontext.Hospitals.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.Name });
            return Category;
        }

        public IQueryable<SelectListItem> getdoctorfromapplicationuserid()
        {

            IQueryable<SelectListItem>? applicationuser = _user.Users.Where(r => r.statusDoctorInSystem  == Cofimationdoctor.Confirmed).Select(x => new SelectListItem { Value = x.Id, Text = x.UserName });
            return applicationuser;
        }
          public IQueryable<SelectListItem> allpatient()
        {

            IQueryable<SelectListItem>? applicationuser = _user.Users.Where(r => r.RoleRegeseter==RoleRegeseter.Patient).Select(x => new SelectListItem { Value = x.Id, Text = x.UserName });
            return applicationuser;
        }



        public IQueryable<SelectListItem> getdoctorid(string id )
        {

            IQueryable<SelectListItem>? applicationuser = _user.Users.Where(r => r.Id== id).Select(x => new SelectListItem { Value = x.Id, Text = x.UserName });
            return applicationuser;
        }  
        
        
        
        public IQueryable<SelectListItem> PatientbyId(string id )
        {

            IQueryable<SelectListItem>? applicationuser = _user.Users.Where(r => r.Id== id).Select(x => new SelectListItem { Value = x.Id, Text = x.UserName });
            return applicationuser;
        }





        public List<SelectListItem> GetWeekdaySelectList()
        {
            var weekdays = Enum.GetValues(typeof(DayOfWeek))
                               .Cast<DayOfWeek>()
                               .Select(d => new SelectListItem
                               {
                                   Value = ((int)d).ToString(),
                                   Text = d.ToString()
                               })
                               .ToList();

            return weekdays;
        }







        //public List<SelectListItem> GetHoursListAmstarted()
        //{
        //    return Enum.GetValues(typeof(TwelveHourClockPm))
        //               .Cast<TwelveHourClockPm>()
        //               .Select(hour => new SelectListItem
        //               {
        //                   Value = ((int)hour).ToString(),
        //                   Text = hour.ToString()
        //               })
        //               .ToList();
        //}



        //public List<SelectListItem> FormalStartingShift()
        //{
        //    return Enum.GetValues(typeof(FormalStartingShift))
        //                   .Cast<FormalStartingShift>()
        //                   .Select(hour => new SelectListItem
        //                   {
        //                       Value = hour.ToString(),
        //                       Text = hour.ToString()
        //                   })
        //                   .ToList();
        //}



        //public List<SelectListItem> FormalEndingShift()
        //{
        //    return Enum.GetValues(typeof(FormalEndingShift))
        //                   .Cast<FormalEndingShift>()
        //                   .Select(hour => new SelectListItem
        //                   {
        //                       Value = hour.ToString(),
        //                       Text = hour.ToString()
        //                   })
        //                   .ToList();
        //}





        public List<SelectListItem> avilabledoctoronsift()
        {
            return Enum.GetValues(typeof(Stutus))
                           .Cast<Stutus>()
                           .Select(hour => new SelectListItem
                           {
                               Value = ((int)hour).ToString(),
                               Text = hour.ToString()
                           })
                           .ToList();
        }




















        //public List<SelectListItem> availableSlots()
        //{
        //    var availableSlots = new List<SelectListItem>();

        //    // Define the start time for appointments
        //    DateTime startTime = DateTime.Today.AddHours(9); // 9:00 AM

        //    //// Generate 10 appointment slots with 30-minute intervals
        //    for (int i = 0; i < 10; i++)
        //    {
        //        availableSlots.Add(new SelectListItem
        //        {
        //            Value = startTime.ToString("HH:mm"),
        //            Text = startTime.ToString("hh:mm tt")
        //        });
        //        startTime = startTime.AddMinutes(30);
        //    }
        //    return availableSlots;
        //}

        public List<SelectListItem> Gender()
        {
            return Enum.GetValues(typeof(Gender))
                                   .Cast<Gender>()
                                   .Select(hour => new SelectListItem
                                   {
                                       Value = ((int)hour).ToString(),
                                       Text = hour.ToString()
                                   })
                                   .ToList();
        }  
        
        public List<SelectListItem> Shifts()
        {
            return Enum.GetValues(typeof(SHifts))
                                   .Cast<SHifts>()
                                   .Select(hour => new SelectListItem
                                   {
                                       Value = ((int)hour).ToString(),
                                       Text = hour.ToString()
                                   })
                                   .ToList();
        }

        public List<SelectListItem> Doctorspicialist()
        {
            return Enum.GetValues(typeof(spicialist))
                                              .Cast<spicialist>()
                                              .Select(hour => new SelectListItem
                                              {
                                                  Value = ((int)hour).ToString(),
                                                  Text = hour.ToString()
                                              })
                                              .ToList();
        }

        public List<SelectListItem> jop()
        {
            return Enum.GetValues(typeof(RoleRegeseter))
                                              .Cast<RoleRegeseter>()
                                              .Select(hour => new SelectListItem
                                              {
                                                  Value = ((int)hour).ToString(),
                                                  Text = hour.ToString()
                                              })
                                              .ToList();
        }

       
        public List<SelectListItem> Visitetype() 
        {
            return Enum.GetValues(typeof(VisitType))
                                                    .Cast<VisitType>()
                                                          .Select(hour => new SelectListItem
                                                          {
                                                              Value = ((int)hour).ToString(),
                                                              Text = hour.ToString()
                                                          })
                                                          .ToList();
        } 
        public List<SelectListItem> viststuts()
        {
            return Enum.GetValues(typeof(VisitType))
                                                    .Cast<VisitStatus>()
                                                          .Select(hour => new SelectListItem
                                                          {
                                                              Value = ((int)hour).ToString(),
                                                              Text = hour.ToString()
                                                          })
                                                          .ToList();
        }






        #region for this day
        //public List<SelectListItem> AvilableApiontment(string id)
        //{
        //    // Get the doctor's existing appointments
        //    var doctorExistingAppointments = new HashSet<DateTime>(_applicationDBcontext.DoctorAppointmentVIsit
        //        .Where(da => da.DoctorId == id)
        //        .Select(da => da.Appointment.CreateDate));

        //    var availableSlots = new List<SelectListItem>();

        //    // Define the start time for appointments
        //    DateTime startTime = DateTime.Today.AddHours(12); // 9:00 AM

        //    for (int i = 0; i < 24; i++)
        //    {
        //        DateTime potentialTimeSlot = startTime.AddMinutes(i * 30);

        //        // Check if the potentialTimeSlot is not booked for this doctor and is not booked by any other doctor
        //        if (!doctorExistingAppointments.Contains(potentialTimeSlot) &&
        //             !_applicationDBcontext.DoctorAppointmentVIsit.All(da => da.Appointment.CreateDate == potentialTimeSlot))
        //        {
        //            // Check if the potentialTimeSlot is in the future and not exactly equal to the current time
        //            if (potentialTimeSlot > DateTime.Now)
        //            {
        //                availableSlots.Add(new SelectListItem
        //                {
        //                    Value = potentialTimeSlot.ToString("HH:mm"),
        //                    Text = potentialTimeSlot.ToString("yyyy-MM-dd hh:mm tt")
        //                });

        //                // Stop the loop when you have added 22 available slots
        //                if (availableSlots.Count == 24)
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return availableSlots;
        //}

        #endregion















        #region for nextday 



        public List<SelectListItem> AvailableAppointments(string doctorId ,int chosenDayOffset = 5)
        {
            var doctorExistingAppointments = new HashSet<DateTime>(
                _applicationDBcontext.DoctorAppointmentVIsit
                    .Where(da => da.DoctorId == doctorId)
                    .Select(da => da.Appointment.CreateDate));

            var availableSlots = new List<SelectListItem>();

            DateTime currentDate = DateTime.Now.Date ;
            DateTime futureDate = currentDate.AddDays(7);
            DateTime startOfDay = futureDate.Date.AddHours(12); // Start time for appointments
            DateTime endOfDay = futureDate.Date.AddHours(12 + 23).AddMinutes(30 * 23); // End time for appointments


            while (currentDate <= futureDate)
            {
                //for (int i = 0; i < 24; i++)
                //{
                    for (DateTime potentialTimeSlot = startOfDay; potentialTimeSlot <= endOfDay; potentialTimeSlot = potentialTimeSlot.AddMinutes(30))
                    {

                        if (!IsTimeSlotBooked(doctorId, potentialTimeSlot))
                    {
                        if (potentialTimeSlot > DateTime.Now)
                        {
                            availableSlots.Add(new SelectListItem
                            {
                                Value = potentialTimeSlot.ToString("yyyy-MM-dd HH:mm"),
                                Text = potentialTimeSlot.ToString("yyyy-MM-dd hh:mm tt")
                            });
                        }
                    }
                }

                currentDate = currentDate.AddDays(1);
            }

            return availableSlots;
        }

        private bool IsTimeSlotBooked(string doctorId, DateTime timeSlot)
        {
            return _applicationDBcontext.DoctorAppointmentVIsit
                .Any(da => da.DoctorId == doctorId && da.Appointment.CreateDate == timeSlot);
        }


        //public List<SelectListItem> AvailableAppointments(string id)
        //{
        //    // Get the doctor's existing appointments
        //    var doctorExistingAppointments = new HashSet<DateTime>(_applicationDBcontext.DoctorAppointmentVIsit
        //        .Where(da => da.DoctorId == id)
        //        .Select(da => da.Appointment.CreateDate));

        //    var availableSlots = new List<SelectListItem>();

        //    // Define the start time for appointments
        //    DateTime startTime = DateTime.Today.AddHours(12); // Starting from 12:00 PM today

        //    DateTime currentDate = DateTime.Now.Date; // Today's date
        //    DateTime futureDate = currentDate.AddDays(7); // Consider available slots for the next 7 days

        //    while (currentDate <= futureDate)
        //    {
        //        for (int i = 0; i < 24; i++)
        //        {
        //            DateTime potentialTimeSlot = currentDate.AddDays(1).AddHours(i).AddMinutes(i * 30);

        //            // Check if the potentialTimeSlot is not booked for this doctor only
        //            if (!doctorExistingAppointments.Contains(potentialTimeSlot) &&
        //             ! _applicationDBcontext.DoctorAppointmentVIsit.  Any(da => da.Appointment.CreateDate == potentialTimeSlot))
        //            {
        //                // Check if the potentialTimeSlot is in the future
        //                if (potentialTimeSlot > DateTime.Now)
        //                {
        //                    availableSlots.Add(new SelectListItem
        //                    {
        //                        Value = potentialTimeSlot.ToString("yyyy-MM-dd HH:mm"),
        //                        Text = potentialTimeSlot.ToString("yyyy-MM-dd hh:mm tt")
        //                    });
        //                }
        //            }
        //        }

        //        currentDate = currentDate.AddDays(1); // Move to the next day
        //    }

        //    return availableSlots;
        //}
         
        public List<SelectListItem> StatusDoctorInSystem()
        {
            return Enum.GetValues(typeof(Cofimationdoctor))
                        .Cast<Cofimationdoctor>()
                        .Select(hour => new SelectListItem
                        {
                            Value = ((int)hour).ToString(),
                            Text = hour.ToString()
                        })
                        .ToList();
        }

        public IQueryable<SelectListItem> DAyWeekId()
        {
            IQueryable<SelectListItem>? DAyWeekId = _applicationDBcontext.weekDays.Select(x => new SelectListItem { Value = x.WeekDaysId.ToString(), Text = x.WeekDaysName });
            return DAyWeekId;
        }
        #endregion

        //public List<SelectListItem> availableSlots()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<SelectListItem> avilabledoctoronsift()
        //{
        //    throw new NotImplementedException();
        //}


    }
}


































