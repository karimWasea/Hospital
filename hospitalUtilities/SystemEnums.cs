
using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;




namespace hospitalUtilities.SystemEnums
{
    public enum AppointmentConfirmation
    {
        [Display(Name = "Pending Confirmation")]
        PendingConfirmation = 0,

        [Display(Name = "Confirmed by Doctor")]
        ConfirmedByDoctor = 1,

        [Display(Name = "Cancelled by Doctor")]
        CancelledByDoctor = 2,

        [Display(Name = "Cancelled by Patient")]
        CancelledByPatient = 3,
    }
    public enum Gender
    {
        Male, femail, other
    }

    public enum Cofimationdoctor
    {
        Confirmed,
        pending,
        Refused,
        Regeseter


    }
    public enum SHifts
    {


        morinimgSiftfrrom8Amto5pm,
        nightSiftfrrom5pmto8Am
, HasNosifits

    }
    public enum Stutus
    {
        [Display(Name = " is Available")]
        Available = 1,

        [Display(Name = " is doctorleavework")]
        doctorleavework = 2,

        [Display(Name = " is Finsiedshift")]
        Finsiedshift = 3,
        [Display(Name = " is Notavilable")]

        Notavilable = 4

    }
    public enum VisitStatus
    {
        Scheduled,
        InProgress,
        Completed,
        Cancelled,
        Rescheduled,
        Postponed,
        NoShow,
        Arrived,
        Unknown
    }
    public enum IsDeleted
    {
        NotDeleted,
        Deleted
    }

    public enum VisitType
    {
        FirstVisit,

        FollowUpVisit,

        RegularCheckup,

        EmergencyVisit,

        // Add more visit types as needed
    }

    public enum RoleRegeseter
    {
        None,
        Doctor,
        Nurse,
        Receptionist,
        Employee,
        Patient

    };
    public enum spicialist
    {
        None,
        Emergency,
        Pediatrics,
        Surgery,
        InternalMedicine,
        ObstetricsGynecology
    }

}