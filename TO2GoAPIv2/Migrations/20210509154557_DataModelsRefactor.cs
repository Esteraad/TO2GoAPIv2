using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class DataModelsRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167fecc1-95bb-41b8-9c71-b37049328073");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21dd0921-c17b-4b8b-821e-3d174662c97f");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "GameFinish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFinish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameFinish_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameStart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameStart_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69c5363b-f0a8-47a0-8b55-cc7b4d30b89d", "f6a9fda8-00b7-4045-a1fb-ad84b03b745f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6798a5f-dcec-4742-ac11-435a60162551", "9700cbe2-67f5-431a-9406-6ee9ad1eaa03", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_GameFinish_GameId",
                table: "GameFinish",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameStart_GameId",
                table: "GameStart",
                column: "GameId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameFinish");

            migrationBuilder.DropTable(
                name: "GameStart");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69c5363b-f0a8-47a0-8b55-cc7b4d30b89d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6798a5f-dcec-4742-ac11-435a60162551");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "167fecc1-95bb-41b8-9c71-b37049328073", "e82beac9-c77f-4a9e-826e-5ab8eecdc50d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21dd0921-c17b-4b8b-821e-3d174662c97f", "3bc28d1d-24c9-4194-b700-2e0a88d5d1f4", "Administrator", "ADMINISTRATOR" });
        }
    }
}
