using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMG.Migrations
{
    /// <inheritdoc />
    public partial class fixemg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emg2",
                table: "Pars");

            migrationBuilder.AlterColumn<string>(
                name: "Emg1",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Emg",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emg",
                table: "Pars");

            migrationBuilder.AlterColumn<string>(
                name: "Emg1",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emg2",
                table: "Pars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
