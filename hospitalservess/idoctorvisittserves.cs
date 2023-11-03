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

    public class idoctorvisittserves : PaginationHelper<ApointmentVm>, Idoctorvist
    {
        UserManager<ApplicationUser> _userManager;

        private ApplicationDBcontext _db;
        public idoctorvisittserves(ApplicationDBcontext db ,UserManager<ApplicationUser> userManager
 )        {
            _db = db;
            _userManager = userManager;
        }
















        public void Save(ApointmentVm entity)
        {













            var model = ApointmentVm.CanconvertViewmodeldoctorvisite(entity);


            
                var upitedappiontment = _db.Apointment.Where(i => i.id == entity.id).FirstOrDefault();

                if (entity.DoctorAppointmentVIsitid > 0)
            { 



                if (entity.id > 0)
                {
                    upitedappiontment.CreateDate=entity.CreateDate;
                    upitedappiontment.discreaption = entity.discreaption;
                    upitedappiontment.id = entity.id;

                    //var app = ApointmentVm.CanconvertViewmodel(upitedappiontment);
                   
                    _db.Apointment.Update(upitedappiontment);
                    _db.SaveChanges();


                }
                _db.DoctorAppointmentVIsit.Update(model);

                _db.SaveChanges();


            }
            else
            {

                if ( entity.id!= upitedappiontment.id)
                {
                    var app2 = ApointmentVm.CanconvertViewmodel(entity);
                    _db.Apointment.Add(app2);
                    _db.SaveChanges();

                }


                _db.DoctorAppointmentVIsit.Add(model);
                 
                _db.SaveChanges();

            


            }
        }





        public IEnumerable<ApointmentVm> GetAll()
        {
            var model = _db.DoctorAppointmentVIsit.Where(p=> p.IsDeleted == IsDeleted.NotDeleted).Include(p => p.Appointment).Include(p => p.Doctor ).Include(p => p.patient).Select(p => new ApointmentVm
            {

                  DoctorAppointmentVIsitid=p.Id,
                  patientid=p.patientid,
                  doctorid=p.DoctorId,
                id = (int)p.AppointmentId,
                VisitStatus=p.visitStatus,
                 DoctorName=p.Doctor.UserName,
                 PatientName=p.patient.UserName,
                CreateDate = p.Appointment.CreateDate,
                VisitType=p.VisitType,
                isdeleted=p.IsDeleted,
                




            }).OrderBy(i=>i.CreateDate);

            return model;
        }

        public ApointmentVm GetById(int id)
        {

            var model = _db.DoctorAppointmentVIsit.Where(p=>p.Id==id &&p.IsDeleted==IsDeleted.NotDeleted). Include(p => p.Appointment).Include(p => p.Doctor).Include(p => p.patient).Select(p => new ApointmentVm
            {
                DoctorAppointmentVIsitid = p.Id,
                patientid = p.patientid,
                doctorid = p.DoctorId,
                id = p.AppointmentId,
                VisitStatus = p.visitStatus,
                DoctorName = p.Doctor.UserName,
                PatientName = p.patient.UserName,
                CreateDate = p.Appointment.CreateDate,
                VisitType = p.VisitType,
                VisiteNotebydoctor
                =p.VisiteNotebydoctor,

            }).FirstOrDefault();

            return model;
        }













        


        public void Delete(int id)
        {





            var mode = _db.DoctorAppointmentVIsit.Find(id);

            _db.DoctorAppointmentVIsit.Remove(mode);
            var apiontment = _db.Apointment.Find(mode.Appointment.id);
            _db.Remove(apiontment);
            _db.SaveChanges();



        }

        public IPagedList<ApointmentVm> GettAllVistitsByDoctorid(string id, int? pageNumber, string searchTerm = null)
        {
            var searchTermLower = searchTerm?.ToLower();
            int pageNum = pageNumber ?? 1;

            var doctorAppointments = _db.DoctorAppointmentVIsit.Where(i=>i.Doctor.RoleRegeseter==RoleRegeseter.Doctor).Include(i=>i.Doctor).Include(i=>i.Doctor).Include(i=>i.Appointment)
                .Where(a => a.DoctorId == id &&
                    (string.IsNullOrWhiteSpace(searchTerm) ||
                    EF.Functions.Like(a.Doctor.UserName, "%" + searchTermLower + "%") ||
                    EF.Functions.Like(a.patient.UserName, "%" + searchTermLower + "%")))
                .Select(p => new ApointmentVm
                {
                    DoctorAppointmentVIsitid = p.Id,
                    discreaption = p.Appointment.discreaption,
                    DoctorName = p.Doctor.UserName,
                    PatientName = p.patient.UserName,
                    CreateDate = p.Appointment.CreateDate,
                    VisitType = p.VisitType,
                    patientid = p.patientid,
                    doctorid = p.DoctorId,
                    VisitStatus = p.visitStatus,
                    VisiteNotebydoctor = p.VisiteNotebydoctor
                }).OrderBy(i => i.CreateDate);

    


            var paglist = GetPagedData(doctorAppointments, pageNum);

            return paglist;
        }


        public IPagedList<ApointmentVm> GetAllVistitsbyPatientid(string id, int? pagnumber, string searchTerm = null)
        {
            var searchTermLower = searchTerm?.ToLower();
            int pageNum = pagnumber ?? 1;

            var doctorAppointments = _db.DoctorAppointmentVIsit.Include(i => i.Doctor).Include(i => i.Doctor).Include(i => i.Appointment)
                .Where(a => a.patientid == id &&
                    (string.IsNullOrWhiteSpace(searchTerm) ||
                    EF.Functions.Like(a.Doctor.UserName, "%" + searchTermLower + "%") ||
                    EF.Functions.Like(a.patient.UserName, "%" + searchTermLower + "%")))
                .Select(p => new ApointmentVm
                {
                    DoctorAppointmentVIsitid = p.Id,
                    discreaption = p.Appointment.discreaption,
                    DoctorName = p.Doctor.UserName,
                    PatientName = p.patient.UserName,
                    CreateDate = p.Appointment.CreateDate,
                    VisitType = p.VisitType,
                    patientid = p.patientid,
                    doctorid = p.DoctorId,
                    VisitStatus = p.visitStatus,
                    VisiteNotebydoctor = p.VisiteNotebydoctor
                }).OrderBy(i => i.CreateDate)
                ;

  


            var paglist = GetPagedData(doctorAppointments, pageNum);

            return paglist;
        }

        public IPagedList<ApointmentVm> GetAllVaisits(int? pagnumber, string searchTerm = null)
        {
            var searchTermLower = searchTerm?.ToLower();
            int pageNum = pagnumber ?? 1;

            var doctorAppointments = _db.DoctorAppointmentVIsit
                .Include(i => i.Doctor)
                .Include(i => i.Appointment)
                .Where(a =>
                    string.IsNullOrWhiteSpace(searchTerm) ||
                    EF.Functions.Like(a.Doctor.UserName, "%" + searchTermLower + "%") ||
                    EF.Functions.Like(a.patient.UserName, "%" + searchTermLower + "%"))
                .Select(p => new ApointmentVm
                { DoctorAppointmentVIsitid=p.Id,
                    discreaption= p.Appointment.discreaption,
                    DoctorName = p.Doctor.UserName,
                    PatientName = p.patient.UserName,
                    CreateDate = p.Appointment.CreateDate,
                    VisitType = p.VisitType,
                    patientid = p.patientid,
                    doctorid = p.DoctorId,
                    VisitStatus=p.visitStatus,
                    VisiteNotebydoctor =p.VisiteNotebydoctor
                }).OrderBy(i => i.CreateDate);

            var paglist = GetPagedData(doctorAppointments, pageNum);

            return paglist;
        }

     

    }

}
