using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class DataGameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4e33e4f-0d09-4eb0-a8c3-d37c60e3d39f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8b54cb2-bee2-4d59-b278-b1e4fdaed5ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "355919a1-88d2-4100-9815-2a7ea4275876", "12cee357-de5b-4486-bd16-08922a0fcc75", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "308583ee-7756-4a3e-8a79-d01c79f9b6cc", "391fdb36-90f1-4bc6-a11a-49d29e04ba02", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308583ee-7756-4a3e-8a79-d01c79f9b6cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355919a1-88d2-4100-9815-2a7ea4275876");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8b54cb2-bee2-4d59-b278-b1e4fdaed5ec", "5380516b-804a-4d4f-a18f-0bb45751a385", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4e33e4f-0d09-4eb0-a8c3-d37c60e3d39f", "be8e218b-c88a-44a4-9898-9e04864577a0", "Administrator", "ADMINISTRATOR" });
        }
    }
}
