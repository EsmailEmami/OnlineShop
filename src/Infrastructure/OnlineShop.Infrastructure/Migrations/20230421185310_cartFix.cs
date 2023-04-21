using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cartFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Product_ProductId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItem",
                newName: "ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                newName: "IX_CartItem_ProductItemId");

            migrationBuilder.AlterColumn<string>(
                name: "PostTrackingCode",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "FinalSum",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Cart",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "Cart",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ProductItem_ProductItemId",
                table: "CartItem",
                column: "ProductItemId",
                principalTable: "ProductItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ProductItem_ProductItemId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "FinalSum",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "CartItem",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductItemId",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "CartItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "PostTrackingCode",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Product_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
