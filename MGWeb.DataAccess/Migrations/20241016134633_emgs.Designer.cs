﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMG.Data;

#nullable disable

namespace WebMG.Migrations
{
    [DbContext(typeof(MGDbContext))]
    [Migration("20241016134633_emgs")]
    partial class emgs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebMG.Models.AttendCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmpId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("SchoolDay")
                        .HasColumnType("date");

                    b.Property<int>("StuId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeOut")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpId");

                    b.HasIndex("ParId");

                    b.HasIndex("StuId");

                    b.ToTable("AttendCards");
                });

            modelBuilder.Entity("WebMG.Models.Emp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.Property<bool>("Teach")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Emps");
                });

            modelBuilder.Entity("WebMG.Models.Fam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParId");

                    b.ToTable("Fams");
                });

            modelBuilder.Entity("WebMG.Models.Par", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emg1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emg1Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emg1Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmgEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmgPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Par1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Par2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pars");
                });

            modelBuilder.Entity("WebMG.Models.Stu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("ClassCategory")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DOB")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("Disenroll")
                        .HasColumnType("date");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamId")
                        .HasColumnType("int");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FamId");

                    b.ToTable("Stus");
                });

            modelBuilder.Entity("WebMG.Models.TimeCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Finish")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("TimeCategory")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpId");

                    b.ToTable("TimeCards");
                });

            modelBuilder.Entity("WebMG.Models.AttendCard", b =>
                {
                    b.HasOne("WebMG.Models.Emp", "Emp")
                        .WithMany("AttendCards")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebMG.Models.Par", "Par")
                        .WithMany("AttendCards")
                        .HasForeignKey("ParId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WebMG.Models.Stu", "Stu")
                        .WithMany("AttendCards")
                        .HasForeignKey("StuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Emp");

                    b.Navigation("Par");

                    b.Navigation("Stu");
                });

            modelBuilder.Entity("WebMG.Models.Fam", b =>
                {
                    b.HasOne("WebMG.Models.Par", "Par")
                        .WithMany()
                        .HasForeignKey("ParId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Par");
                });

            modelBuilder.Entity("WebMG.Models.Stu", b =>
                {
                    b.HasOne("WebMG.Models.Fam", "Fam")
                        .WithMany("Stus")
                        .HasForeignKey("FamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fam");
                });

            modelBuilder.Entity("WebMG.Models.TimeCard", b =>
                {
                    b.HasOne("WebMG.Models.Emp", "Emp")
                        .WithMany("TimeCards")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Emp");
                });

            modelBuilder.Entity("WebMG.Models.Emp", b =>
                {
                    b.Navigation("AttendCards");

                    b.Navigation("TimeCards");
                });

            modelBuilder.Entity("WebMG.Models.Fam", b =>
                {
                    b.Navigation("Stus");
                });

            modelBuilder.Entity("WebMG.Models.Par", b =>
                {
                    b.Navigation("AttendCards");
                });

            modelBuilder.Entity("WebMG.Models.Stu", b =>
                {
                    b.Navigation("AttendCards");
                });
#pragma warning restore 612, 618
        }
    }
}
