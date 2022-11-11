using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace logistics_system_back.Migrations
{
    public partial class Refact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseInvoices");

            migrationBuilder.DropTable(
                name: "PurchasesPlanPositions");

            migrationBuilder.DropTable(
                name: "PurchasesPlanRealizations");

            migrationBuilder.DropTable(
                name: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "SalesPlanPositions");

            migrationBuilder.DropTable(
                name: "SalesPlanRealizations");

            migrationBuilder.DropTable(
                name: "TransferInvoices");

            migrationBuilder.DropTable(
                name: "PurchasesPlans");

            migrationBuilder.DropTable(
                name: "SalesPlans");

            migrationBuilder.CreateTable(
                name: "InvoicePurchases",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePurchases", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoicePurchases_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicePurchases_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicePurchases_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSales",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSales", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceSales_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceSales_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceSales_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTransfers",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    OutDivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    InDivisionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTransfers", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceTransfers_Divisions_InDivisionId",
                        column: x => x.InDivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceTransfers_Divisions_OutDivisionId",
                        column: x => x.OutDivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceTransfers_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlansSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlansSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanSalesPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSalesPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanSalesPositions_PlansSales_PlanSalesId",
                        column: x => x.PlanSalesId,
                        principalTable: "PlansSales",
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
                name: "PlanSalesRealizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSalesRealizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanSalesRealizations_PlansSales_PlanSalesId",
                        column: x => x.PlanSalesId,
                        principalTable: "PlansSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanSalesRealizations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlansPurchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    PlanSalesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlansPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlansPurchases_PlansSales_PlanSalesId",
                        column: x => x.PlanSalesId,
                        principalTable: "PlansSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanPurchasesPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PlanPurchasesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "FK_PlanPurchasesPositions_PlansPurchases_PlanPurchasesId",
                        column: x => x.PlanPurchasesId,
                        principalTable: "PlansPurchases",
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
                name: "PlanPurchasesRealizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PlanPurchasesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPurchasesRealizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesRealizations_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesRealizations_PlansPurchases_PlanPurchasesId",
                        column: x => x.PlanPurchasesId,
                        principalTable: "PlansPurchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPurchasesRealizations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePurchases_DivisionId",
                table: "InvoicePurchases",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePurchases_PartnerId",
                table: "InvoicePurchases",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSales_DivisionId",
                table: "InvoiceSales",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSales_PartnerId",
                table: "InvoiceSales",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTransfers_InDivisionId",
                table: "InvoiceTransfers",
                column: "InDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTransfers_OutDivisionId",
                table: "InvoiceTransfers",
                column: "OutDivisionId");

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
                name: "IX_PlanPurchasesRealizations_DivisionId",
                table: "PlanPurchasesRealizations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchasesRealizations_PlanPurchasesId",
                table: "PlanPurchasesRealizations",
                column: "PlanPurchasesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPurchasesRealizations_ProductId",
                table: "PlanPurchasesRealizations",
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
                name: "IX_PlanSalesRealizations_PlanSalesId",
                table: "PlanSalesRealizations",
                column: "PlanSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSalesRealizations_ProductId",
                table: "PlanSalesRealizations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PlansPurchases_PlanSalesId",
                table: "PlansPurchases",
                column: "PlanSalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoicePurchases");

            migrationBuilder.DropTable(
                name: "InvoiceSales");

            migrationBuilder.DropTable(
                name: "InvoiceTransfers");

            migrationBuilder.DropTable(
                name: "PlanPurchasesPositions");

            migrationBuilder.DropTable(
                name: "PlanPurchasesRealizations");

            migrationBuilder.DropTable(
                name: "PlanSalesPositions");

            migrationBuilder.DropTable(
                name: "PlanSalesRealizations");

            migrationBuilder.DropTable(
                name: "PlansPurchases");

            migrationBuilder.DropTable(
                name: "PlansSales");

            migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "TransferInvoices",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    InDivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    OutDivisionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferInvoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_TransferInvoices_Divisions_InDivisionId",
                        column: x => x.InDivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferInvoices_Divisions_OutDivisionId",
                        column: x => x.OutDivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesPlans_SalesPlans_SalesPlanId",
                        column: x => x.SalesPlanId,
                        principalTable: "SalesPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPlanPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPlanRealizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesPlanPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchasesPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesPlanRealizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchasesPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_DivisionId",
                table: "PurchaseInvoices",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_PartnerId",
                table: "PurchaseInvoices",
                column: "PartnerId");

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
                name: "IX_PurchasesPlans_SalesPlanId",
                table: "PurchasesPlans",
                column: "SalesPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_DivisionId",
                table: "SalesInvoices",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_PartnerId",
                table: "SalesInvoices",
                column: "PartnerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TransferInvoices_InDivisionId",
                table: "TransferInvoices",
                column: "InDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferInvoices_OutDivisionId",
                table: "TransferInvoices",
                column: "OutDivisionId");
        }
    }
}
