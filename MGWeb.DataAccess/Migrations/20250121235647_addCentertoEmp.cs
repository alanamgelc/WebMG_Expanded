using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMG.Migrations
{
    /// <inheritdoc />
    public partial class addCentertoEmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassCategory",
                table: "Emps");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Emps",
                newName: "CenterId");

            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emps_CenterId",
                table: "Emps",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emps_Centers_CenterId",
                table: "Emps",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emps_Centers_CenterId",
                table: "Emps");

            migrationBuilder.DropTable(
                name: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Emps_CenterId",
                table: "Emps");

            migrationBuilder.RenameColumn(
                name: "CenterId",
                table: "Emps",
                newName: "ClassId");

            migrationBuilder.AddColumn<int>(
                name: "ClassCategory",
                table: "Emps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
