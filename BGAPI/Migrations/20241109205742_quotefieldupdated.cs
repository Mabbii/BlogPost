using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGAPI.Migrations
{
    /// <inheritdoc />
    public partial class quotefieldupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPosts",
                table: "blogPosts");

            migrationBuilder.RenameTable(
                name: "blogPosts",
                newName: "BlogPosts");

            migrationBuilder.AddColumn<string>(
                name: "Quote",
                table: "BlogPosts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Quote",
                table: "BlogPosts");

            migrationBuilder.RenameTable(
                name: "BlogPosts",
                newName: "blogPosts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPosts",
                table: "blogPosts",
                column: "Id");
        }
    }
}
