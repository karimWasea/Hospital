using Dataaccesslayer;

using hospitalVm;

using Microsoft.Data.SqlClient;

namespace hospitalIrepreatory
{
    public interface IUnitOfWork : IDisposable
    { Idoctorvist Idoctorvist { get; }
                    IGenericRepository<ApointmentVm> GenericRepositoryvisit { get; }
        IRoleS roleS { get; }
        Idoctodayworinweek idoctodayworinweek {  get; }
            IGenericRepository<DoctorDayworkVM> genericRepositoryDoctorDaywork { get; }
        IPatientHistory patientHistory { get; }
        IDoctor Doctor { get; }
        IPatient  Patient { get; }
             IGenericRepository<DoctorVm> genericRepositoryDoctor { get; }  
             IGenericRepository<patientreportVm> genericRepositorypatientreport { get; }  
        IApplicationuser  Applicationuser { get; }
            IGenericRepository<ApplicationuserVm> GenericRepositoryApplicationuser { get; }
        IGenericRepository<HospitalVm> RepositoryHospitsl { get; }
        IGenericRepository<RoomVm> RepositoryRoom { get; }
    IGenericRepository<ContactVm> RepositoryContact { get; }
 IGenericRepository<timingshiftVm> genericRepositorytimshift { get; }
 IGenericRepository<ApointmentVm>  genericRepositoryAppiontment { get; }
        Ihospital Ihospital { get; }
        ItimingShift ItimingSHift { get; }
        IContact Contact { get; }
        IRoom IRoom { get; }
        Ilookup Ilookup { get; }
        Apointmentservesses Apointment { get; }
    }
}