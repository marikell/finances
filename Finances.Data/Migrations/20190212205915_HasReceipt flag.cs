using Microsoft.EntityFrameworkCore.Migrations;

namespace Finances.Data.Migrations
{
    public partial class HasReceiptflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasReceipt",
                table: "Transactions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasReceipt",
                table: "Transactions");
        }
    }
}
