using Microsoft.EntityFrameworkCore.Migrations;

namespace Review.Data.Migrations
{
    public partial class newpropertiesinrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4bc1c8a9-d836-4e7c-8e35-d2bc410569b2", "d35cce2f-b2f1-442e-b6bd-9b570042ef6b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5a943f66-31cb-4e79-bbea-3cf5da5cef7b", "2e6f53ae-a72e-4c5e-85fc-3a9e949c20d6" });

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numThumbsDown",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numThumbsUp",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9943f7b0-1c8d-42a3-ab4d-b23bd1448512", "c2bafb59-d659-4567-9226-f25185a6d0f6", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04cfa20c-e7e8-4f83-8740-8ac85757746c", "a81b6f0a-429d-47c1-aafb-85aaf215fb87", "administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "04cfa20c-e7e8-4f83-8740-8ac85757746c", "a81b6f0a-429d-47c1-aafb-85aaf215fb87" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9943f7b0-1c8d-42a3-ab4d-b23bd1448512", "c2bafb59-d659-4567-9226-f25185a6d0f6" });

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "numThumbsDown",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "numThumbsUp",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bc1c8a9-d836-4e7c-8e35-d2bc410569b2", "d35cce2f-b2f1-442e-b6bd-9b570042ef6b", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a943f66-31cb-4e79-bbea-3cf5da5cef7b", "2e6f53ae-a72e-4c5e-85fc-3a9e949c20d6", "administrator", "ADMINISTRATOR" });
        }
    }
}
