using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dataaccesslayer.Migrations
{
    /// <inheritdoc />
    public partial class gf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctorDayworks_weekDays_WeekDaysId",
                table: "doctorDayworks");

            migrationBuilder.DropIndex(
                name: "IX_doctorDayworks_WeekDaysId",
                table: "doctorDayworks");

            migrationBuilder.DropColumn(
                name: "WeekDaysId",
                table: "doctorDayworks");

            migrationBuilder.CreateIndex(
                name: "IX_doctorDayworks_WeekDaystId",
                table: "doctorDayworks",
                column: "WeekDaystId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctorDayworks_weekDays_WeekDaystId",
                table: "doctorDayworks",
                column: "WeekDaystId",
                principalTable: "weekDays",
                principalColumn: "WeekDaysId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctorDayworks_weekDays_WeekDaystId",
                table: "doctorDayworks");

            migrationBuilder.DropIndex(
                name: "IX_doctorDayworks_WeekDaystId",
                table: "doctorDayworks");

            migrationBuilder.AddColumn<int>(
                name: "WeekDaysId",
                table: "doctorDayworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_doctorDayworks_WeekDaysId",
                table: "doctorDayworks",
                column: "WeekDaysId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctorDayworks_weekDays_WeekDaysId",
                table: "doctorDayworks",
                column: "WeekDaysId",
                principalTable: "weekDays",
                principalColumn: "WeekDaysId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
