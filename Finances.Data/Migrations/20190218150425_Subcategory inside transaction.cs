using Microsoft.EntityFrameworkCore.Migrations;

namespace Finances.Data.Migrations
{
    public partial class Subcategoryinsidetransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdSubCategory",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdSubCategory",
                table: "Transactions",
                column: "IdSubCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_SubCategories_IdSubCategory",
                table: "Transactions",
                column: "IdSubCategory",
                principalTable: "SubCategories",
                principalColumn: "IdSubCategory",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_SubCategories_IdSubCategory",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_IdSubCategory",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IdSubCategory",
                table: "Transactions");
        }
    }
}
