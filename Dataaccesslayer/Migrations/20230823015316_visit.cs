using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dataaccesslayer.Migrations
{
    /// <inheritdoc />
    public partial class visit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointmentVIsit_AspNetUsers_patientid",
                table: "DoctorAppointmentVIsit");

            migrationBuilder.AddColumn<int>(
                name: "DoctorAppointmentVIsitid",
                table: "Patientreports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "patientid",
                table: "DoctorAppointmentVIsit",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Patientreports_DoctorAppointmentVIsitid",
                table: "Patientreports",
                column: "DoctorAppointmentVIsitid");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointmentVIsit_AspNetUsers_patientid",
                table: "DoctorAppointmentVIsit",
                column: "patientid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patientreports_DoctorAppointmentVIsit_DoctorAppointmentVIsitid",
                table: "Patientreports",
                column: "DoctorAppointmentVIsitid",
                principalTable: "DoctorAppointmentVIsit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointmentVIsit_AspNetUsers_patientid",
                table: "DoctorAppointmentVIsit");

            migrationBuilder.DropForeignKey(
                name: "FK_Patientreports_DoctorAppointmentVIsit_DoctorAppointmentVIsitid",
                table: "Patientreports");

            migrationBuilder.DropIndex(
                name: "IX_Patientreports_DoctorAppointmentVIsitid",
                table: "Patientreports");

            migrationBuilder.DropColumn(
                name: "DoctorAppointmentVIsitid",
                table: "Patientreports");

            migrationBuilder.AlterColumn<string>(
                name: "patientid",
                table: "DoctorAppointmentVIsit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointmentVIsit_AspNetUsers_patientid",
                table: "DoctorAppointmentVIsit",
                column: "patientid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
