using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixPeyvastFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PeyvastFile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PeyvastFile",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
