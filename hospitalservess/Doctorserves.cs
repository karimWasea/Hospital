﻿using Dataaccesslayer;
using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Newtonsoft.Json.Linq;

using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Security.Policy;

namespace hospitalservess
{

    public class Doctorserves : PaginationHelper<DoctorVm>,IDoctor
    {
        Imgoeration _lookupServess;
        private readonly UserManager<ApplicationUser> _user;
        Idoctodayworinweek idoctodayworinweek;


        private ApplicationDBcontext _db;
        public Doctorserves(ApplicationDBcontext db, UserManager<ApplicationUser> user , Imgoeration lookupServess , DoctorDayworkserves doctorDayworkserves )
        {
            idoctodayworinweek = doctorDayworkserves;
            _lookupServess = lookupServess;
            _user = user;
            _db = db;
        }
    
















        public async Task Save(DoctorVm entity)
        {
            var model = DoctorVm.CanconvertViewmodel(entity);

            if (entity.id != null)
            {
                // Update existing entity
                var existingUser = await _user.FindByIdAsync(entity.id);
             
                // Update properties of existingUser
                existingUser.Salary = entity.Salary;
                    existingUser.Nationality = entity.Nationality;
                    existingUser.spicialist = entity.spicialist;
                    existingUser.Title=entity.Title; existingUser.WorkingDaysinWeek=entity.WorkingDaysinWeek;  
                    existingUser.Contracturl=entity.Contracturl;
                     existingUser.HiringDate=entity.HiringDate;
                     existingUser.Email=entity.Email;
                     existingUser.Gender=entity.Gender;
                     existingUser.RoleRegeseter=entity.RoleRegeseter;
                     existingUser.HiringDate=entity.HiringDate;
                     existingUser.imphgurl=entity.imphgurl;
                     existingUser.PhoneNumber=entity.Phonenumber;
                     existingUser.PostalCode=entity.PostalCode;
                     existingUser.StreetAddress=entity.StreetAddress;
                     existingUser.UserName=entity.username;

                if (entity.imgurlupdated == null)


                {
                    existingUser.imphgurl = _user.Users.Where(x => x.Id == entity.id).Select(e => e.imphgurl).FirstOrDefault();
                }
                else
                {

                   existingUser.imphgurl = _lookupServess.Uploadimg(entity.imgurlupdated);
                }



                existingUser.statusDoctorInSystem = entity.StatusDoctorInSystem;

                 
                        var updateResult = await _user.UpdateAsync(existingUser);
                       
                        await _db.SaveChangesAsync();
                    }
            else
            {

                var updateResult = await _user.CreateAsync(model);

                await _db.SaveChangesAsync();   
            }
          
        }



        public async Task<bool> Delete(string id)
        {
            try
            {
               var listworkdays=  _db.doctorDayworks.Where(i => i.DoctorId == id).Select(i => i).ToList();
                _db.doctorDayworks.RemoveRange(listworkdays);
                _db.SaveChanges();
                var user = await _user.FindByIdAsync(id);
                
                if (user != null)
                {
                    var roles = await _user.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        await _user.RemoveFromRoleAsync(user, role);
                    }

                    var result = await _user.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        await _db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        // Handle user deletion failure
                        foreach (var error in result.Errors)
                        {
                            // Log or handle each error message
                        }
                        return false;
                    }
                }
                else
                {
                    // Handle user not found
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // Log the exception details for troubleshooting
                return false;
            }
        }
        public async Task<IEnumerable<DoctorVm>> GetallconfirmedDoctor()
    {
            var _users = await _user.Users.Where(ApplicationUser => ApplicationUser.RoleRegeseter == RoleRegeseter.Doctor&& ApplicationUser.statusDoctorInSystem == Cofimationdoctor.Confirmed).Select(ApplicationUser => new DoctorVm
            {
                id = ApplicationUser.Id,
                username = ApplicationUser.UserName,

                Email = ApplicationUser.Email,
                RoleRegeseter = ApplicationUser.RoleRegeseter,
                Gender = ApplicationUser.Gender,
                StreetAddress = ApplicationUser.StreetAddress,
                City = ApplicationUser.City,
                Dateofbarth = ApplicationUser.Dateofbarth,
                Phonenumber = ApplicationUser.PhoneNumber,
                Nationality = ApplicationUser.Nationality,
                imphgurl = ApplicationUser.imphgurl,
                PostalCode = ApplicationUser.PostalCode,
                Title = ApplicationUser.Title,
                HiringDate = ApplicationUser.HiringDate,
                Contracturl = ApplicationUser.Contracturl,
                StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

                WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                Salary = ApplicationUser.Salary,



            }).ToListAsync();

            return _users;
        }
        
        public async Task<DoctorVm>GetByIdasRegisterdoctor(string id)
        {
            var model =await
             _user.Users.Where(p => p.Id == id && p.statusDoctorInSystem == Cofimationdoctor.Regeseter).Select(ApplicationUser => new DoctorVm
            {
                id = ApplicationUser.Id,
                username = ApplicationUser.UserName,

                Email = ApplicationUser.Email,
                RoleRegeseter = ApplicationUser.RoleRegeseter,
                Gender = ApplicationUser.Gender,
                StreetAddress = ApplicationUser.StreetAddress,
                City = ApplicationUser.City,
                Dateofbarth = ApplicationUser.Dateofbarth,
                Phonenumber = ApplicationUser.PhoneNumber,
                Nationality = ApplicationUser.Nationality,
                imphgurl = ApplicationUser.imphgurl,
                PostalCode = ApplicationUser.PostalCode,
                Title = ApplicationUser.Title,
                HiringDate = ApplicationUser.HiringDate,
                Contracturl = ApplicationUser.Contracturl,
                StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

                WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                Salary = ApplicationUser.Salary,





            }).FirstOrDefaultAsync();
            return model;   
        }



        public async Task<IEnumerable<DoctorVm>> GetAllDoctorRegester()
        {
            // && ApplicationUser.statusDoctorInSystem == Cofimationdoctor.Regeseter
            var _users = await _user.Users.Where(ApplicationUser => ApplicationUser.RoleRegeseter == RoleRegeseter.Doctor && ApplicationUser.statusDoctorInSystem == Cofimationdoctor.Regeseter).Select(ApplicationUser => new DoctorVm
            {


                id = ApplicationUser.Id,
                username = ApplicationUser.UserName,

                Email = ApplicationUser.Email,
                RoleRegeseter = ApplicationUser.RoleRegeseter,
                Gender = ApplicationUser.Gender,
                StreetAddress = ApplicationUser.StreetAddress,
                City = ApplicationUser.City,
                Dateofbarth = ApplicationUser.Dateofbarth,
                Phonenumber = ApplicationUser.PhoneNumber,
                Nationality = ApplicationUser.Nationality,
                imphgurl = ApplicationUser.imphgurl,
                PostalCode = ApplicationUser.PostalCode,
                StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,
                spicialist = ApplicationUser.spicialist,






            }).ToListAsync();
            return _users;
        }

        public async Task<DoctorVm> GetByIdasconfirmed(string id)
        {
      // && p.statusDoctorInSystem == Cofimationdoctor.Regeseter
            var model = await
             _user.Users.Where(p => p.Id == id ).Select(ApplicationUser => new DoctorVm
             {
                 id = ApplicationUser.Id,
                 username = ApplicationUser.UserName,

                 Email = ApplicationUser.Email,
                 RoleRegeseter = ApplicationUser.RoleRegeseter,
                 Gender = ApplicationUser.Gender,
                 StreetAddress = ApplicationUser.StreetAddress,
                 City = ApplicationUser.City,
                 Dateofbarth = ApplicationUser.Dateofbarth,
                 Phonenumber = ApplicationUser.PhoneNumber,
                 Nationality = ApplicationUser.Nationality,
                 imphgurl = ApplicationUser.imphgurl,
                 PostalCode = ApplicationUser.PostalCode,
                 Title = ApplicationUser.Title,
                 HiringDate = ApplicationUser.HiringDate,
                 Contracturl = ApplicationUser.Contracturl,
                 StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

                 WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                 Salary = ApplicationUser.Salary,





             }).FirstOrDefaultAsync();
            return model;
        }
        public async Task<IEnumerable<DoctorVm>> Search(string searchTerm = null)
        {
            var searchTermLower = searchTerm?.ToLower();

            var doctorsList = await _user.Users
                .Where(a => a.RoleRegeseter == RoleRegeseter.Doctor &&
                            a.statusDoctorInSystem == Cofimationdoctor.Confirmed &&
                            (string.IsNullOrWhiteSpace(searchTerm) ||
                            EF.Functions.Like(a.UserName, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.StreetAddress, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.City, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Email, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Title, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Nationality, "%" + searchTermLower + "%")))
                .Select(ApplicationUser => new DoctorVm
                {
                    id = ApplicationUser.Id,
                    username = ApplicationUser.UserName,
                    Email = ApplicationUser.Email,
                    RoleRegeseter = ApplicationUser.RoleRegeseter,
                    Gender = ApplicationUser.Gender,
                    StreetAddress = ApplicationUser.StreetAddress,
                    City = ApplicationUser.City,
                    Dateofbarth = ApplicationUser.Dateofbarth,
                    Phonenumber = ApplicationUser.PhoneNumber,
                    Nationality = ApplicationUser.Nationality,
                    imphgurl = ApplicationUser.imphgurl,
                    PostalCode = ApplicationUser.PostalCode,
                    Title = ApplicationUser.Title,
                    HiringDate = ApplicationUser.HiringDate,
                    Contracturl = ApplicationUser.Contracturl,
                    StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,
                    WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                    Salary = ApplicationUser.Salary
                })
                .ToListAsync();

            return doctorsList;
        }



    }
}

