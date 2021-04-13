using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinic.Migrations
{
    public partial class AddedShifts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clinicians_births_BirthId",
                table: "clinicians");

            migrationBuilder.AlterColumn<int>(
                name: "BirthId",
                table: "clinicians",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_clinicians_births_BirthId",
                table: "clinicians",
                column: "BirthId",
                principalTable: "births",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clinicians_births_BirthId",
                table: "clinicians");

            migrationBuilder.AlterColumn<int>(
                name: "BirthId",
                table: "clinicians",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_clinicians_births_BirthId",
                table: "clinicians",
                column: "BirthId",
                principalTable: "births",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
