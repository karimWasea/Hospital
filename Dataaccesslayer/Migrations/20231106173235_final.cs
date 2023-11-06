using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dataaccesslayer.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    discreaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentConfirmation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apointment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pplicynumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enddate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discreaption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coust = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prouductiondate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expireddate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TimingShifts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startshift = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Endsifit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: true),
                    Stutus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimingShifts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weekDays",
                columns: table => new
                {
                    WeekDaysId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDaysName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StratingAmShafit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPmShift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weekDays", x => x.WeekDaysId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    hospitalid = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contacts_Hospitals_hospitalid",
                        column: x => x.hospitalid,
                        principalTable: "Hospitals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    Hospitalid = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discraption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departments_Hospitals_Hospitalid",
                        column: x => x.Hospitalid,
                        principalTable: "Hospitals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GetRooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hospitalid = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stuts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetRooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_GetRooms_Hospitals_hospitalid",
                        column: x => x.hospitalid,
                        principalTable: "Hospitals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medicineId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    suplierid = table.Column<int>(type: "int", nullable: false),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prouductiondate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expireddate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineReport_Medicines_medicineId",
                        column: x => x.medicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineReport_Supliers_suplierid",
                        column: x => x.suplierid,
                        principalTable: "Supliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Contracturl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingDaysinWeek = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleRegeseter = table.Column<int>(type: "int", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imphgurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spicialist = table.Column<int>(type: "int", nullable: true),
                    statusDoctorInSystem = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateofbarth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Departmentid = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_Departmentid",
                        column: x => x.Departmentid,
                        principalTable: "Departments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    Chargedoctor = table.Column<int>(type: "int", nullable: false),
                    Chargemedicine = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Roomcharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    neringcharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Optioncharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    labcharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    advanc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalbill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nofdayes = table.Column<int>(type: "int", nullable: false),
                    patientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Insuranceid = table.Column<int>(type: "int", nullable: false),
                    numberbill = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bills_AspNetUsers_patientId",
                        column: x => x.patientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Insurances_Insuranceid",
                        column: x => x.Insuranceid,
                        principalTable: "Insurances",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorAppointmentVIsit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    patientid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VisiteNotebydoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisiteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VisitType = table.Column<int>(type: "int", nullable: false),
                    visitStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAppointmentVIsit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorAppointmentVIsit_Apointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Apointment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DoctorAppointmentVIsit_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DoctorAppointmentVIsit_AspNetUsers_patientid",
                        column: x => x.patientid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "doctorDayworks",
                columns: table => new
                {
                    DoctorDayworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeekDaystId = table.Column<int>(type: "int", nullable: false),
                    FormalStartingShift = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorDayworks", x => x.DoctorDayworkId);
                    table.ForeignKey(
                        name: "FK_doctorDayworks_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_doctorDayworks_weekDays_WeekDaystId",
                        column: x => x.WeekDaystId,
                        principalTable: "weekDays",
                        principalColumn: "WeekDaysId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DoctorTimingShift",
                columns: table => new
                {
                    DoctorTimingShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimingShiftId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTimingShift", x => x.DoctorTimingShiftId);
                    table.ForeignKey(
                        name: "FK_DoctorTimingShift_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DoctorTimingShift_TimingShifts_TimingShiftId",
                        column: x => x.TimingShiftId,
                        principalTable: "TimingShifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GetPayrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Netsalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    hoursalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bonassalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    compensalation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeIdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Accountantnumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetPayrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GetPayrolls_AspNetUsers_EmployeIdId",
                        column: x => x.EmployeIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    hight = table.Column<int>(type: "int", nullable: false),
                    wight = table.Column<int>(type: "int", nullable: false),
                    bloodpressur = table.Column<int>(type: "int", nullable: false),
                    temprature = table.Column<int>(type: "int", nullable: false),
                    labnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    testtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    testcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    testresult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patientid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Labs_AspNetUsers_patientid",
                        column: x => x.patientid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChiefComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoryOfPresentIllness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PastMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalExamination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assessment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    IsFollowUp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHistory_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Patientreports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dignouses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doctorid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    patientid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorAppointmentVIsitid = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patientreports", x => x.id);
                    table.ForeignKey(
                        name: "FK_Patientreports_AspNetUsers_doctorid",
                        column: x => x.doctorid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patientreports_AspNetUsers_patientid",
                        column: x => x.patientid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Patientreports_DoctorAppointmentVIsit_DoctorAppointmentVIsitid",
                        column: x => x.DoctorAppointmentVIsitid,
                        principalTable: "DoctorAppointmentVIsit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Testprices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labid = table.Column<int>(type: "int", nullable: false),
                    testcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tesstprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    billid = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testprices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Testprices_Bills_billid",
                        column: x => x.billid,
                        principalTable: "Bills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Testprices_Labs_labid",
                        column: x => x.labid,
                        principalTable: "Labs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Prescribmedicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicineid = table.Column<int>(type: "int", nullable: false),
                    Patientreportid = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescribmedicines", x => x.id);
                    table.ForeignKey(
                        name: "FK_Prescribmedicines_Medicines_Medicineid",
                        column: x => x.Medicineid,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Prescribmedicines_Patientreports_Patientreportid",
                        column: x => x.Patientreportid,
                        principalTable: "Patientreports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c55d1ab3-a02d-4af6-ad8f-41d57ee95bba", "c55d1ab3-a02d-4af6-ad8f-41d57ee95bba", "SuperAdmin", "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Contracturl", "Dateofbarth", "Departmentid", "Discriminator", "Email", "EmailConfirmed", "Gender", "HiringDate", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Nationality", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "RoleRegeseter", "Salary", "SecurityStamp", "StreetAddress", "Title", "TwoFactorEnabled", "UserName", "WorkingDaysinWeek", "imphgurl", "spicialist", "statusDoctorInSystem" },
                values: new object[] { "652c8825-368e-4dfc-85fa-a4db109933c9", 1, "cairo", "11/6/2023 7:32:33 PM", "SuperAdmin", new DateTime(2023, 11, 6, 19, 32, 33, 677, DateTimeKind.Local).AddTicks(2096), null, "ApplicationUser", "Karim.n.1995@gmail.com", false, 0, new DateTime(2023, 11, 6, 19, 32, 33, 677, DateTimeKind.Local).AddTicks(2168), 0, false, null, "", null, null, "Karim.n.1995@gmail.com", null, false, "", 1, 0.0m, "d5b2b103-cf88-490d-b216-2737f4c4bf05", "SuperAdmin", "SuperAdmin", false, "SuperAdmin", 0, "SuperAdmin", 2, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c55d1ab3-a02d-4af6-ad8f-41d57ee95bba", "652c8825-368e-4dfc-85fa-a4db109933c9" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Departmentid",
                table: "AspNetUsers",
                column: "Departmentid");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Insuranceid",
                table: "Bills",
                column: "Insuranceid");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_patientId",
                table: "Bills",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_hospitalid",
                table: "Contacts",
                column: "hospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Hospitalid",
                table: "Departments",
                column: "Hospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointmentVIsit_AppointmentId",
                table: "DoctorAppointmentVIsit",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointmentVIsit_DoctorId",
                table: "DoctorAppointmentVIsit",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointmentVIsit_patientid",
                table: "DoctorAppointmentVIsit",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_doctorDayworks_DoctorId",
                table: "doctorDayworks",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorDayworks_WeekDaystId",
                table: "doctorDayworks",
                column: "WeekDaystId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTimingShift_DoctorId",
                table: "DoctorTimingShift",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTimingShift_TimingShiftId",
                table: "DoctorTimingShift",
                column: "TimingShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_GetPayrolls_EmployeIdId",
                table: "GetPayrolls",
                column: "EmployeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_GetRooms_hospitalid",
                table: "GetRooms",
                column: "hospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_Labs_patientid",
                table: "Labs",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineReport_medicineId",
                table: "MedicineReport",
                column: "medicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineReport_suplierid",
                table: "MedicineReport",
                column: "suplierid");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_PatientId",
                table: "PatientHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patientreports_DoctorAppointmentVIsitid",
                table: "Patientreports",
                column: "DoctorAppointmentVIsitid");

            migrationBuilder.CreateIndex(
                name: "IX_Patientreports_doctorid",
                table: "Patientreports",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_Patientreports_patientid",
                table: "Patientreports",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_Prescribmedicines_Medicineid",
                table: "Prescribmedicines",
                column: "Medicineid");

            migrationBuilder.CreateIndex(
                name: "IX_Prescribmedicines_Patientreportid",
                table: "Prescribmedicines",
                column: "Patientreportid");

            migrationBuilder.CreateIndex(
                name: "IX_Testprices_billid",
                table: "Testprices",
                column: "billid");

            migrationBuilder.CreateIndex(
                name: "IX_Testprices_labid",
                table: "Testprices",
                column: "labid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "doctorDayworks");

            migrationBuilder.DropTable(
                name: "DoctorTimingShift");

            migrationBuilder.DropTable(
                name: "GetPayrolls");

            migrationBuilder.DropTable(
                name: "GetRooms");

            migrationBuilder.DropTable(
                name: "MedicineReport");

            migrationBuilder.DropTable(
                name: "PatientHistory");

            migrationBuilder.DropTable(
                name: "Prescribmedicines");

            migrationBuilder.DropTable(
                name: "Testprices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "weekDays");

            migrationBuilder.DropTable(
                name: "TimingShifts");

            migrationBuilder.DropTable(
                name: "Supliers");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Patientreports");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "DoctorAppointmentVIsit");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Apointment");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
