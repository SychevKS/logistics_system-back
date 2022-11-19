using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace logistics_system_back.Migrations
{
    public partial class AddFieldToInvoicePos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceKind",
                table: "InvoicePositions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceKind",
                table: "InvoicePositions");
        }
    }
}
