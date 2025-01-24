using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMG.Migrations
{
    /// <inheritdoc />
    public partial class emp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendCards_Emps_EmpId",
                table: "AttendCards");

            migrationBuilder.DropIndex(
                name: "IX_AttendCards_EmpId",
                table: "AttendCards");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "AttendCards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "AttendCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendCards_EmpId",
                table: "AttendCards",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendCards_Emps_EmpId",
                table: "AttendCards",
                column: "EmpId",
                principalTable: "Emps",
                principalColumn: "Id");
        }
    }
}
