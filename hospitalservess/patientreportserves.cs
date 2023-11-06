using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;
using hospitalUtilities.SystemEnums;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using PagedList;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class patientreportserves : PaginationHelper<patientreportVm> ,Ipatientreportserves
    {

        UserManager<ApplicationUser> _userManager;

        private ApplicationDBcontext _db;
        public patientreportserves(ApplicationDBcontext db, UserManager<ApplicationUser> userManager )
        { _db = db; _userManager = userManager;
        }












        public void Save(patientreportVm entity)
        {


            var model = patientreportVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
                _db.Patientreports.Update(model);

                _db.SaveChanges();


            }
            else
            {
                

                _db.Patientreports.Add(model);

                _db.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            var mode = GetById(id);

            mode.IsDeleted= IsDeleted.Deleted;
            Save(mode);

            //_db.Patientreports.Remove(mode);
            //_db.SaveChanges();



        }













        public IEnumerable<patientreportVm> GetAll()
        {
            var model = _db. Patientreports.Where(i=>i.IsDeleted==IsDeleted.NotDeleted).Select(p => new patientreportVm
            {


                patientName = _userManager.Users.Where(i => i.Id == p.patientid).Select(n => n.UserName).FirstOrDefault(),
                doctorname = _userManager.Users.Where(i => i.Id == p.doctorid).Select(n => n.UserName).FirstOrDefault(),

                dignouses = p.dignouses,
                DoctorAppointmentVIsitid = p.DoctorAppointmentVIsitid,
                doctorid = p.doctorid,
                patientid = p.patientid,
                id = p.id,
               IsDeleted  = p.IsDeleted,
               Reportdate=_db.DoctorAppointmentVIsit.Where(i=>i.patientid==p.patientid&&i.DoctorId==p.doctorid).Select(p=>p.Appointment.CreateDate).FirstOrDefault(),



            }).ToList();

            return model;
        }

        public patientreportVm GetById(int id)
        {
            return _db. Patientreports.Where(p => p.id == id && p.IsDeleted == IsDeleted.NotDeleted).Select(p => new patientreportVm
            {

 dignouses =p.dignouses,
  doctorid =p.doctorid,
    patientid=p.patientid,
    id =p.id,
    patientName=_userManager.Users.Where(i=>i.Id==p.patientid).Select(n=>n.UserName).FirstOrDefault(),
    doctorname=_userManager.Users.Where(i=>i.Id==p.doctorid).Select(n=>n.UserName).FirstOrDefault(),

                IsDeleted = p.IsDeleted,


                DoctorAppointmentVIsitid = p.DoctorAppointmentVIsitid,



            }).FirstOrDefault();
        }

        public IPagedList<patientreportVm> GetAllReportsbyPatientid(string patientid, int? pagnumber, string searchTerm = null)
        {
            var searchTermLower = searchTerm?.ToLower();
            int pageNum = pagnumber ?? 1;

            var doctorAppointments = _db.Patientreports.Include(i => i.doctor).Include(i => i.patient).Include(i => i.DoctorAppointmentVIsit)
                .Where(a => a.patientid==patientid &&
                    (string.IsNullOrWhiteSpace(searchTerm) ||
                    EF.Functions.Like(a.doctor.UserName, "%" + searchTermLower + "%") ||
                    EF.Functions.Like(a.patient.UserName, "%" + searchTermLower + "%")) || EF.Functions.Like(a.dignouses, "%" + searchTermLower + "%"))
                .Select(p => new patientreportVm
                {
                    patientName = p.patient.UserName,
                    doctorname = p.doctor.UserName,
                    dignouses = p.dignouses,
                    DoctorAppointmentVIsitid = p.DoctorAppointmentVIsitid,
                    doctorid = p.doctorid,
                    patientid = p.patientid,
                    id = p.id,
                    IsDeleted = p.IsDeleted,
                    Reportdate = _db.DoctorAppointmentVIsit.Where(i => i.patientid == p.patientid && i.DoctorId == p.doctorid).Select(p => p.Appointment.CreateDate).FirstOrDefault(),

                }).OrderBy(i => i.Reportdate);




            var paglist = GetPagedData(doctorAppointments, pageNum);

            return paglist;
        }

        public IPagedList<patientreportVm> Search(int? pagnumber, string searchTerm = null)
        {
            var searchTermLower = searchTerm?.ToLower();
            int pageNum = pagnumber ?? 1;

            var doctorAppointments = _db.Patientreports.Include(i => i.doctor).Include(i => i.patient).Include(i => i.DoctorAppointmentVIsit)
                .Where(a => 
                    (string.IsNullOrWhiteSpace(searchTerm) ||
                    EF.Functions.Like(a.doctor.UserName, "%" + searchTermLower + "%") ||
                    EF.Functions.Like(a.patient.UserName, "%" + searchTermLower + "%")) || EF.Functions.Like(a.dignouses, "%" + searchTermLower + "%")) 
                .Select(p => new patientreportVm
                {
                    patientName = p.patient.UserName,
                    doctorname = p.doctor.UserName,
                    dignouses = p.dignouses,
                    DoctorAppointmentVIsitid = p.DoctorAppointmentVIsitid,
                    doctorid = p.doctorid,
                    patientid = p.patientid,
                    id = p.id,
                    IsDeleted = p.IsDeleted,
                    Reportdate = _db.DoctorAppointmentVIsit.Where(i => i.patientid == p.patientid && i.DoctorId == p.doctorid).Select(p => p.Appointment.CreateDate).FirstOrDefault(),

                }).OrderBy(i => i.Reportdate);




            var paglist = GetPagedData(doctorAppointments, pageNum);

            return paglist;
        }
    }




}
