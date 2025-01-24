using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMG.Migrations
{
    /// <inheritdoc />
    public partial class emg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emg1",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Emg1Email",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emg1Phone",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emg2",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmgEmail",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmgPhone",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emg1",
                table: "Pars");

            migrationBuilder.DropColumn(
                name: "Emg1Email",
                table: "Pars");

            migrationBuilder.DropColumn(
                name: "Emg1Phone",
                table: "Pars");

            migrationBuilder.DropColumn(
                name: "Emg2",
                table: "Pars");

            migrationBuilder.DropColumn(
                name: "EmgEmail",
                table: "Pars");

            migrationBuilder.DropColumn(
                name: "EmgPhone",
                table: "Pars");
        }
    }
}
