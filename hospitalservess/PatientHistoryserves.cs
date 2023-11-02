 using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class PatientHistoryserves : PaginationHelper<PatientHistoryVm>, IGenericRepository<PatientHistoryVm> ,IPatientHistory
    {

        UserManager<ApplicationUser> _userManager;

        private ApplicationDBcontext _db;
        public PatientHistoryserves(ApplicationDBcontext db ,UserManager<ApplicationUser> userManager
 )        {

            _db = db;
            _userManager = userManager;
        }










     


        public void Save(PatientHistoryVm entity)
        {


            var model = PatientHistoryVm.CanconvertViewmodel(entity);


            

                if (entity.Id > 0)
                { 


                _db.PatientHistory.Update(model);

                _db.SaveChanges();

                 }
            else
                {


                _db.PatientHistory.Add(model);
                 
                _db.SaveChanges();

            


            }
        }





        public IEnumerable<PatientHistoryVm> GetAll()
        {
            var model = _db.PatientHistory.Include(p=>p.Patient).
                Where(p=> p.IsDeleted == IsDeleted.NotDeleted).Select(PatientHistory => new PatientHistoryVm
            {



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
                PastMedicalHistory = PatientHistory.PastMedicalHistory,
                PatientName = PatientHistory.Patient.UserName,


            }) .ToList();

            return model;
        }

        public PatientHistoryVm GetById(int id)
        {

            var model = _db.PatientHistory.Where(p=>p.Id==id &&p.IsDeleted==IsDeleted.NotDeleted).Include(p => p.Patient).Select(PatientHistory => new PatientHistoryVm
            {
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
                PastMedicalHistory = PatientHistory.PastMedicalHistory,
                PatientName = PatientHistory.Patient.UserName,

            }).FirstOrDefault();

            return model;
        }

    












        #region pagnation


      
        

    public IEnumerable<PatientHistoryVm> GetallPatientHistory(string id)
    {

            var model = _db.PatientHistory.Where(PatientHistory => PatientHistory.PatientId == id && PatientHistory.IsDeleted == IsDeleted.NotDeleted).Include(PatientHistory => PatientHistory.Patient).Select(PatientHistory => new PatientHistoryVm
            {

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
                PastMedicalHistory = PatientHistory.PastMedicalHistory,
                 PatientName= PatientHistory.Patient.UserName,



            }).ToList();

        return model;
    

            #endregion


        }


        public void Delete(int id)
        {
            var model = GetById(id);



            model.IsDeleted = IsDeleted.Deleted;
            Save(model);
            //var mode = _db. DoctorAppointmentVIsit.Find(id);


            //_db.DoctorAppointmentVIsit.Remove(mode);
            //_db.SaveChanges();



        }

    }

}
