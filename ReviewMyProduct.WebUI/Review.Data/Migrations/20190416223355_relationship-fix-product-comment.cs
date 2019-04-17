using Microsoft.EntityFrameworkCore.Migrations;

namespace Review.Data.Migrations
{
    public partial class relationshipfixproductcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Comments_CommentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CommentId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8c12606e-2b38-4fe0-83d9-f846b349b544", "6879cab7-b1ba-4c06-8280-180a92b699dd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b05ca95c-0f4c-4223-8c8c-90e9dff89df5", "9169455c-2e46-4a38-b272-092b4b7debb2" });

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bc1c8a9-d836-4e7c-8e35-d2bc410569b2", "d35cce2f-b2f1-442e-b6bd-9b570042ef6b", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a943f66-31cb-4e79-bbea-3cf5da5cef7b", "2e6f53ae-a72e-4c5e-85fc-3a9e949c20d6", "administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_productId",
                table: "Comments",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_productId",
                table: "Comments",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_productId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_productId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4bc1c8a9-d836-4e7c-8e35-d2bc410569b2", "d35cce2f-b2f1-442e-b6bd-9b570042ef6b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5a943f66-31cb-4e79-bbea-3cf5da5cef7b", "2e6f53ae-a72e-4c5e-85fc-3a9e949c20d6" });

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Products",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b05ca95c-0f4c-4223-8c8c-90e9dff89df5", "9169455c-2e46-4a38-b272-092b4b7debb2", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c12606e-2b38-4fe0-83d9-f846b349b544", "6879cab7-b1ba-4c06-8280-180a92b699dd", "administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CommentId",
                table: "Products",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Comments_CommentId",
                table: "Products",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
