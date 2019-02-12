using Microsoft.EntityFrameworkCore.Migrations;

namespace Finances.Data.Migrations
{
    public partial class ValidatingUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_IdUser",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_IdUser",
                table: "Transactions",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_IdUser",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_IdUser",
                table: "Transactions",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
