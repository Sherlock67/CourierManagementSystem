using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierSystemDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fieldnamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "shipments",
                newName: "ShipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipId",
                table: "shipments",
                newName: "ShipmentId");
        }
    }
}
