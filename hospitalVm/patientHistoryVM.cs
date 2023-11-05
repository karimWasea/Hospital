using Dataaccesslayer;

using System.ComponentModel.DataAnnotations.Schema;

namespace hospitalVm
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PatientHistoryVm
    {
        //[Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "PatientId is required.")]
        public string? PatientId { get; set; }

        [Required(ErrorMessage = "PatientName is required.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "VisitDate is required.")]
        public DateTime VisitDate { get; set; }

        [Required(ErrorMessage = "ChiefComplaint is required.")]
        public string ChiefComplaint { get; set; }

        [Required(ErrorMessage = "HistoryOfPresentIllness is required.")]
        public string HistoryOfPresentIllness { get; set; }

        [Required(ErrorMessage = "PastMedicalHistory is required.")]
        public string PastMedicalHistory { get; set; }

        [Required(ErrorMessage = "FamilyHistory is required.")]
        public string FamilyHistory { get; set; }

        [Required(ErrorMessage = "PhysicalExamination is required.")]
        public string PhysicalExamination { get; set; }

        [Required(ErrorMessage = "Assessment is required.")]
        public string Assessment { get; set; }

        [Required(ErrorMessage = "Plan is required.")]
        public string Plan { get; set; }

        [Required(ErrorMessage = "Medications is required.")]
        public string Medications { get; set; }

        [Required(ErrorMessage = "Allergies is required.")]
        public string Allergies { get; set; }

        [Required(ErrorMessage = "LabResults is required.")]
        public string LabResults { get; set; }

        [Required(ErrorMessage = "IsDeleted is required.")]
        public IsDeleted IsDeleted { get; set; }

        [Required(ErrorMessage = "IsFollowUp is required.")]
        public bool IsFollowUp { get; set; }






        public static PatientHistory CanconvertViewmodel(PatientHistoryVm PatientHistory)
        {
            return new PatientHistory
            {

                PhysicalExamination= PatientHistory.PhysicalExamination,

                PatientId = PatientHistory.PatientId,
                Id = PatientHistory.Id,
                Allergies = PatientHistory.Allergies,
                LabResults = PatientHistory.LabResults,
                IsFollowUp = PatientHistory.IsFollowUp,
                Assessment = PatientHistory.Assessment,
                Plan = PatientHistory.Plan,
                ChiefComplaint = PatientHistory.ChiefComplaint,
                FamilyHistory = PatientHistory.FamilyHistory,
                IsDeleted = PatientHistory.IsDeleted,
                VisitDate = PatientHistory.VisitDate,
                HistoryOfPresentIllness = PatientHistory.HistoryOfPresentIllness,
                 Medications = PatientHistory.Medications,
                 PastMedicalHistory= PatientHistory.PastMedicalHistory,





            };
        }


    }

    
}