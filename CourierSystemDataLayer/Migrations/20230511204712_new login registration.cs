using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierSystemDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newloginregistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "admins");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "customers",
                newName: "CustomerUsername");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "customers",
                newName: "CustomerPassword");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "customers");

            migrationBuilder.RenameColumn(
                name: "CustomerUsername",
                table: "customers",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "CustomerPassword",
                table: "customers",
                newName: "Password");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "customers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "customers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "admins",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "admins",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
