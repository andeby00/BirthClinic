using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "birthClinics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birthClinics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "birthRooms",
                columns: table => new
                {
                    BirthRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    BirthClinicID = table.Column<int>(type: "int", nullable: true),
                    BirthClinitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birthRooms", x => x.BirthRoomId);
                    table.ForeignKey(
                        name: "FK_birthRooms_birthClinics_BirthClinicID",
                        column: x => x.BirthClinicID,
                        principalTable: "birthClinics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clinicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthClinicId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clinicians_birthClinics_BirthClinicId",
                        column: x => x.BirthClinicId,
                        principalTable: "birthClinics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "maternityRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    BirthClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maternityRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_maternityRooms_birthClinics_BirthClinicId",
                        column: x => x.BirthClinicId,
                        principalTable: "birthClinics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "restRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    BirthClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_restRooms_birthClinics_BirthClinicId",
                        column: x => x.BirthClinicId,
                        principalTable: "birthClinics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "births",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthRoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_births", x => x.Id);
                    table.ForeignKey(
                        name: "FK_births_birthRooms_BirthRoomID",
                        column: x => x.BirthRoomID,
                        principalTable: "birthRooms",
                        principalColumn: "BirthRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "children",
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
                    table.PrimaryKey("PK_children", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_children_births_BirthId",
                        column: x => x.BirthId,
                        principalTable: "births",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestRoomId = table.Column<int>(type: "int", nullable: true),
                    MaternityRoomId = table.Column<int>(type: "int", nullable: true),
                    BirthId = table.Column<int>(type: "int", nullable: true),
                    ChildId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parents_births_BirthId",
                        column: x => x.BirthId,
                        principalTable: "births",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_parents_children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_parents_maternityRooms_MaternityRoomId",
                        column: x => x.MaternityRoomId,
                        principalTable: "maternityRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_parents_restRooms_RestRoomId",
                        column: x => x.RestRoomId,
                        principalTable: "restRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_birthRooms_BirthClinicID",
                table: "birthRooms",
                column: "BirthClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_births_BirthRoomID",
                table: "births",
                column: "BirthRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_children_BirthId",
                table: "children",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_clinicians_BirthClinicId",
                table: "clinicians",
                column: "BirthClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_maternityRooms_BirthClinicId",
                table: "maternityRooms",
                column: "BirthClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_parents_BirthId",
                table: "parents",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_parents_ChildId",
                table: "parents",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_parents_MaternityRoomId",
                table: "parents",
                column: "MaternityRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_parents_RestRoomId",
                table: "parents",
                column: "RestRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_restRooms_BirthClinicId",
                table: "restRooms",
                column: "BirthClinicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clinicians");

            migrationBuilder.DropTable(
                name: "parents");

            migrationBuilder.DropTable(
                name: "children");

            migrationBuilder.DropTable(
                name: "maternityRooms");

            migrationBuilder.DropTable(
                name: "restRooms");

            migrationBuilder.DropTable(
                name: "births");

            migrationBuilder.DropTable(
                name: "birthRooms");

            migrationBuilder.DropTable(
                name: "birthClinics");
        }
    }
}
