using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TreWishApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWishEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishes_Users_UserId",
                table: "Wishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishes_Users_UserId1",
                table: "Wishes");

            migrationBuilder.DropIndex(
                name: "IX_Wishes_UserId",
                table: "Wishes");

            migrationBuilder.DropIndex(
                name: "IX_Wishes_UserId1",
                table: "Wishes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Wishes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Wishes");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User 1" },
                    { 2, "User 2" },
                    { 3, "User 3" },
                    { 4, "User 4" },
                    { 5, "User 5" }
                });

            migrationBuilder.InsertData(
                table: "Wishes",
                columns: new[] { "Id", "Description", "Name", "Price", "PurchaserId", "WebPageLink", "WisherId" },
                values: new object[,]
                {
                    { 1, "Wish 1 Description", "Wish 1", 1.1000000000000001, null, null, 1 },
                    { 2, "Wish 2 Description", "Wish 2", 2.2000000000000002, 2, null, 1 },
                    { 3, "Wish 3 Description", "Wish 3", 3.2999999999999998, 2, null, 1 },
                    { 4, "Wish 4 Description", "Wish 4", 4.4000000000000004, 3, null, 2 },
                    { 5, "Wish 5 Description", "Wish 5", 5.5, 1, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_PurchaserId",
                table: "Wishes",
                column: "PurchaserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_WisherId",
                table: "Wishes",
                column: "WisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishes_Users_PurchaserId",
                table: "Wishes",
                column: "PurchaserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishes_Users_WisherId",
                table: "Wishes",
                column: "WisherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishes_Users_PurchaserId",
                table: "Wishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishes_Users_WisherId",
                table: "Wishes");

            migrationBuilder.DropIndex(
                name: "IX_Wishes_PurchaserId",
                table: "Wishes");

            migrationBuilder.DropIndex(
                name: "IX_Wishes_WisherId",
                table: "Wishes");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Wishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Wishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_UserId",
                table: "Wishes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_UserId1",
                table: "Wishes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishes_Users_UserId",
                table: "Wishes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishes_Users_UserId1",
                table: "Wishes",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
