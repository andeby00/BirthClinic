// <auto-generated />
using System;
using BirthClinic.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirthClinic.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210407133058_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirthClinic.Models.Birth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthRoomID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BirthRoomID");

                    b.ToTable("births");
                });

            modelBuilder.Entity("BirthClinic.Models.BirthClinic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("birthClinics");
                });

            modelBuilder.Entity("BirthClinic.Models.BirthRoom", b =>
                {
                    b.Property<int>("BirthRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BirthClinicID")
                        .HasColumnType("int");

                    b.Property<int>("BirthClinitID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("BirthRoomId");

                    b.HasIndex("BirthClinicID");

                    b.ToTable("birthRooms");
                });

            modelBuilder.Entity("BirthClinic.Models.Child", b =>
                {
                    b.Property<int>("ChildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthId")
                        .HasColumnType("int");

                    b.Property<bool>("DeathAtBirth")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChildId");

                    b.HasIndex("BirthId");

                    b.ToTable("children");
                });

            modelBuilder.Entity("BirthClinic.Models.Clinician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthClinicId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BirthClinicId");

                    b.ToTable("clinicians");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Clinician");
                });

            modelBuilder.Entity("BirthClinic.Models.MaternityRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthClinicId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BirthClinicId");

                    b.ToTable("maternityRooms");
                });

            modelBuilder.Entity("BirthClinic.Models.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BirthId")
                        .HasColumnType("int");

                    b.Property<int?>("ChildId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaternityRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("RestRoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BirthId");

                    b.HasIndex("ChildId");

                    b.HasIndex("MaternityRoomId");

                    b.HasIndex("RestRoomId");

                    b.ToTable("parents");
                });

            modelBuilder.Entity("BirthClinic.Models.RestRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthClinicId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BirthClinicId");

                    b.ToTable("restRooms");
                });

            modelBuilder.Entity("BirthClinic.Models.Doctor", b =>
                {
                    b.HasBaseType("BirthClinic.Models.Clinician");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("BirthClinic.Models.Midwife", b =>
                {
                    b.HasBaseType("BirthClinic.Models.Clinician");

                    b.HasDiscriminator().HasValue("Midwife");
                });

            modelBuilder.Entity("BirthClinic.Models.Nurse", b =>
                {
                    b.HasBaseType("BirthClinic.Models.Clinician");

                    b.HasDiscriminator().HasValue("Nurse");
                });

            modelBuilder.Entity("BirthClinic.Models.Secretary", b =>
                {
                    b.HasBaseType("BirthClinic.Models.Clinician");

                    b.HasDiscriminator().HasValue("Secretary");
                });

            modelBuilder.Entity("BirthClinic.Models.SocialHealthAss", b =>
                {
                    b.HasBaseType("BirthClinic.Models.Clinician");

                    b.HasDiscriminator().HasValue("SocialHealthAss");
                });

            modelBuilder.Entity("BirthClinic.Models.Birth", b =>
                {
                    b.HasOne("BirthClinic.Models.BirthRoom", "BirthRoom")
                        .WithMany("Birth")
                        .HasForeignKey("BirthRoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthRoom");
                });

            modelBuilder.Entity("BirthClinic.Models.BirthRoom", b =>
                {
                    b.HasOne("BirthClinic.Models.BirthClinic", "BirthClinic")
                        .WithMany("BirthRooms")
                        .HasForeignKey("BirthClinicID");

                    b.Navigation("BirthClinic");
                });

            modelBuilder.Entity("BirthClinic.Models.Child", b =>
                {
                    b.HasOne("BirthClinic.Models.Birth", "Birth")
                        .WithMany("Childs")
                        .HasForeignKey("BirthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Birth");
                });

            modelBuilder.Entity("BirthClinic.Models.Clinician", b =>
                {
                    b.HasOne("BirthClinic.Models.BirthClinic", "BirthClinic")
                        .WithMany("Clinicians")
                        .HasForeignKey("BirthClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthClinic");
                });

            modelBuilder.Entity("BirthClinic.Models.MaternityRoom", b =>
                {
                    b.HasOne("BirthClinic.Models.BirthClinic", "BirthClinic")
                        .WithMany("MaternityRooms")
                        .HasForeignKey("BirthClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthClinic");
                });

            modelBuilder.Entity("BirthClinic.Models.Parent", b =>
                {
                    b.HasOne("BirthClinic.Models.Birth", null)
                        .WithMany("Parent")
                        .HasForeignKey("BirthId");

                    b.HasOne("BirthClinic.Models.Child", null)
                        .WithMany("Parents")
                        .HasForeignKey("ChildId");

                    b.HasOne("BirthClinic.Models.MaternityRoom", "MaternityRoom")
                        .WithMany("Parents")
                        .HasForeignKey("MaternityRoomId");

                    b.HasOne("BirthClinic.Models.RestRoom", "RestRoom")
                        .WithMany("Parents")
                        .HasForeignKey("RestRoomId");

                    b.Navigation("MaternityRoom");

                    b.Navigation("RestRoom");
                });

            modelBuilder.Entity("BirthClinic.Models.RestRoom", b =>
                {
                    b.HasOne("BirthClinic.Models.BirthClinic", "BirthClinic")
                        .WithMany("RestRooms")
                        .HasForeignKey("BirthClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthClinic");
                });

            modelBuilder.Entity("BirthClinic.Models.Birth", b =>
                {
                    b.Navigation("Childs");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("BirthClinic.Models.BirthClinic", b =>
                {
                    b.Navigation("BirthRooms");

                    b.Navigation("Clinicians");

                    b.Navigation("MaternityRooms");

                    b.Navigation("RestRooms");
                });

            modelBuilder.Entity("BirthClinic.Models.BirthRoom", b =>
                {
                    b.Navigation("Birth");
                });

            modelBuilder.Entity("BirthClinic.Models.Child", b =>
                {
                    b.Navigation("Parents");
                });

            modelBuilder.Entity("BirthClinic.Models.MaternityRoom", b =>
                {
                    b.Navigation("Parents");
                });

            modelBuilder.Entity("BirthClinic.Models.RestRoom", b =>
                {
                    b.Navigation("Parents");
                });
#pragma warning restore 612, 618
        }
    }
}
