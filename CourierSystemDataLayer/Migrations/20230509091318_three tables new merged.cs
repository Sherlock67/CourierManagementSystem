using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierSystemDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class threetablesnewmerged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shipmentInfos",
                columns: table => new
                {
                    ShipmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShipmentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingTerms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipVia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipmentInfos", x => x.ShipmentId);
                });

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    ShipmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShipmentSentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipmentArrivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipments", x => x.ShipmentId);
                });

            migrationBuilder.CreateTable(
                name: "shippers",
                columns: table => new
                {
                    ShipperId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShipperName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipperPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippers", x => x.ShipperId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shipmentInfos");

            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.DropTable(
                name: "shippers");
        }
    }
}
