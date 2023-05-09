using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierSystemDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shipments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    ShipmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShipmentArrivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentSentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipmentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipments", x => x.ShipmentId);
                });
        }
    }
}
