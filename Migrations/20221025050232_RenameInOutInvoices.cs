using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace logistics_system_back.Migrations
{
    public partial class RenameInOutInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InOutInvoices_Divisions_InDivisionId",
                table: "InOutInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InOutInvoices_Divisions_OutDivisionId",
                table: "InOutInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InOutInvoices_Invoices_InvoiceId",
                table: "InOutInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InOutInvoices",
                table: "InOutInvoices");

            migrationBuilder.RenameTable(
                name: "InOutInvoices",
                newName: "TransferInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_InOutInvoices_OutDivisionId",
                table: "TransferInvoices",
                newName: "IX_TransferInvoices_OutDivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_InOutInvoices_InDivisionId",
                table: "TransferInvoices",
                newName: "IX_TransferInvoices_InDivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransferInvoices",
                table: "TransferInvoices",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferInvoices_Divisions_InDivisionId",
                table: "TransferInvoices",
                column: "InDivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferInvoices_Divisions_OutDivisionId",
                table: "TransferInvoices",
                column: "OutDivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferInvoices_Invoices_InvoiceId",
                table: "TransferInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferInvoices_Divisions_InDivisionId",
                table: "TransferInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferInvoices_Divisions_OutDivisionId",
                table: "TransferInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferInvoices_Invoices_InvoiceId",
                table: "TransferInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransferInvoices",
                table: "TransferInvoices");

            migrationBuilder.RenameTable(
                name: "TransferInvoices",
                newName: "InOutInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_TransferInvoices_OutDivisionId",
                table: "InOutInvoices",
                newName: "IX_InOutInvoices_OutDivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferInvoices_InDivisionId",
                table: "InOutInvoices",
                newName: "IX_InOutInvoices_InDivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InOutInvoices",
                table: "InOutInvoices",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InOutInvoices_Divisions_InDivisionId",
                table: "InOutInvoices",
                column: "InDivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InOutInvoices_Divisions_OutDivisionId",
                table: "InOutInvoices",
                column: "OutDivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InOutInvoices_Invoices_InvoiceId",
                table: "InOutInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
