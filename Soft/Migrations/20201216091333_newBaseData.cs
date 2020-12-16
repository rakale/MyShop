using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Soft.Migrations {
    public partial class newBaseData : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Catalogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Catalogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Catalogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Baskets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Baskets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "BasketItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "From",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "To",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "From",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "To",
                table: "BasketItems");
        }
    }
}
