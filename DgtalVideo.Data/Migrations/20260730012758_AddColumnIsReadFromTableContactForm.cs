using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DgtalVideo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsReadFromTableContactForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ContactForm",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ContactForm");
        }
    }
}
