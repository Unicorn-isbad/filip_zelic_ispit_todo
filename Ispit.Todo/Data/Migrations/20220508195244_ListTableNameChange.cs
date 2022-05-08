using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Data.Migrations
{
    public partial class ListTableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TodoListItems_ListId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoListItems_AspNetUsers_UserId",
                table: "TodoListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoListItems",
                table: "TodoListItems");

            migrationBuilder.RenameTable(
                name: "TodoListItems",
                newName: "TodoLists");

            migrationBuilder.RenameIndex(
                name: "IX_TodoListItems_UserId",
                table: "TodoLists",
                newName: "IX_TodoLists_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TodoLists_ListId",
                table: "Tasks",
                column: "ListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_AspNetUsers_UserId",
                table: "TodoLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TodoLists_ListId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_AspNetUsers_UserId",
                table: "TodoLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists");

            migrationBuilder.RenameTable(
                name: "TodoLists",
                newName: "TodoListItems");

            migrationBuilder.RenameIndex(
                name: "IX_TodoLists_UserId",
                table: "TodoListItems",
                newName: "IX_TodoListItems_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoListItems",
                table: "TodoListItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TodoListItems_ListId",
                table: "Tasks",
                column: "ListId",
                principalTable: "TodoListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoListItems_AspNetUsers_UserId",
                table: "TodoListItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
