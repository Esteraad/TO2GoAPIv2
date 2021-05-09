using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class AddedRestEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d9f2146-5663-4b0c-a70b-52280b6a09ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4335b8d-2981-4f08-a9e2-590a0b74e10c");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "OwnerReady",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Player2Ready",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d610fb3-16db-4044-b1f1-14f500c96662", "393f8eab-4f47-42b9-bf1c-190ff2dcac51", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58965604-09b9-499a-815b-61240a1a18d3", "71c6d273-4d90-447d-bf93-9e27b2ed8981", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58965604-09b9-499a-815b-61240a1a18d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d610fb3-16db-4044-b1f1-14f500c96662");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OwnerReady",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Player2Ready",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4335b8d-2981-4f08-a9e2-590a0b74e10c", "e4d7480b-3f0f-4bf5-8690-4c2623ac3a15", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d9f2146-5663-4b0c-a70b-52280b6a09ba", "02164d29-690c-41c2-9cbe-6724480e230f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
