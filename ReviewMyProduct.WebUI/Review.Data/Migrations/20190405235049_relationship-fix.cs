using Microsoft.EntityFrameworkCore.Migrations;

namespace Review.Data.Migrations
{
    public partial class relationshipfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Comments_CommentId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a5c08ac3-1b67-462e-a2de-57d1e537ac7b", "1d5e2219-8c7a-461a-b08b-05963f9fa916" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b56f20cf-1cec-45e7-8392-2192b4b98c39", "255b6003-0037-428d-8efa-8bf94a8f5869" });

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b05ca95c-0f4c-4223-8c8c-90e9dff89df5", "9169455c-2e46-4a38-b272-092b4b7debb2", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c12606e-2b38-4fe0-83d9-f846b349b544", "6879cab7-b1ba-4c06-8280-180a92b699dd", "administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Comments_CommentId",
                table: "Products",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Comments_CommentId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8c12606e-2b38-4fe0-83d9-f846b349b544", "6879cab7-b1ba-4c06-8280-180a92b699dd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b05ca95c-0f4c-4223-8c8c-90e9dff89df5", "9169455c-2e46-4a38-b272-092b4b7debb2" });

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5c08ac3-1b67-462e-a2de-57d1e537ac7b", "1d5e2219-8c7a-461a-b08b-05963f9fa916", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b56f20cf-1cec-45e7-8392-2192b4b98c39", "255b6003-0037-428d-8efa-8bf94a8f5869", "administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Comments_CommentId",
                table: "Products",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
