using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

namespace hospitalIrepreatory
{
    public interface Ilookup
    {
        IQueryable<SelectListItem> getdoctorid(string id);

        IQueryable<SelectListItem> HospitalsId();
        IQueryable<SelectListItem> DAyWeekId();
        //List<SelectListItem> GetHoursListAmstarted();
        //List<SelectListItem> GetHoursListAmFinhed();
        //List<SelectListItem> FormalEndingShift();
        List<SelectListItem> Shifts();
        public IQueryable<SelectListItem> allpatient();

        IQueryable<SelectListItem> PatientbyId(string id);

        //List<SelectListItem> FormalStartingShift();
        //List<SelectListItem> GetHoursListPmstarted();
        //List<SelectListItem> GetHoursListPmfinsied();
        List<SelectListItem> avilabledoctoronsift();
       List<SelectListItem> StatusDoctorInSystem();
        List<SelectListItem> Gender();
        List<SelectListItem> Doctorspicialist();
        List<SelectListItem> jop();
        List<SelectListItem> viststuts();
        List<SelectListItem> AvailableAppointments(string id , int chosendy=7);

        IQueryable<SelectListItem> getdoctorfromapplicationuserid();

    }
}