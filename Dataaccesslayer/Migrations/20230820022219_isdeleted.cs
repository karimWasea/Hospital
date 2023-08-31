using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dataaccesslayer.Migrations
{
    /// <inheritdoc />
    public partial class isdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "weekDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "TimingShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Testprices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Supliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Prescribmedicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Patientreports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "MedicineReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Labs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "GetRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "GetPayrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "DoctorTimingShift",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "doctorDayworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "DoctorAppointmentVIsit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "visitStatus",
                table: "DoctorAppointmentVIsit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "weekDays");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TimingShifts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Testprices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Supliers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Prescribmedicines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Patientreports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MedicineReport");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GetRooms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GetPayrolls");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorTimingShift");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "doctorDayworks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorAppointmentVIsit");

            migrationBuilder.DropColumn(
                name: "visitStatus",
                table: "DoctorAppointmentVIsit");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");
        }
    }
}
