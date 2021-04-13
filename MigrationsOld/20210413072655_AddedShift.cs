using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinic.Migrations
{
    public partial class AddedShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parents_births_BirthId",
                table: "parents");

            migrationBuilder.RenameColumn(
                name: "BirthId",
                table: "parents",
                newName: "birthId");

            migrationBuilder.RenameIndex(
                name: "IX_parents_BirthId",
                table: "parents",
                newName: "IX_parents_birthId");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "births",
                newName: "SceduledTime");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "birthClinics",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "BirthId",
                table: "clinicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "clinicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ended",
                table: "births",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shifts_birthClinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "birthClinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clinicians_BirthId",
                table: "clinicians",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_clinicians_ShiftId",
                table: "clinicians",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_shifts_ClinicId",
                table: "shifts",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_clinicians_births_BirthId",
                table: "clinicians",
                column: "BirthId",
                principalTable: "births",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clinicians_shifts_ShiftId",
                table: "clinicians",
                column: "ShiftId",
                principalTable: "shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_parents_births_birthId",
                table: "parents",
                column: "birthId",
                principalTable: "births",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clinicians_births_BirthId",
                table: "clinicians");

            migrationBuilder.DropForeignKey(
                name: "FK_clinicians_shifts_ShiftId",
                table: "clinicians");

            migrationBuilder.DropForeignKey(
                name: "FK_parents_births_birthId",
                table: "parents");

            migrationBuilder.DropTable(
                name: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_clinicians_BirthId",
                table: "clinicians");

            migrationBuilder.DropIndex(
                name: "IX_clinicians_ShiftId",
                table: "clinicians");

            migrationBuilder.DropColumn(
                name: "BirthId",
                table: "clinicians");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "clinicians");

            migrationBuilder.DropColumn(
                name: "Ended",
                table: "births");

            migrationBuilder.RenameColumn(
                name: "birthId",
                table: "parents",
                newName: "BirthId");

            migrationBuilder.RenameIndex(
                name: "IX_parents_birthId",
                table: "parents",
                newName: "IX_parents_BirthId");

            migrationBuilder.RenameColumn(
                name: "SceduledTime",
                table: "births",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "birthClinics",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_parents_births_BirthId",
                table: "parents",
                column: "BirthId",
                principalTable: "births",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
