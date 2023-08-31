using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{

    public class ApplicationDBcontext


    : IdentityDbContext
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        {

        }
        public DbSet<TimingShifts> TimingShifts { get; set; }
        public DbSet<PatientHistory> PatientHistory { get; set; }
        public DbSet<WeekDays> weekDays { get; set; }
        public DbSet<DoctorDaywork> doctorDayworks { get; set; }
        public DbSet<DoctorTimingShift> DoctorTimingShift { get; set; }
        // public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Apointment> Apointment { get; set; }
        //   public DbSet<Doctor> Doctors { get; set; }
        //public DbSet<Patient>  Patients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineReport> MedicineReport { get; set; }
        public DbSet<payroll> GetPayrolls { get; set; }
        public DbSet<prescribmedicine> Prescribmedicines { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Room> GetRooms { get; set; }
        public DbSet<testprice> Testprices { get; set; }
        public DbSet<patientreport> Patientreports { get; set; }
        public DbSet<suplier> Supliers { get; set; }
        public DbSet<DoctorAppointmentVIsit> DoctorAppointmentVIsit { get; set; }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //           // Apply TPC to each entity type
        //         //  modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
        //          //  modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        //            //modelBuilder.Entity<IdentityUser
        //            //    >().UseTpcMappingStrategy(); ;
        ////modelBuilder.Entity<Patient>().UseTpcMappingStrategy(); ;
        //            base.OnModelCreating(modelBuilder);

        //        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorAppointmentVIsit>()
                .HasOne(dav => dav.Doctor)
                .WithMany() // Assuming there's no collection property in ApplicationUser that relates back to DoctorAppointmentVIsit
                .HasForeignKey(dav => dav.DoctorId); // Assuming DoctorId is the foreign key property



            base.OnModelCreating(modelBuilder);
            }
            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{


            //var userid = Guid.NewGuid().ToString();
            //var useradminid = Guid.NewGuid().ToString();
            //var RoleuserId = Guid.NewGuid().ToString();
            //var RoleSuperAdminId = Guid.NewGuid().ToString();
            //var RoleAdminId = Guid.NewGuid().ToString();



            //modelBuilder.Entity<IdentityRole>().HasData(


            //new IdentityRole()
            //{
            //    Id = RoleAdminId,


            //    Name = "Admin",
            //    NormalizedName = "admin",
            //    ConcurrencyStamp = RoleAdminId,

            //},


            //new IdentityRole()
            //{
            //    Id = RoleSuperAdminId,


            //    Name = "SuperAdmin",
            //    NormalizedName = "SuperAdmin",
            //    ConcurrencyStamp = RoleSuperAdminId,

            //},
            //new IdentityRole()
            //{
            //    Id = RoleuserId,


            //    Name = "User",
            //    NormalizedName = "user",

            //    ConcurrencyStamp = RoleuserId,
            //}



            //);
            //}

        }
    }
