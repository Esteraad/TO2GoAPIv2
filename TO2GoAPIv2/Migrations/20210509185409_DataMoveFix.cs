using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class DataMoveFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58c0221f-8c53-40ac-bf1e-a6f0eb7e117c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bae99c64-a1e9-4e1e-884a-6390a20f470f");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Moves",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8b54cb2-bee2-4d59-b278-b1e4fdaed5ec", "5380516b-804a-4d4f-a18f-0bb45751a385", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4e33e4f-0d09-4eb0-a8c3-d37c60e3d39f", "be8e218b-c88a-44a4-9898-9e04864577a0", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4e33e4f-0d09-4eb0-a8c3-d37c60e3d39f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8b54cb2-bee2-4d59-b278-b1e4fdaed5ec");

            migrationBuilder.AlterColumn<short>(
                name: "Type",
                table: "Moves",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bae99c64-a1e9-4e1e-884a-6390a20f470f", "f6fd4aa9-ed4f-480f-9d4a-2bcfe33499d8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58c0221f-8c53-40ac-bf1e-a6f0eb7e117c", "fdc8e2b3-0bb6-43c0-b4bd-4bc4d62c45d6", "Administrator", "ADMINISTRATOR" });
        }
    }
}
