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

    public class idoctorvisittserves : PaginationHelper<ApointmentVm>, IGenericRepository<ApointmentVm>, Idoctorvist
    {
        //Apointmentservesses  _apointment;
        UserManager<ApplicationUser> _userManager;

        private ApplicationDBcontext _db;
        public idoctorvisittserves(ApplicationDBcontext db ,UserManager<ApplicationUser> userManager
 )        {
            // GetApplicationuser = applicationuserserves;
            _db = db;
            _userManager = userManager;
        }










        public IEnumerable<ApointmentVm> GetAll(int pageNumber)
        {
            int pageSize = 10; // Set the page size to 10
            var model = _db.DoctorAppointmentVIsit
                .Include(p => p.Appointment)
                .Include(p => p.Doctor)
                .Include(p => p.patient)
                .Select(p => new ApointmentVm
                {
                    DoctorAppointmentVIsitid = p.Id,
                    patientid = p.patientid,
                    doctorid = p.DoctorId,
                    id = (int)p.AppointmentId,
                    VisitStatus = p.visitStatus,
                    DoctorName = p.Doctor.UserName,
                    PatientName = p.patient.UserName,
                    CreateDate = p.Appointment.CreateDate,
                    VisitType = p.VisitType,
                })
                .OrderByDescending(i => i.CreateDate.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return model;
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
                




            }).DefaultIfEmpty(). ToList().OrderBy(i=>i.CreateDate);

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

        //public Task ApointmentVm bydocid(string id)
        //{

        //    return _db.Doctors.Where(p => p.Id == id).Select(p => new ApointmentVm
        //    {
        //        doctorid =
        //    }).FirstOrDefault();
        //}








        //public ApointmentVm GetAvilablebydocid(string id)
        //{

        //    var _users =  _userManager.Users.Where(p => p.Id == id).Select(ap => new ApointmentVm
        //    {



        //        doctorid = ap.Id,
        //        doctorName = ap.UserName,

        //    }).FirstOrDefault();
        //    return _users;
        //}
















        #region pagnation


        public IEnumerable<ApointmentVm> GetBookingAppiontmentbydocid(string id)
        {





            var model = _db.DoctorAppointmentVIsit.Where(i => i.DoctorId == id &&i.IsDeleted==IsDeleted.NotDeleted).Select(p => new ApointmentVm
            {

                DoctorName = _userManager.Users.Where(i => i.Id == id).Select(i => i.UserName).FirstOrDefault(),

                PatientName = _userManager.Users.Where(i => i.Id == p.patientid).Select(i => i.UserName).FirstOrDefault(),

                CreateDate = _db.Apointment.Where(i => i.id == p.AppointmentId && p.DoctorId == id).Select(i => i.CreateDate).FirstOrDefault(),
                VisitType = p.VisitType,
                patientid = p.patientid,
                doctorid = id,


            }).ToList();
            return model;
        }

        public IEnumerable<ApointmentVm> getvistitsbydoctorid(string id)
        {
            var model = _db.DoctorAppointmentVIsit.Where(p=>p.DoctorId==id &&p.IsDeleted==IsDeleted.NotDeleted&&p.visitStatus!=VisitStatus.Cancelled).Include(p => p.Appointment).Include(p => p.Doctor).Include(p => p.patient).Select(p => new ApointmentVm
            {
                DoctorAppointmentVIsitid = p.Id,
                patientid = p.patientid,
                doctorid = p.DoctorId,
                id = (int)p.AppointmentId,
                VisitStatus = p.visitStatus,
                DoctorName = p.Doctor.UserName,
                PatientName = p.patient.UserName,
                CreateDate = p.Appointment.CreateDate,
                VisitType = p.VisitType,
                VisiteNotebydoctor
                = p.VisiteNotebydoctor,
            }).ToList().OrderBy(p=>p.VisitStatus==VisitStatus.Arrived);

            return model;
        }

        public IEnumerable<ApointmentVm> getvistitsbypatientid(string id)
        {
            var model = _db.DoctorAppointmentVIsit.Where(i=>i.patientid==id &&i.IsDeleted==IsDeleted.Deleted).Include(p => p.Appointment).Include(p => p.Doctor).Include(p => p.patient).Select(p => new ApointmentVm
            {
                DoctorAppointmentVIsitid = p.Id,
                patientid = p.patientid,
                doctorid = p.DoctorId,
                id = (int)p.AppointmentId,
                VisitStatus = p.visitStatus,
                DoctorName = p.Doctor.UserName,
                PatientName = p.patient.UserName,
                CreateDate = p.Appointment.CreateDate,
                VisitType = p.VisitType,
                VisiteNotebydoctor
                = p.VisiteNotebydoctor,
            }).ToList();

            return model;


            #endregion


        }


        public void Delete(int id)
        {
            var model = GetById(id);



            model.isdeleted = IsDeleted.Deleted;
            Save(model);
            //var mode = _db. DoctorAppointmentVIsit.Find(id);


            //_db.DoctorAppointmentVIsit.Remove(mode);
            //_db.SaveChanges();



        }

    }

}
