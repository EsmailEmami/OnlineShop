using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class discountInCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ProductDiscount_DiscountId",
                table: "CartItem");

            migrationBuilder.AlterColumn<long>(
                name: "DiscountId",
                table: "CartItem",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ProductDiscount_DiscountId",
                table: "CartItem",
                column: "DiscountId",
                principalTable: "ProductDiscount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ProductDiscount_DiscountId",
                table: "CartItem");

            migrationBuilder.AlterColumn<long>(
                name: "DiscountId",
                table: "CartItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ProductDiscount_DiscountId",
                table: "CartItem",
                column: "DiscountId",
                principalTable: "ProductDiscount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
