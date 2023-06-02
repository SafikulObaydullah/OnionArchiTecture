using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class countryFiledAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dteCreatedAt",
                table: "Cuountry",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dteUpdatedAt",
                table: "Cuountry",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Cuountry",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "strUpdatedBy",
                table: "Cuountry",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dteCreatedAt",
                table: "Cuountry");

            migrationBuilder.DropColumn(
                name: "dteUpdatedAt",
                table: "Cuountry");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Cuountry");

            migrationBuilder.DropColumn(
                name: "strUpdatedBy",
                table: "Cuountry");
        }
    }
}
