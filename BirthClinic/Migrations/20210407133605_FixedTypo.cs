using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicApp.Migrations
{
    public partial class FixedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_birthRooms_birthClinics_BirthClinicID",
                table: "birthRooms");

            migrationBuilder.DropColumn(
                name: "BirthClinitID",
                table: "birthRooms");

            migrationBuilder.AlterColumn<int>(
                name: "BirthClinicID",
                table: "birthRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_birthRooms_birthClinics_BirthClinicID",
                table: "birthRooms",
                column: "BirthClinicID",
                principalTable: "birthClinics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_birthRooms_birthClinics_BirthClinicID",
                table: "birthRooms");

            migrationBuilder.AlterColumn<int>(
                name: "BirthClinicID",
                table: "birthRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BirthClinitID",
                table: "birthRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_birthRooms_birthClinics_BirthClinicID",
                table: "birthRooms",
                column: "BirthClinicID",
                principalTable: "birthClinics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
