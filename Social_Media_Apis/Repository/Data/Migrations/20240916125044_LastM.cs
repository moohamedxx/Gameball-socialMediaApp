using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Data.Migrations
{
    public partial class LastM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserEntityid",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserFollow",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserEntityid",
                table: "Comments",
                newName: "UserEntityId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserEntityid",
                table: "Comments",
                newName: "IX_Comments_UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserEntityId",
                table: "Comments",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserEntityId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserFollow",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "Comments",
                newName: "UserEntityid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserEntityId",
                table: "Comments",
                newName: "IX_Comments_UserEntityid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserEntityid",
                table: "Comments",
                column: "UserEntityid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
