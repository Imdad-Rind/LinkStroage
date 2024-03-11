using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkStorage.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationsToLinksAndUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Links",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserId",
                table: "Links",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Users_Table_UserId",
                table: "Links",
                column: "UserId",
                principalTable: "Users_Table",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Users_Table_UserId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_UserId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Links");
        }
    }
}
