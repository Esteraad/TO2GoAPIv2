using Microsoft.EntityFrameworkCore.Migrations;

namespace TO2GoAPIv2.Migrations
{
    public partial class dataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_AspNetUsers_ApiUserId",
                table: "GamePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Games_GameId",
                table: "GamePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_GameWinner_AspNetUsers_ApiUserId",
                table: "GameWinner");

            migrationBuilder.DropForeignKey(
                name: "FK_GameWinner_Games_GameId",
                table: "GameWinner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameWinner",
                table: "GameWinner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7e292a2-8e13-4c71-99ff-b0ac98aa9bff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f24a43f0-355e-4b95-96ab-35fc260f9732");

            migrationBuilder.RenameTable(
                name: "GameWinner",
                newName: "GameWinners");

            migrationBuilder.RenameTable(
                name: "GamePlayer",
                newName: "GamePlayers");

            migrationBuilder.RenameIndex(
                name: "IX_GameWinner_GameId",
                table: "GameWinners",
                newName: "IX_GameWinners_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameWinner_ApiUserId",
                table: "GameWinners",
                newName: "IX_GameWinners_ApiUserId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayer_GameId",
                table: "GamePlayers",
                newName: "IX_GamePlayers_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayer_ApiUserId",
                table: "GamePlayers",
                newName: "IX_GamePlayers_ApiUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameWinners",
                table: "GameWinners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlayers",
                table: "GamePlayers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "167fecc1-95bb-41b8-9c71-b37049328073", "e82beac9-c77f-4a9e-826e-5ab8eecdc50d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21dd0921-c17b-4b8b-821e-3d174662c97f", "3bc28d1d-24c9-4194-b700-2e0a88d5d1f4", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayers_AspNetUsers_ApiUserId",
                table: "GamePlayers",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayers_Games_GameId",
                table: "GamePlayers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameWinners_AspNetUsers_ApiUserId",
                table: "GameWinners",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameWinners_Games_GameId",
                table: "GameWinners",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayers_AspNetUsers_ApiUserId",
                table: "GamePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayers_Games_GameId",
                table: "GamePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_GameWinners_AspNetUsers_ApiUserId",
                table: "GameWinners");

            migrationBuilder.DropForeignKey(
                name: "FK_GameWinners_Games_GameId",
                table: "GameWinners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameWinners",
                table: "GameWinners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlayers",
                table: "GamePlayers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167fecc1-95bb-41b8-9c71-b37049328073");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21dd0921-c17b-4b8b-821e-3d174662c97f");

            migrationBuilder.RenameTable(
                name: "GameWinners",
                newName: "GameWinner");

            migrationBuilder.RenameTable(
                name: "GamePlayers",
                newName: "GamePlayer");

            migrationBuilder.RenameIndex(
                name: "IX_GameWinners_GameId",
                table: "GameWinner",
                newName: "IX_GameWinner_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameWinners_ApiUserId",
                table: "GameWinner",
                newName: "IX_GameWinner_ApiUserId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayers_GameId",
                table: "GamePlayer",
                newName: "IX_GamePlayer_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayers_ApiUserId",
                table: "GamePlayer",
                newName: "IX_GamePlayer_ApiUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameWinner",
                table: "GameWinner",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7e292a2-8e13-4c71-99ff-b0ac98aa9bff", "5b2ea918-0b5f-47c9-8159-24c9c1e61025", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f24a43f0-355e-4b95-96ab-35fc260f9732", "890b56bd-a55f-4892-8aca-80c495da62b4", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_AspNetUsers_ApiUserId",
                table: "GamePlayer",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Games_GameId",
                table: "GamePlayer",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameWinner_AspNetUsers_ApiUserId",
                table: "GameWinner",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameWinner_Games_GameId",
                table: "GameWinner",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
