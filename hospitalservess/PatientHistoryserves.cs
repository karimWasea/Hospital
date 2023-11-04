 using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using PagedList;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class PatientHistoryserves : PaginationHelper<PatientHistoryVm>, IPatientHistory
    {

        UserManager<ApplicationUser> _userManager;

        private ApplicationDBcontext _db;
        public PatientHistoryserves(ApplicationDBcontext db, UserManager<ApplicationUser> userManager
 )
        {

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
                PatientName = PatientHistory.Patient.UserName,



            }).ToList();

            return model;





        }





        public void Delete(int id)
        {
            var mode = _db.PatientHistory.Find(id);


            _db.PatientHistory.Remove(mode);
            _db.SaveChanges();

        }

        public PatientHistoryVm GetById(int id)
        {
            var model = _db.PatientHistory.Where(p => p.Id == id && p.IsDeleted == IsDeleted.NotDeleted).Include(p => p.Patient).Select(PatientHistory => new PatientHistoryVm
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


        public IPagedList<PatientHistoryVm> Search(int? pagnumber, string searchTerm = null)
        {


            var searchTermLower = searchTerm?.ToLower();
            int pageNum = pagnumber ?? 1;

            var doctorAppointments = _db.PatientHistory.Include(a => a.Patient).
            Where(a =>
                   ( string.IsNullOrWhiteSpace(searchTerm) ||
                    EF.Functions.Like(a.HistoryOfPresentIllness, "%" + searchTermLower + "%")

                    ||
                    EF.Functions.Like(a.Allergies, "%" + searchTermLower + "%") ||
                    EF.Functions.Like(a.Plan, "%" + searchTermLower + "%") ||
                    EF.Functions.Like(a.LabResults, "%" + searchTermLower + "%"))



                    )
               .Select(PatientHistory => new PatientHistoryVm
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


               });
            var paglist = GetPagedData(doctorAppointments, pageNum);

            return paglist;
        }



        IPagedList<PatientHistoryVm> IPatientHistory.GetallPatientHistory(string Patientid, int? pagnumber, string searchTerm = null)
        {
            {
                var searchTermLower = searchTerm?.ToLower();
                int pageNum = pagnumber ?? 1;

                var doctorAppointments = _db.PatientHistory.Include(a => a.Patient).
                Where(a => a.PatientId == Patientid &&
                      (  string.IsNullOrWhiteSpace(searchTerm) ||
                        EF.Functions.Like(a.HistoryOfPresentIllness, "%" + searchTermLower + "%")

                        ||
                        EF.Functions.Like(a.Allergies, "%" + searchTermLower + "%") ||
                        EF.Functions.Like(a.Plan, "%" + searchTermLower + "%") ||
                        EF.Functions.Like(a.LabResults, "%" + searchTermLower + "%"))



                        )
                   .Select(PatientHistory => new PatientHistoryVm
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


                   });
                var paglists = GetPagedData(doctorAppointments, pageNum);

                return paglists;
            }
        }

    }
}
