using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperEvaluation.CartsApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartsDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdd",
                table: "CarrinhoItens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "CarrinhoItens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdd",
                table: "Carrinho",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Carrinho",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdd",
                table: "CarrinhoItens");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "CarrinhoItens");

            migrationBuilder.DropColumn(
                name: "DateAdd",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Carrinho");
        }
    }
}
