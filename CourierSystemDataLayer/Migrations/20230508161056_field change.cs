using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierSystemDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fieldchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ConsignmentNumber",
                table: "orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.AlterColumn<string>(
                name: "ConsignmentNumber",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
