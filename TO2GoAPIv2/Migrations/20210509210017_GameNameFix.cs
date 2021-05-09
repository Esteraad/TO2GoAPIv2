using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class GameNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1684a770-5893-4cd1-b2d9-110722819662");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e4d12d-57f5-4ccd-9aeb-d92fbaf4b41a");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fe184ec-5549-44d2-b018-9a2479e68d67", "7df927a2-33d7-43c6-aa16-8ff5bd9b59b2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e78fb9f-51a8-45f1-9f3e-fef56420358b", "7fe13b5c-52d8-4779-ba80-83ca12fd5080", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fe184ec-5549-44d2-b018-9a2479e68d67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e78fb9f-51a8-45f1-9f3e-fef56420358b");

            migrationBuilder.AlterColumn<short>(
                name: "Name",
                table: "Games",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64e4d12d-57f5-4ccd-9aeb-d92fbaf4b41a", "e6d9db86-0f4f-4215-81b0-312c20835bbc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1684a770-5893-4cd1-b2d9-110722819662", "cc7ede49-48b2-4dd3-ac0b-435da41a3187", "Administrator", "ADMINISTRATOR" });
        }
    }
}
