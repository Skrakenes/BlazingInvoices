using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingInvoices.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceCounterNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceCounter",
                table: "InvoiceCounter");

            migrationBuilder.RenameTable(
                name: "InvoiceCounter",
                newName: "InvoiceCounters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceCounters",
                table: "InvoiceCounters",
                columns: new[] { "UserId", "Year" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceCounters",
                table: "InvoiceCounters");

            migrationBuilder.RenameTable(
                name: "InvoiceCounters",
                newName: "InvoiceCounter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceCounter",
                table: "InvoiceCounter",
                columns: new[] { "UserId", "Year" });
        }
    }
}
