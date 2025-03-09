using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperEvaluation.ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                         table: "Produtos",
                         columns: new[] { "Id", "Titulo", "Valor", "Descricao", "Categoria", "Imagem", "Rate", "Contador" },
                         values: new object[,]
                         {
                    { Guid.NewGuid(), "Brahma", 5.99m, "Cerveja Pilsen da Ambev", "Bebidas", "brahma.jpg", 4.5m, 500 },
                    { Guid.NewGuid(), "Skol", 4.99m, "Cerveja Pilsen leve e refrescante", "Bebidas", "skol.jpg", 4.3m, 450 },
                    { Guid.NewGuid(), "Antarctica", 5.49m, "Cerveja tradicional do Brasil", "Bebidas", "antarctica.jpg", 4.4m, 470 },
                    { Guid.NewGuid(), "Bohemia", 6.99m, "Cerveja de puro malte", "Bebidas", "bohemia.jpg", 4.7m, 480 },
                    { Guid.NewGuid(), "Original", 7.99m, "Cerveja Pilsen encorpada", "Bebidas", "original.jpg", 4.8m, 490 },
                    { Guid.NewGuid(), "Budweiser", 6.49m, "Cerveja Premium da Ambev", "Bebidas", "budweiser.jpg", 4.6m, 510 },
                    { Guid.NewGuid(), "Stella Artois", 7.49m, "Cerveja Belga da Ambev", "Bebidas", "stella.jpg", 4.9m, 530 },
                    { Guid.NewGuid(), "Corona", 8.49m, "Cerveja mexicana da Ambev", "Bebidas", "corona.jpg", 4.8m, 520 },
                    { Guid.NewGuid(), "Beck's", 7.29m, "Cerveja de sabor marcante", "Bebidas", "becks.jpg", 4.7m, 500 },
                    { Guid.NewGuid(), "Caracu", 6.99m, "Cerveja escura e encorpada", "Bebidas", "caracu.jpg", 4.5m, 470 },
                    { Guid.NewGuid(), "Polar", 5.79m, "Cerveja do Sul do Brasil", "Bebidas", "polar.jpg", 4.3m, 460 },
                    { Guid.NewGuid(), "Franziskaner", 9.99m, "Cerveja de trigo premium", "Bebidas", "franziskaner.jpg", 4.9m, 540 },
                    { Guid.NewGuid(), "Hoegaarden", 9.49m, "Cerveja belga de trigo", "Bebidas", "hoegaarden.jpg", 4.8m, 550 },
                    { Guid.NewGuid(), "Leffe", 10.99m, "Cerveja belga de abadia", "Bebidas", "leffe.jpg", 4.9m, 560 },
                    { Guid.NewGuid(), "Quilmes", 7.99m, "Cerveja argentina da Ambev", "Bebidas", "quilmes.jpg", 4.6m, 530 },
                    { Guid.NewGuid(), "Wäls", 11.49m, "Cerveja artesanal brasileira", "Bebidas", "wals.jpg", 4.7m, 500 },
                    { Guid.NewGuid(), "Colorado", 10.99m, "Cerveja artesanal com toque de mel", "Bebidas", "colorado.jpg", 4.8m, 520 },
                    { Guid.NewGuid(), "Goose Island", 12.99m, "Cerveja artesanal americana", "Bebidas", "goose.jpg", 4.9m, 530 },
                    { Guid.NewGuid(), "Serramalte", 7.49m, "Cerveja encorpada e maltada", "Bebidas", "serramalte.jpg", 4.7m, 500 },
                    { Guid.NewGuid(), "Spaten", 8.99m, "Cerveja puro malte alemã", "Bebidas", "spaten.jpg", 4.8m, 510 }
                         });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
              table: "Produtos",
              keyColumn: "Titulo",
              keyValues: new object[] { "Brahma", "Skol", "Antarctica", "Bohemia", "Original", "Budweiser", "Stella Artois", "Corona", "Beck's", "Caracu", "Polar", "Franziskaner", "Hoegaarden", "Leffe", "Quilmes", "Wäls", "Colorado", "Goose Island", "Serramalte", "Spaten" }
          );
        }
    }
}
