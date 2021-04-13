using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinic.Migrations
{
    public partial class RemovedBirthToClinician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clinicians_births_BirthId",
                table: "clinicians");

            migrationBuilder.DropIndex(
                name: "IX_clinicians_BirthId",
                table: "clinicians");

            migrationBuilder.DropColumn(
                name: "BirthId",
                table: "clinicians");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirthId",
                table: "clinicians",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_clinicians_BirthId",
                table: "clinicians",
                column: "BirthId");

            migrationBuilder.AddForeignKey(
                name: "FK_clinicians_births_BirthId",
                table: "clinicians",
                column: "BirthId",
                principalTable: "births",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
