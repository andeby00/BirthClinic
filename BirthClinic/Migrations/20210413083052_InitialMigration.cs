using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinic.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "birthRoom",
                columns: table => new
                {
                    BirthRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birthRoom", x => x.BirthRoomId);
                });

            migrationBuilder.CreateTable(
                name: "maternityRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maternityRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "restRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "birth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ended = table.Column<int>(type: "int", nullable: true),
                    ScheduledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthRoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_birth_birthRoom_BirthRoomID",
                        column: x => x.BirthRoomID,
                        principalTable: "birthRoom",
                        principalColumn: "BirthRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "child",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeathAtBirth = table.Column<bool>(type: "bit", nullable: false),
                    BirthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_child_birth_BirthId",
                        column: x => x.BirthId,
                        principalTable: "birth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clinician",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    BirthId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinician", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clinician_birth_BirthId",
                        column: x => x.BirthId,
                        principalTable: "birth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clinician_shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestRoomId = table.Column<int>(type: "int", nullable: true),
                    MaternityRoomId = table.Column<int>(type: "int", nullable: true),
                    BirthId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parent_birth_BirthId",
                        column: x => x.BirthId,
                        principalTable: "birth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_parent_maternityRoom_MaternityRoomId",
                        column: x => x.MaternityRoomId,
                        principalTable: "maternityRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_parent_restRoom_RestRoomId",
                        column: x => x.RestRoomId,
                        principalTable: "restRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        name: "FK_ChildParent_child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "child",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildParent_parent_ParentsId",
                        column: x => x.ParentsId,
                        principalTable: "parent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_birth_BirthRoomID",
                table: "birth",
                column: "BirthRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_child_BirthId",
                table: "child",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildParent_ParentsId",
                table: "ChildParent",
                column: "ParentsId");

            migrationBuilder.CreateIndex(
                name: "IX_clinician_BirthId",
                table: "clinician",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_clinician_ShiftId",
                table: "clinician",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_parent_BirthId",
                table: "parent",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_parent_MaternityRoomId",
                table: "parent",
                column: "MaternityRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_parent_RestRoomId",
                table: "parent",
                column: "RestRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildParent");

            migrationBuilder.DropTable(
                name: "clinician");

            migrationBuilder.DropTable(
                name: "child");

            migrationBuilder.DropTable(
                name: "parent");

            migrationBuilder.DropTable(
                name: "shift");

            migrationBuilder.DropTable(
                name: "birth");

            migrationBuilder.DropTable(
                name: "maternityRoom");

            migrationBuilder.DropTable(
                name: "restRoom");

            migrationBuilder.DropTable(
                name: "birthRoom");
        }
    }
}
