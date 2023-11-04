using Dataaccesslayer;

using System.ComponentModel.DataAnnotations.Schema;

namespace hospitalVm
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PatientHistoryVm
    {
        public int Id { get; set; }

        public string? PatientId { get; set; }

        public string PatientName { get; set; }

  
        public DateTime VisitDate { get; set; }

    
        public string ChiefComplaint { get; set; }

     
        public string HistoryOfPresentIllness { get; set; }

        public string PastMedicalHistory { get; set; }

        public string FamilyHistory { get; set; }

      
        public string PhysicalExamination { get; set; }

        public string Assessment { get; set; }

        public string Plan { get; set; }

        public string Medications { get; set; }

        public string Allergies { get; set; }

        public string LabResults { get; set; }

        public IsDeleted IsDeleted { get; set; }

     
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