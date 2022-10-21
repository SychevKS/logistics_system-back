using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace logistics_system_back.Migrations
{
    public partial class RenameModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remaining_Divisions_DivisionId",
                table: "Remaining");

            migrationBuilder.DropForeignKey(
                name: "FK_Remaining_Products_ProductId",
                table: "Remaining");

            migrationBuilder.DropTable(
                name: "PlanPurchasesPositions");

            migrationBuilder.DropTable(
                name: "PlanPurchasesRealization");

            migrationBuilder.DropTable(
                name: "PlanSalesPositions");

            migrationBuilder.DropTable(
                name: "PlanSalesRealization");

            migrationBuilder.DropTable(
                name: "PlanPurchases");

            migrationBuilder.DropTable(
                name: "PlanSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Remaining",
                table: "Remaining");

            migrationBuilder.RenameTable(
                name: "Remaining",
                newName: "Remainings");

            migrationBuilder.RenameIndex(
                name: "IX_Remaining_ProductId",
                table: "Remainings",
                newName: "IX_Remainings_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Remaining_DivisionId",
                table: "Remainings",
                newName: "IX_Remainings_DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Remainings",
                table: "Remainings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SalesPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesPlans_SalesPlans_PlanSalesId",
                        column: x => x.PlanSalesId,
                        principalTable: "SalesPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPlanPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPlanPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPlanPositions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPlanPositions_SalesPlans_SalesPlanId",
                        column: x => x.SalesPlanId,
                        principalTable: "SalesPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesPlanRealizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPlanRealizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPlanRealizations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPlanRealizations_SalesPlans_SalesPlanId",
                        column: x => x.SalesPlanId,
                        principalTable: "SalesPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchasesPlanPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PlanPurchasesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchasesPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesPlanPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesPlanPositions_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesPlanPositions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesPlanPositions_PurchasesPlans_PurchasesPlanId",
                        column: x => x.PurchasesPlanId,
                        principalTable: "PurchasesPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchasesPlanRealizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PlanPurchasesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchasesPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesPlanRealizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesPlanRealizations_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesPlanRealizations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesPlanRealizations_PurchasesPlans_PurchasesPlanId",
                        column: x => x.PurchasesPlanId,
                        principalTable: "PurchasesPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPlanPositions_DivisionId",
                table: "PurchasesPlanPositions",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPlanPositions_ProductId",
                table: "PurchasesPlanPositions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPlanPositions_PurchasesPlanId",
                table: "PurchasesPlanPositions",
                column: "PurchasesPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPlanRealizations_DivisionId",
                table: "PurchasesPlanRealizations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPlanRealizations_ProductId",
                table: "PurchasesPlanRealizations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPlanRealizations_PurchasesPlanId",
                table: "PurchasesPlanRealizations",
                column: "PurchasesPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPlans_PlanSalesId",
                table: "PurchasesPlans",
                column: "PlanSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPlanPositions_ProductId",
                table: "SalesPlanPositions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPlanPositions_SalesPlanId",
                table: "SalesPlanPositions",
                column: "SalesPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPlanRealizations_ProductId",
                table: "SalesPlanRealizations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPlanRealizations_SalesPlanId",
                table: "SalesPlanRealizations",
                column: "SalesPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remainings_Divisions_DivisionId",
                table: "Remainings",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Remainings_Products_ProductId",
                table: "Remainings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remainings_Divisions_DivisionId",
                table: "Remainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Remainings_Products_ProductId",
                table: "Remainings");

            migrationBuilder.DropTable(
                name: "PurchasesPlanPositions");

            migrationBuilder.DropTable(
                name: "PurchasesPlanRealizations");

            migrationBuilder.DropTable(
                name: "SalesPlanPositions");

            migrationBuilder.DropTable(
                name: "SalesPlanRealizations");

            migrationBuilder.DropTable(
                name: "PurchasesPlans");

            migrationBuilder.DropTable(
                name: "SalesPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Remainings",
                table: "Remainings");

            migrationBuilder.RenameTable(
                name: "Remainings",
                newName: "Remaining");

            migrationBuilder.RenameIndex(
                name: "IX_Remainings_ProductId",
                table: "Remaining",
                newName: "IX_Remaining_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Remainings_DivisionId",
                table: "Remaining",
                newName: "IX_Remaining_DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Remaining",
                table: "Remaining",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlanSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanPurchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPurchases_PlanSales_PlanSalesId",
                        column: x => x.PlanSalesId,
                        principalTable: "PlanSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanSalesPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSalesPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanSalesPositions_PlanSales_PlanSalesId",
                        column: x => x.PlanSalesId,
                        principalTable: "PlanSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanSalesPositions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanSalesRealization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSalesRealization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanSalesRealization_PlanSales_PlanSalesId",
                        column: x => x.PlanSalesId,
                        principalTable: "PlanSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanSalesRealization_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanPurchasesPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanPurchasesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPurchasesPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesPositions_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesPositions_PlanPurchases_PlanPurchasesId",
                        column: x => x.PlanPurchasesId,
                        principalTable: "PlanPurchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesPositions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanPurchasesRealization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanPurchasesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPurchasesRealization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesRealization_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesRealization_PlanPurchases_PlanPurchasesId",
                        column: x => x.PlanPurchasesId,
                        principalTable: "PlanPurchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesRealization_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchases_PlanSalesId",
                table: "PlanPurchases",
                column: "PlanSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchasesPositions_DivisionId",
                table: "PlanPurchasesPositions",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchasesPositions_PlanPurchasesId",
                table: "PlanPurchasesPositions",
                column: "PlanPurchasesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchasesPositions_ProductId",
                table: "PlanPurchasesPositions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchasesRealization_DivisionId",
                table: "PlanPurchasesRealization",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchasesRealization_PlanPurchasesId",
                table: "PlanPurchasesRealization",
                column: "PlanPurchasesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchasesRealization_ProductId",
                table: "PlanPurchasesRealization",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSalesPositions_PlanSalesId",
                table: "PlanSalesPositions",
                column: "PlanSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSalesPositions_ProductId",
                table: "PlanSalesPositions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSalesRealization_PlanSalesId",
                table: "PlanSalesRealization",
                column: "PlanSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSalesRealization_ProductId",
                table: "PlanSalesRealization",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remaining_Divisions_DivisionId",
                table: "Remaining",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Remaining_Products_ProductId",
                table: "Remaining",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
