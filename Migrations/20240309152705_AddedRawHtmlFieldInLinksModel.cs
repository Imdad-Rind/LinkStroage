using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkStorage.Migrations
{
    /// <inheritdoc />
    public partial class AddedRawHtmlFieldInLinksModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RawHtml",
                table: "Links",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RawHtml",
                table: "Links");
        }
    }
}
