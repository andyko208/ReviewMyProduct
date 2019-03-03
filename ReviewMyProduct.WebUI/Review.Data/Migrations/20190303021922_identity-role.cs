using Microsoft.EntityFrameworkCore.Migrations;

namespace Review.Data.Migrations
{
    public partial class identityrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8b30b69-0012-4a9f-b234-76bccbc60471", "97e65167-a2f3-48a1-92a5-31ade52e61d3", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f859f292-331f-4d4a-aca9-75d02b93db50", "39468404-5b93-4a75-bf72-cdd632be02c6", "administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c8b30b69-0012-4a9f-b234-76bccbc60471", "97e65167-a2f3-48a1-92a5-31ade52e61d3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f859f292-331f-4d4a-aca9-75d02b93db50", "39468404-5b93-4a75-bf72-cdd632be02c6" });
        }
    }
}
