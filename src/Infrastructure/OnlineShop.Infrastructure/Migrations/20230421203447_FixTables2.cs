using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProductDetailKeyValue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SellerId",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_SellerId",
                table: "CartItem",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ProductItemSeller_SellerId",
                table: "CartItem",
                column: "SellerId",
                principalTable: "ProductItemSeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ProductItemSeller_SellerId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_SellerId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductDetailKeyValue");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "CartItem");
        }
    }
}
