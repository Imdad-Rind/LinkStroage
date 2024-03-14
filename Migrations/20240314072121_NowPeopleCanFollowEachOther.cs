using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkStorage.Migrations
{
    /// <inheritdoc />
    public partial class NowPeopleCanFollowEachOther : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Follower_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Following_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => new { x.Follower_Id, x.Following_Id });
                    table.ForeignKey(
                        name: "FK_Follows_Users_Table_Follower_Id",
                        column: x => x.Follower_Id,
                        principalTable: "Users_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follows_Users_Table_Following_Id",
                        column: x => x.Following_Id,
                        principalTable: "Users_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follows_Following_Id",
                table: "Follows",
                column: "Following_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follows");
        }
    }
}
