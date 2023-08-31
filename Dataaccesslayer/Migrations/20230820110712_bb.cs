using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dataaccesslayer.Migrations
{
    /// <inheritdoc />
    public partial class bb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChiefComplaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryOfPresentIllness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalExamination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_PatientId",
                table: "PatientHistory",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientHistory");
        }
    }
}
