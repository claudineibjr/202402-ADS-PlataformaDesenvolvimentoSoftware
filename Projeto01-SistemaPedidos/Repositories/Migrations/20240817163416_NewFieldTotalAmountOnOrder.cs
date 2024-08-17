using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto01_OrdersManager.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldTotalAmountOnOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalAmout",
                table: "Orders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmout",
                table: "Orders");
        }
    }
}
