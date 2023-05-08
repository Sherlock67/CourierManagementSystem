using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierSystemDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class booleanorderstatusintroduced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderStatus",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "orders");
        }
    }
}
