using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto01_OrdersManager.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RenamingFieldsToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_ClienteId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DataPedido",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClienteId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Customers",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "DataPedido");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_ClienteId");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "Nome");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_ClienteId",
                table: "Orders",
                column: "ClienteId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
