using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class CustomerInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "UpadteCountries",
                newName: "strUpdatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UpadteCountries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dteCreatedAt",
                table: "UpadteCountries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dteUpdatedAt",
                table: "UpadteCountries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "UpadteCountries",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasesProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInfos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UpadteCountries");

            migrationBuilder.DropColumn(
                name: "dteCreatedAt",
                table: "UpadteCountries");

            migrationBuilder.DropColumn(
                name: "dteUpdatedAt",
                table: "UpadteCountries");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "UpadteCountries");

            migrationBuilder.RenameColumn(
                name: "strUpdatedBy",
                table: "UpadteCountries",
                newName: "UpdateBy");
        }
    }
}
