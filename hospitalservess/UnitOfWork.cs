 using Dataaccesslayer;
using hospitalIrepreatory;

using hospitalVm;

using Microsoft.AspNetCore.Identity;

namespace hospitalservess
{
    public class UnitOfWork : IUnitOfWork
    {

       public readonly ApplicationDBcontext _context;
        public readonly UserManager<ApplicationUser> _userManager;
        public lookupServess _lookupServess;

        public UnitOfWork(Hospitalserves hospitalserves , lookupServess lookupServess, RoleService roleService,Roomserves roomserves , Contactserves contactserves,
            PatientHistoryserves patientHistoryserves ,

            ApplicationDBcontext context   , timingShiftservess timingShiftservess ,
            Apointmentserves apointmentserves , Applicationuserserves applicationuserserves , Doctorserves doctorserves 
             , DoctorDayworkserves doctorDayworkserves , patientreportserves patientreportserves , Patientserves patientserves  ,idoctorvisittserves idoctorvisittserves
           , UserManager<ApplicationUser> userManager
            )

        {
            _lookupServess = lookupServess;
            _userManager = userManager;  
           roleS = roleService;
             Patient = patientserves;
            idoctodayworinweek = doctorDayworkserves;
             genericRepositoryDoctorDaywork = doctorDayworkserves;
            Contact = contactserves;
            RepositoryContact = contactserves;
            RepositoryRoom = roomserves;
            IRoom = roomserves;
            RepositoryHospitsl = hospitalserves;
            Ihospital = hospitalserves;
            _context = context;
            Ilookup = lookupServess;
            genericRepositorytimshift = timingShiftservess;
            ItimingSHift = timingShiftservess;
            Apointment=apointmentserves;
genericRepositoryAppiontment=apointmentserves;  
           // Applicationuser= applicationuserserves;
            Doctor = doctorserves;
            Idoctorvist = idoctorvisittserves;
                GenericRepositoryvisit = idoctorvisittserves;
             genericRepositorypatientreport = patientreportserves;
            patientHistory = patientHistoryserves;

            GetGenericpatientHistory = patientHistoryserves;
        }

        #region Implement the Dispose method to release resources
        private bool disposed = false;

        public IGenericRepository<HospitalVm> RepositoryHospitsl { get; }
        public IGenericRepository<RoomVm> RepositoryRoom { get; }
        public IGenericRepository<ContactVm> RepositoryContact { get; }
        public IGenericRepository<timingshiftVm>   genericRepositorytimshift { get; }
        public Ihospital Ihospital { get; }
        public IContact Contact { get; }
        public IRoom IRoom { get; }
        public Ilookup Ilookup { get; }
        public ItimingShift ItimingSHift { get; }
        public IGenericRepository<ApointmentVm> genericRepositoryAppiontment { get; }
        public Apointmentservesses Apointment { get; }
        public IApplicationuser Applicationuser { get; }
        public IGenericRepository<ApplicationuserVm> GenericRepositoryApplicationuser { get; }
        public IDoctor Doctor { get; }
        public IGenericRepository<DoctorVm> genericRepositoryDoctor { get; }
        public Idoctodayworinweek idoctodayworinweek { get; }
        public IGenericRepository<DoctorDayworkVM> genericRepositoryDoctorDaywork { get; }
        public IGenericRepository<patientreportVm> genericRepositorypatientreport { get; }
        public IPatient Patient { get; }
        public Idoctorvist Idoctorvist  { get; }
        public IGenericRepository<ApointmentVm> GenericRepositoryvisit { get; }
        public IGenericRepository<PatientHistoryVm> GetGenericpatientHistory { get; }
        public IPatientHistory patientHistory  { get; }
        public IRoleS roleS { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




        // Implement the finalizer to release unmanaged resources
        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion

















    }
}