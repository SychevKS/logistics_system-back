using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace logistics_system_back.Migrations
{
    public partial class RenameIdModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesPlanPositions_PurchasesPlans_PurchasesPlanId",
                table: "PurchasesPlanPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesPlanRealizations_PurchasesPlans_PurchasesPlanId",
                table: "PurchasesPlanRealizations");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesPlans_SalesPlans_PlanSalesId",
                table: "PurchasesPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPlanPositions_SalesPlans_SalesPlanId",
                table: "SalesPlanPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPlanRealizations_SalesPlans_SalesPlanId",
                table: "SalesPlanRealizations");

            migrationBuilder.DropColumn(
                name: "PlanSalesId",
                table: "SalesPlanRealizations");

            migrationBuilder.DropColumn(
                name: "PlanSalesId",
                table: "SalesPlanPositions");

            migrationBuilder.DropColumn(
                name: "PlanPurchasesId",
                table: "PurchasesPlanRealizations");

            migrationBuilder.DropColumn(
                name: "PlanPurchasesId",
                table: "PurchasesPlanPositions");

            migrationBuilder.RenameColumn(
                name: "PlanSalesId",
                table: "PurchasesPlans",
                newName: "SalesPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasesPlans_PlanSalesId",
                table: "PurchasesPlans",
                newName: "IX_PurchasesPlans_SalesPlanId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SalesPlanId",
                table: "SalesPlanRealizations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SalesPlanId",
                table: "SalesPlanPositions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchasesPlanId",
                table: "PurchasesPlanRealizations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchasesPlanId",
                table: "PurchasesPlanPositions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesPlanPositions_PurchasesPlans_PurchasesPlanId",
                table: "PurchasesPlanPositions",
                column: "PurchasesPlanId",
                principalTable: "PurchasesPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesPlanRealizations_PurchasesPlans_PurchasesPlanId",
                table: "PurchasesPlanRealizations",
                column: "PurchasesPlanId",
                principalTable: "PurchasesPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesPlans_SalesPlans_SalesPlanId",
                table: "PurchasesPlans",
                column: "SalesPlanId",
                principalTable: "SalesPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPlanPositions_SalesPlans_SalesPlanId",
                table: "SalesPlanPositions",
                column: "SalesPlanId",
                principalTable: "SalesPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPlanRealizations_SalesPlans_SalesPlanId",
                table: "SalesPlanRealizations",
                column: "SalesPlanId",
                principalTable: "SalesPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesPlanPositions_PurchasesPlans_PurchasesPlanId",
                table: "PurchasesPlanPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesPlanRealizations_PurchasesPlans_PurchasesPlanId",
                table: "PurchasesPlanRealizations");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesPlans_SalesPlans_SalesPlanId",
                table: "PurchasesPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPlanPositions_SalesPlans_SalesPlanId",
                table: "SalesPlanPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPlanRealizations_SalesPlans_SalesPlanId",
                table: "SalesPlanRealizations");

            migrationBuilder.RenameColumn(
                name: "SalesPlanId",
                table: "PurchasesPlans",
                newName: "PlanSalesId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasesPlans_SalesPlanId",
                table: "PurchasesPlans",
                newName: "IX_PurchasesPlans_PlanSalesId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SalesPlanId",
                table: "SalesPlanRealizations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanSalesId",
                table: "SalesPlanRealizations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SalesPlanId",
                table: "SalesPlanPositions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanSalesId",
                table: "SalesPlanPositions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchasesPlanId",
                table: "PurchasesPlanRealizations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanPurchasesId",
                table: "PurchasesPlanRealizations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchasesPlanId",
                table: "PurchasesPlanPositions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanPurchasesId",
                table: "PurchasesPlanPositions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesPlanPositions_PurchasesPlans_PurchasesPlanId",
                table: "PurchasesPlanPositions",
                column: "PurchasesPlanId",
                principalTable: "PurchasesPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesPlanRealizations_PurchasesPlans_PurchasesPlanId",
                table: "PurchasesPlanRealizations",
                column: "PurchasesPlanId",
                principalTable: "PurchasesPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesPlans_SalesPlans_PlanSalesId",
                table: "PurchasesPlans",
                column: "PlanSalesId",
                principalTable: "SalesPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPlanPositions_SalesPlans_SalesPlanId",
                table: "SalesPlanPositions",
                column: "SalesPlanId",
                principalTable: "SalesPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPlanRealizations_SalesPlans_SalesPlanId",
                table: "SalesPlanRealizations",
                column: "SalesPlanId",
                principalTable: "SalesPlans",
                principalColumn: "Id");
        }
    }
}
