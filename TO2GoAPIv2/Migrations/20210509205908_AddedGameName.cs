using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class AddedGameName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308583ee-7756-4a3e-8a79-d01c79f9b6cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355919a1-88d2-4100-9815-2a7ea4275876");

            migrationBuilder.AddColumn<short>(
                name: "Name",
                table: "Games",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64e4d12d-57f5-4ccd-9aeb-d92fbaf4b41a", "e6d9db86-0f4f-4215-81b0-312c20835bbc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1684a770-5893-4cd1-b2d9-110722819662", "cc7ede49-48b2-4dd3-ac0b-435da41a3187", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1684a770-5893-4cd1-b2d9-110722819662");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e4d12d-57f5-4ccd-9aeb-d92fbaf4b41a");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "355919a1-88d2-4100-9815-2a7ea4275876", "12cee357-de5b-4486-bd16-08922a0fcc75", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "308583ee-7756-4a3e-8a79-d01c79f9b6cc", "391fdb36-90f1-4bc6-a11a-49d29e04ba02", "Administrator", "ADMINISTRATOR" });
        }
    }
}
