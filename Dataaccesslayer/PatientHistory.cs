using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;


namespace Dataaccesslayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PatientHistory
    {
        public int Id { get; set; }

        //[Required]
        public string PatientId { get; set; }

        //[/*Required*/]
        public DateTime  VisitDate { get; set; }

        //[MaxLength(500)]
        public string  ChiefComplaint { get; set; }

        //[MaxLength(1000)]
        public string HistoryOfPresentIllness { get; set; }

        //[MaxLength(1000)]
        public string   PastMedicalHistory { get; set; }

        //[MaxLength(1000)]
        public string FamilyHistory { get; set; }

        //[MaxLength(500)]
        public string PhysicalExamination { get; set; }

        //[MaxLength(5/00)]
        public string   Assessment { get; set; }

        //[MaxLength(1000)]
        public string  Plan { get; set; }

        //[MaxLength(1000)]
        public string  Medications { get; set; }

        //[MaxLength(500)]
        public string  Allergies { get; set; }

        //[MaxLength(500)]
        public string LabResults { get; set; }
        public IsDeleted  IsDeleted { get; set; }

        public bool IsFollowUp { get; set; }

        // Navigation property to link to the patient
        [ForeignKey("PatientId")]
        public ApplicationUser Patient { get; set; }
    }

    

}
