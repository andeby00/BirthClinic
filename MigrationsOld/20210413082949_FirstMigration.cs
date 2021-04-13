using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinic.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_birthRooms_birthClinics_BirthClinicID",
                table: "birthRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_births_birthRooms_BirthRoomID",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildParent_children_ChildId",
                table: "ChildParent");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildParent_parents_ParentsId",
                table: "ChildParent");

            migrationBuilder.DropForeignKey(
                name: "FK_children_births_BirthId",
                table: "children");

            migrationBuilder.DropForeignKey(
                name: "FK_clinicians_birthClinics_BirthClinicId",
                table: "clinicians");

            migrationBuilder.DropForeignKey(
                name: "FK_clinicians_shifts_ShiftId",
                table: "clinicians");

            migrationBuilder.DropForeignKey(
                name: "FK_maternityRooms_birthClinics_BirthClinicId",
                table: "maternityRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_parents_births_birthId",
                table: "parents");

            migrationBuilder.DropForeignKey(
                name: "FK_parents_maternityRooms_MaternityRoomId",
                table: "parents");

            migrationBuilder.DropForeignKey(
                name: "FK_parents_restRooms_RestRoomId",
                table: "parents");

            migrationBuilder.DropForeignKey(
                name: "FK_restRooms_birthClinics_BirthClinicId",
                table: "restRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_shifts_birthClinics_ClinicId",
                table: "shifts");

            migrationBuilder.DropTable(
                name: "birthClinics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shifts",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_ClinicId",
                table: "shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_restRooms",
                table: "restRooms");

            migrationBuilder.DropIndex(
                name: "IX_restRooms_BirthClinicId",
                table: "restRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parents",
                table: "parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_maternityRooms",
                table: "maternityRooms");

            migrationBuilder.DropIndex(
                name: "IX_maternityRooms_BirthClinicId",
                table: "maternityRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clinicians",
                table: "clinicians");

            migrationBuilder.DropIndex(
                name: "IX_clinicians_BirthClinicId",
                table: "clinicians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_children",
                table: "children");

            migrationBuilder.DropPrimaryKey(
                name: "PK_births",
                table: "births");

            migrationBuilder.DropPrimaryKey(
                name: "PK_birthRooms",
                table: "birthRooms");

            migrationBuilder.DropIndex(
                name: "IX_birthRooms_BirthClinicID",
                table: "birthRooms");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "shifts");

            migrationBuilder.DropColumn(
                name: "BirthClinicId",
                table: "restRooms");

            migrationBuilder.DropColumn(
                name: "BirthClinicId",
                table: "maternityRooms");

            migrationBuilder.DropColumn(
                name: "BirthClinicId",
                table: "clinicians");

            migrationBuilder.DropColumn(
                name: "BirthClinicID",
                table: "birthRooms");

            migrationBuilder.RenameTable(
                name: "shifts",
                newName: "shift");

            migrationBuilder.RenameTable(
                name: "restRooms",
                newName: "restRoom");

            migrationBuilder.RenameTable(
                name: "parents",
                newName: "parent");

            migrationBuilder.RenameTable(
                name: "maternityRooms",
                newName: "maternityRoom");

            migrationBuilder.RenameTable(
                name: "clinicians",
                newName: "clinician");

            migrationBuilder.RenameTable(
                name: "children",
                newName: "child");

            migrationBuilder.RenameTable(
                name: "births",
                newName: "birth");

            migrationBuilder.RenameTable(
                name: "birthRooms",
                newName: "birthRoom");

            migrationBuilder.RenameColumn(
                name: "birthId",
                table: "parent",
                newName: "BirthId");

            migrationBuilder.RenameIndex(
                name: "IX_parents_RestRoomId",
                table: "parent",
                newName: "IX_parent_RestRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_parents_MaternityRoomId",
                table: "parent",
                newName: "IX_parent_MaternityRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_parents_birthId",
                table: "parent",
                newName: "IX_parent_BirthId");

            migrationBuilder.RenameIndex(
                name: "IX_clinicians_ShiftId",
                table: "clinician",
                newName: "IX_clinician_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_children_BirthId",
                table: "child",
                newName: "IX_child_BirthId");

            migrationBuilder.RenameColumn(
                name: "SceduledTime",
                table: "birth",
                newName: "ScheduledTime");

            migrationBuilder.RenameIndex(
                name: "IX_births_BirthRoomID",
                table: "birth",
                newName: "IX_birth_BirthRoomID");

            migrationBuilder.AddColumn<int>(
                name: "BirthId",
                table: "clinician",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_shift",
                table: "shift",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_restRoom",
                table: "restRoom",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parent",
                table: "parent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_maternityRoom",
                table: "maternityRoom",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clinician",
                table: "clinician",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_child",
                table: "child",
                column: "ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_birth",
                table: "birth",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_birthRoom",
                table: "birthRoom",
                column: "BirthRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_clinician_BirthId",
                table: "clinician",
                column: "BirthId");

            migrationBuilder.AddForeignKey(
                name: "FK_birth_birthRoom_BirthRoomID",
                table: "birth",
                column: "BirthRoomID",
                principalTable: "birthRoom",
                principalColumn: "BirthRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_child_birth_BirthId",
                table: "child",
                column: "BirthId",
                principalTable: "birth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildParent_child_ChildId",
                table: "ChildParent",
                column: "ChildId",
                principalTable: "child",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildParent_parent_ParentsId",
                table: "ChildParent",
                column: "ParentsId",
                principalTable: "parent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clinician_birth_BirthId",
                table: "clinician",
                column: "BirthId",
                principalTable: "birth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_clinician_shift_ShiftId",
                table: "clinician",
                column: "ShiftId",
                principalTable: "shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_parent_birth_BirthId",
                table: "parent",
                column: "BirthId",
                principalTable: "birth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_birth_birthRoom_BirthRoomID",
                table: "birth");

            migrationBuilder.DropForeignKey(
                name: "FK_child_birth_BirthId",
                table: "child");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildParent_child_ChildId",
                table: "ChildParent");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildParent_parent_ParentsId",
                table: "ChildParent");

            migrationBuilder.DropForeignKey(
                name: "FK_clinician_birth_BirthId",
                table: "clinician");

            migrationBuilder.DropForeignKey(
                name: "FK_clinician_shift_ShiftId",
                table: "clinician");

            migrationBuilder.DropForeignKey(
                name: "FK_parent_birth_BirthId",
                table: "parent");

            migrationBuilder.DropForeignKey(
                name: "FK_parent_maternityRoom_MaternityRoomId",
                table: "parent");

            migrationBuilder.DropForeignKey(
                name: "FK_parent_restRoom_RestRoomId",
                table: "parent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shift",
                table: "shift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_restRoom",
                table: "restRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parent",
                table: "parent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_maternityRoom",
                table: "maternityRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clinician",
                table: "clinician");

            migrationBuilder.DropIndex(
                name: "IX_clinician_BirthId",
                table: "clinician");

            migrationBuilder.DropPrimaryKey(
                name: "PK_child",
                table: "child");

            migrationBuilder.DropPrimaryKey(
                name: "PK_birthRoom",
                table: "birthRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_birth",
                table: "birth");

            migrationBuilder.DropColumn(
                name: "BirthId",
                table: "clinician");

            migrationBuilder.RenameTable(
                name: "shift",
                newName: "shifts");

            migrationBuilder.RenameTable(
                name: "restRoom",
                newName: "restRooms");

            migrationBuilder.RenameTable(
                name: "parent",
                newName: "parents");

            migrationBuilder.RenameTable(
                name: "maternityRoom",
                newName: "maternityRooms");

            migrationBuilder.RenameTable(
                name: "clinician",
                newName: "clinicians");

            migrationBuilder.RenameTable(
                name: "child",
                newName: "children");

            migrationBuilder.RenameTable(
                name: "birthRoom",
                newName: "birthRooms");

            migrationBuilder.RenameTable(
                name: "birth",
                newName: "births");

            migrationBuilder.RenameColumn(
                name: "BirthId",
                table: "parents",
                newName: "birthId");

            migrationBuilder.RenameIndex(
                name: "IX_parent_RestRoomId",
                table: "parents",
                newName: "IX_parents_RestRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_parent_MaternityRoomId",
                table: "parents",
                newName: "IX_parents_MaternityRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_parent_BirthId",
                table: "parents",
                newName: "IX_parents_birthId");

            migrationBuilder.RenameIndex(
                name: "IX_clinician_ShiftId",
                table: "clinicians",
                newName: "IX_clinicians_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_child_BirthId",
                table: "children",
                newName: "IX_children_BirthId");

            migrationBuilder.RenameColumn(
                name: "ScheduledTime",
                table: "births",
                newName: "SceduledTime");

            migrationBuilder.RenameIndex(
                name: "IX_birth_BirthRoomID",
                table: "births",
                newName: "IX_births_BirthRoomID");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "shifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthClinicId",
                table: "restRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthClinicId",
                table: "maternityRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthClinicId",
                table: "clinicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthClinicID",
                table: "birthRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_shifts",
                table: "shifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_restRooms",
                table: "restRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parents",
                table: "parents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_maternityRooms",
                table: "maternityRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clinicians",
                table: "clinicians",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_children",
                table: "children",
                column: "ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_birthRooms",
                table: "birthRooms",
                column: "BirthRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_births",
                table: "births",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "birthClinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birthClinics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shifts_ClinicId",
                table: "shifts",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_restRooms_BirthClinicId",
                table: "restRooms",
                column: "BirthClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_maternityRooms_BirthClinicId",
                table: "maternityRooms",
                column: "BirthClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_clinicians_BirthClinicId",
                table: "clinicians",
                column: "BirthClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_birthRooms_BirthClinicID",
                table: "birthRooms",
                column: "BirthClinicID");

            migrationBuilder.AddForeignKey(
                name: "FK_birthRooms_birthClinics_BirthClinicID",
                table: "birthRooms",
                column: "BirthClinicID",
                principalTable: "birthClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_births_birthRooms_BirthRoomID",
                table: "births",
                column: "BirthRoomID",
                principalTable: "birthRooms",
                principalColumn: "BirthRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildParent_children_ChildId",
                table: "ChildParent",
                column: "ChildId",
                principalTable: "children",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildParent_parents_ParentsId",
                table: "ChildParent",
                column: "ParentsId",
                principalTable: "parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_children_births_BirthId",
                table: "children",
                column: "BirthId",
                principalTable: "births",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clinicians_birthClinics_BirthClinicId",
                table: "clinicians",
                column: "BirthClinicId",
                principalTable: "birthClinics",
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
                name: "FK_maternityRooms_birthClinics_BirthClinicId",
                table: "maternityRooms",
                column: "BirthClinicId",
                principalTable: "birthClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_parents_births_birthId",
                table: "parents",
                column: "birthId",
                principalTable: "births",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_parents_maternityRooms_MaternityRoomId",
                table: "parents",
                column: "MaternityRoomId",
                principalTable: "maternityRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_parents_restRooms_RestRoomId",
                table: "parents",
                column: "RestRoomId",
                principalTable: "restRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_restRooms_birthClinics_BirthClinicId",
                table: "restRooms",
                column: "BirthClinicId",
                principalTable: "birthClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shifts_birthClinics_ClinicId",
                table: "shifts",
                column: "ClinicId",
                principalTable: "birthClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
