﻿// <auto-generated />
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
    [Migration("20210414092128_UpdateToReservations")]
    partial class UpdateToReservations
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

                    b.Property<int?>("Ended")
                        .HasColumnType("int");

                    b.Property<int>("MaternityRoomID")
                        .HasColumnType("int");

                    b.Property<int>("RestRoomID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BirthRoomID");

                    b.HasIndex("MaternityRoomID");

                    b.HasIndex("RestRoomID");

                    b.ToTable("birth");
                });

            modelBuilder.Entity("BirthClinic.Models.BirthRoom", b =>
                {
                    b.Property<int>("BirthRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("BirthRoomId");

                    b.ToTable("birthRoom");
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

                    b.ToTable("child");
                });

            modelBuilder.Entity("BirthClinic.Models.Clinician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BirthId")
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

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BirthId");

                    b.HasIndex("ShiftId");

                    b.ToTable("clinician");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Clinician");
                });

            modelBuilder.Entity("BirthClinic.Models.MaternityRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("maternityRoom");
                });

            modelBuilder.Entity("BirthClinic.Models.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BirthId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BirthId");

                    b.ToTable("parent");
                });

            modelBuilder.Entity("BirthClinic.Models.RestRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("restRoom");
                });

            modelBuilder.Entity("BirthClinic.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("shift");
                });

            modelBuilder.Entity("ChildParent", b =>
                {
                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("ParentsId")
                        .HasColumnType("int");

                    b.HasKey("ChildId", "ParentsId");

                    b.HasIndex("ParentsId");

                    b.ToTable("ChildParent");
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
                        .WithMany("Births")
                        .HasForeignKey("BirthRoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirthClinic.Models.MaternityRoom", "MaternityRoom")
                        .WithMany("Births")
                        .HasForeignKey("MaternityRoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirthClinic.Models.RestRoom", "RestRoom")
                        .WithMany("Births")
                        .HasForeignKey("RestRoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthRoom");

                    b.Navigation("MaternityRoom");

                    b.Navigation("RestRoom");
                });

            modelBuilder.Entity("BirthClinic.Models.Child", b =>
                {
                    b.HasOne("BirthClinic.Models.Birth", "Birth")
                        .WithMany("Children")
                        .HasForeignKey("BirthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Birth");
                });

            modelBuilder.Entity("BirthClinic.Models.Clinician", b =>
                {
                    b.HasOne("BirthClinic.Models.Birth", "Birth")
                        .WithMany("Clinicians")
                        .HasForeignKey("BirthId");

                    b.HasOne("BirthClinic.Models.Shift", "Shift")
                        .WithMany("Clinicians")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Birth");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("BirthClinic.Models.Parent", b =>
                {
                    b.HasOne("BirthClinic.Models.Birth", "Birth")
                        .WithMany("Parents")
                        .HasForeignKey("BirthId");

                    b.Navigation("Birth");
                });

            modelBuilder.Entity("ChildParent", b =>
                {
                    b.HasOne("BirthClinic.Models.Child", null)
                        .WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirthClinic.Models.Parent", null)
                        .WithMany()
                        .HasForeignKey("ParentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinic.Models.Birth", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Clinicians");

                    b.Navigation("Parents");
                });

            modelBuilder.Entity("BirthClinic.Models.BirthRoom", b =>
                {
                    b.Navigation("Births");
                });

            modelBuilder.Entity("BirthClinic.Models.MaternityRoom", b =>
                {
                    b.Navigation("Births");
                });

            modelBuilder.Entity("BirthClinic.Models.RestRoom", b =>
                {
                    b.Navigation("Births");
                });

            modelBuilder.Entity("BirthClinic.Models.Shift", b =>
                {
                    b.Navigation("Clinicians");
                });
#pragma warning restore 612, 618
        }
    }
}
