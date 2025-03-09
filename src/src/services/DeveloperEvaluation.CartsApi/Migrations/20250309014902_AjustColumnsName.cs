using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperEvaluation.CartsApi.Migrations
{
    /// <inheritdoc />
    public partial class AjustColumnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "CarrinhoItens",
                newName: "DataAtualizacao");

            migrationBuilder.RenameColumn(
                name: "DateAdd",
                table: "CarrinhoItens",
                newName: "DataInclusao");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Carrinho",
                newName: "DataAtualizacao");

            migrationBuilder.RenameColumn(
                name: "DateAdd",
                table: "Carrinho",
                newName: "DataInclusao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInclusao",
                table: "CarrinhoItens",
                newName: "DateAdd");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "CarrinhoItens",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "DataInclusao",
                table: "Carrinho",
                newName: "DateAdd");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Carrinho",
                newName: "DateUpdated");
        }
    }
}
