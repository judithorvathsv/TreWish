using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreWishApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentStatusToWish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Wishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentStatus",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaymentStatus",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PaymentStatus",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PaymentStatus",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Wishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "PaymentStatus",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Wishes");
        }
    }
}
