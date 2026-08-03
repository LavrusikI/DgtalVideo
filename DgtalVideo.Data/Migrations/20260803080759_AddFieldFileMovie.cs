using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DgtalVideo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldFileMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlMovie",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FileMovie",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileMovie",
                table: "Portfolio");

            migrationBuilder.AlterColumn<string>(
                name: "UrlMovie",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
