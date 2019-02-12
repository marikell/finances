using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Finances.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DsCategory = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    IdSubCategory = table.Column<long>(nullable: false),
                    DsSubCategory = table.Column<string>(maxLength: 50, nullable: false),
                    IdCategory = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.IdSubCategory);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_IdSubCategory",
                        column: x => x.IdSubCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    IdTransaction = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTransactionType = table.Column<long>(nullable: false),
                    DatTransaction = table.Column<DateTime>(nullable: false),
                    DatCreation = table.Column<DateTime>(nullable: false),
                    VlTransaction = table.Column<decimal>(nullable: false),
                    DsTransaction = table.Column<string>(maxLength: 200, nullable: false),
                    IdCategory = table.Column<long>(nullable: false),
                    IdUser = table.Column<string>(nullable: true),
                    IdUserDestination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.IdTransaction);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionsType_IdTransactionType",
                        column: x => x.IdTransactionType,
                        principalTable: "TransactionsType",
                        principalColumn: "IdTransactionType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_IdUserDestination",
                        column: x => x.IdUserDestination,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdCategory",
                table: "Transactions",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdTransactionType",
                table: "Transactions",
                column: "IdTransactionType");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdUser",
                table: "Transactions",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdUserDestination",
                table: "Transactions",
                column: "IdUserDestination");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
