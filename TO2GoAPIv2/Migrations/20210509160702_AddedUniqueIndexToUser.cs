using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class AddedUniqueIndexToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bdd092d-bf50-4e00-93f0-d6bae697cc06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fa3e880-4bef-44ca-bb3b-6738568a3807");

            migrationBuilder.AlterColumn<string>(
                name: "Nick",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bae99c64-a1e9-4e1e-884a-6390a20f470f", "f6fd4aa9-ed4f-480f-9d4a-2bcfe33499d8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58c0221f-8c53-40ac-bf1e-a6f0eb7e117c", "fdc8e2b3-0bb6-43c0-b4bd-4bc4d62c45d6", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Nick",
                table: "AspNetUsers",
                column: "Nick",
                unique: true,
                filter: "[Nick] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Nick",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58c0221f-8c53-40ac-bf1e-a6f0eb7e117c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bae99c64-a1e9-4e1e-884a-6390a20f470f");

            migrationBuilder.AlterColumn<string>(
                name: "Nick",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fa3e880-4bef-44ca-bb3b-6738568a3807", "82345ecf-86ce-46e6-b167-2862d49c646d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bdd092d-bf50-4e00-93f0-d6bae697cc06", "ef7b480d-a4ae-418c-b777-7a0db18a09c6", "Administrator", "ADMINISTRATOR" });
        }
    }
}
