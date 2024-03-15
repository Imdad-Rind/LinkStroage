using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkStorage.Migrations
{
    /// <inheritdoc />
    public partial class NowThereIsCouctForPostAndFolloers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FollowersCount",
                table: "Users_Table",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FollowingsCount",
                table: "Users_Table",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PublicPostCount",
                table: "Users_Table",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowersCount",
                table: "Users_Table");

            migrationBuilder.DropColumn(
                name: "FollowingsCount",
                table: "Users_Table");

            migrationBuilder.DropColumn(
                name: "PublicPostCount",
                table: "Users_Table");
        }
    }
}
