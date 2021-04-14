using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinic.Migrations
{
    public partial class UpdateToReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parent_maternityRoom_MaternityRoomId",
                table: "parent");

            migrationBuilder.DropForeignKey(
                name: "FK_parent_restRoom_RestRoomId",
                table: "parent");

            migrationBuilder.DropIndex(
                name: "IX_parent_MaternityRoomId",
                table: "parent");

            migrationBuilder.DropIndex(
                name: "IX_parent_RestRoomId",
                table: "parent");

            migrationBuilder.DropColumn(
                name: "MaternityRoomId",
                table: "parent");

            migrationBuilder.DropColumn(
                name: "RestRoomId",
                table: "parent");

            migrationBuilder.AddColumn<int>(
                name: "MaternityRoomID",
                table: "birth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestRoomID",
                table: "birth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_birth_MaternityRoomID",
                table: "birth",
                column: "MaternityRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_birth_RestRoomID",
                table: "birth",
                column: "RestRoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_birth_maternityRoom_MaternityRoomID",
                table: "birth",
                column: "MaternityRoomID",
                principalTable: "maternityRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_birth_restRoom_RestRoomID",
                table: "birth",
                column: "RestRoomID",
                principalTable: "restRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_birth_maternityRoom_MaternityRoomID",
                table: "birth");

            migrationBuilder.DropForeignKey(
                name: "FK_birth_restRoom_RestRoomID",
                table: "birth");

            migrationBuilder.DropIndex(
                name: "IX_birth_MaternityRoomID",
                table: "birth");

            migrationBuilder.DropIndex(
                name: "IX_birth_RestRoomID",
                table: "birth");

            migrationBuilder.DropColumn(
                name: "MaternityRoomID",
                table: "birth");

            migrationBuilder.DropColumn(
                name: "RestRoomID",
                table: "birth");

            migrationBuilder.AddColumn<int>(
                name: "MaternityRoomId",
                table: "parent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestRoomId",
                table: "parent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_parent_MaternityRoomId",
                table: "parent",
                column: "MaternityRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_parent_RestRoomId",
                table: "parent",
                column: "RestRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_parent_maternityRoom_MaternityRoomId",
                table: "parent",
                column: "MaternityRoomId",
                principalTable: "maternityRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_parent_restRoom_RestRoomId",
                table: "parent",
                column: "RestRoomId",
                principalTable: "restRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
