using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumDemo.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPostLike_Posts_PostId",
                table: "UserPostLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPostLike_Users_UserId",
                table: "UserPostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostLike",
                table: "UserPostLike");

            migrationBuilder.RenameTable(
                name: "UserPostLike",
                newName: "UserPostLikes");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostLike_UserId",
                table: "UserPostLikes",
                newName: "IX_UserPostLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostLike_PostId",
                table: "UserPostLikes",
                newName: "IX_UserPostLikes_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostLikes",
                table: "UserPostLikes",
                column: "UserPostLikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostLikes_Posts_PostId",
                table: "UserPostLikes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostLikes_Users_UserId",
                table: "UserPostLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPostLikes_Posts_PostId",
                table: "UserPostLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPostLikes_Users_UserId",
                table: "UserPostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostLikes",
                table: "UserPostLikes");

            migrationBuilder.RenameTable(
                name: "UserPostLikes",
                newName: "UserPostLike");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostLikes_UserId",
                table: "UserPostLike",
                newName: "IX_UserPostLike_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostLikes_PostId",
                table: "UserPostLike",
                newName: "IX_UserPostLike_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostLike",
                table: "UserPostLike",
                column: "UserPostLikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostLike_Posts_PostId",
                table: "UserPostLike",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostLike_Users_UserId",
                table: "UserPostLike",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
