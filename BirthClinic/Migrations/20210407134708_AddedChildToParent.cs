using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinic.Migrations
{
    public partial class AddedChildToParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parents_children_ChildId",
                table: "parents");

            migrationBuilder.DropIndex(
                name: "IX_parents_ChildId",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "parents");

            migrationBuilder.CreateTable(
                name: "ChildParent",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    ParentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildParent", x => new { x.ChildId, x.ParentsId });
                    table.ForeignKey(
                        name: "FK_ChildParent_children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildParent_parents_ParentsId",
                        column: x => x.ParentsId,
                        principalTable: "parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildParent_ParentsId",
                table: "ChildParent",
                column: "ParentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildParent");

            migrationBuilder.AddColumn<int>(
                name: "ChildId",
                table: "parents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_parents_ChildId",
                table: "parents",
                column: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_parents_children_ChildId",
                table: "parents",
                column: "ChildId",
                principalTable: "children",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
