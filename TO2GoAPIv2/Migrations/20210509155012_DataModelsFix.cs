using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class DataModelsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameFinish_Games_GameId",
                table: "GameFinish");

            migrationBuilder.DropForeignKey(
                name: "FK_GameStart_Games_GameId",
                table: "GameStart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameStart",
                table: "GameStart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameFinish",
                table: "GameFinish");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69c5363b-f0a8-47a0-8b55-cc7b4d30b89d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6798a5f-dcec-4742-ac11-435a60162551");

            migrationBuilder.RenameTable(
                name: "GameStart",
                newName: "GameStarts");

            migrationBuilder.RenameTable(
                name: "GameFinish",
                newName: "GameFinishes");

            migrationBuilder.RenameIndex(
                name: "IX_GameStart_GameId",
                table: "GameStarts",
                newName: "IX_GameStarts_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameFinish_GameId",
                table: "GameFinishes",
                newName: "IX_GameFinishes_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameStarts",
                table: "GameStarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameFinishes",
                table: "GameFinishes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fa3e880-4bef-44ca-bb3b-6738568a3807", "82345ecf-86ce-46e6-b167-2862d49c646d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bdd092d-bf50-4e00-93f0-d6bae697cc06", "ef7b480d-a4ae-418c-b777-7a0db18a09c6", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameFinishes_Games_GameId",
                table: "GameFinishes",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameStarts_Games_GameId",
                table: "GameStarts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameFinishes_Games_GameId",
                table: "GameFinishes");

            migrationBuilder.DropForeignKey(
                name: "FK_GameStarts_Games_GameId",
                table: "GameStarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameStarts",
                table: "GameStarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameFinishes",
                table: "GameFinishes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bdd092d-bf50-4e00-93f0-d6bae697cc06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fa3e880-4bef-44ca-bb3b-6738568a3807");

            migrationBuilder.RenameTable(
                name: "GameStarts",
                newName: "GameStart");

            migrationBuilder.RenameTable(
                name: "GameFinishes",
                newName: "GameFinish");

            migrationBuilder.RenameIndex(
                name: "IX_GameStarts_GameId",
                table: "GameStart",
                newName: "IX_GameStart_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameFinishes_GameId",
                table: "GameFinish",
                newName: "IX_GameFinish_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameStart",
                table: "GameStart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameFinish",
                table: "GameFinish",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69c5363b-f0a8-47a0-8b55-cc7b4d30b89d", "f6a9fda8-00b7-4045-a1fb-ad84b03b745f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6798a5f-dcec-4742-ac11-435a60162551", "9700cbe2-67f5-431a-9406-6ee9ad1eaa03", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameFinish_Games_GameId",
                table: "GameFinish",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameStart_Games_GameId",
                table: "GameStart",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
