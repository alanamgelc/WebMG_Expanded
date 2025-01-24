using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMG.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teach = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Par1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Par2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCategory = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeCards_Emps_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ParId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fams_Pars_ParId",
                        column: x => x.ParId,
                        principalTable: "Pars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    ClassCategory = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Disenroll = table.Column<DateOnly>(type: "date", nullable: true),
                    FamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stus_Fams_FamId",
                        column: x => x.FamId,
                        principalTable: "Fams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttendCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolDay = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    StuId = table.Column<int>(type: "int", nullable: false),
                    ParId = table.Column<int>(type: "int", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendCards_Emps_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendCards_Emps_EmpId1",
                        column: x => x.EmpId1,
                        principalTable: "Emps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttendCards_Pars_ParId",
                        column: x => x.ParId,
                        principalTable: "Pars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AttendCards_Stus_StuId",
                        column: x => x.StuId,
                        principalTable: "Stus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendCards_EmpId",
                table: "AttendCards",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendCards_EmpId1",
                table: "AttendCards",
                column: "EmpId1");

            migrationBuilder.CreateIndex(
                name: "IX_AttendCards_ParId",
                table: "AttendCards",
                column: "ParId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendCards_StuId",
                table: "AttendCards",
                column: "StuId");

            migrationBuilder.CreateIndex(
                name: "IX_Fams_ParId",
                table: "Fams",
                column: "ParId");

            migrationBuilder.CreateIndex(
                name: "IX_Stus_FamId",
                table: "Stus",
                column: "FamId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeCards_EmpId",
                table: "TimeCards",
                column: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendCards");

            migrationBuilder.DropTable(
                name: "TimeCards");

            migrationBuilder.DropTable(
                name: "Stus");

            migrationBuilder.DropTable(
                name: "Emps");

            migrationBuilder.DropTable(
                name: "Fams");

            migrationBuilder.DropTable(
                name: "Pars");
        }
    }
}
