using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperEvaluation.CartsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var produtos = new object[,]
          {
                { Guid.Parse("11111111-1111-1111-1111-111111111111"), "Brahma", 5.99m, "Cerveja Pilsen da Ambev", "Bebidas", "brahma.jpg", 4.5m, 500 },
                { Guid.Parse("22222222-2222-2222-2222-222222222222"), "Skol", 4.99m, "Cerveja Pilsen leve e refrescante", "Bebidas", "skol.jpg", 4.3m, 450 },
                { Guid.Parse("33333333-3333-3333-3333-333333333333"), "Antarctica", 5.49m, "Cerveja tradicional do Brasil", "Bebidas", "antarctica.jpg", 4.4m, 470 },
                { Guid.Parse("44444444-4444-4444-4444-444444444444"), "Bohemia", 6.99m, "Cerveja de puro malte", "Bebidas", "bohemia.jpg", 4.7m, 480 },
                { Guid.Parse("55555555-5555-5555-5555-555555555555"), "Original", 7.99m, "Cerveja Pilsen encorpada", "Bebidas", "original.jpg", 4.8m, 490 },
                { Guid.Parse("66666666-6666-6666-6666-666666666666"), "Budweiser", 6.49m, "Cerveja Premium da Ambev", "Bebidas", "budweiser.jpg", 4.6m, 510 },
                { Guid.Parse("77777777-7777-7777-7777-777777777777"), "Stella Artois", 7.49m, "Cerveja Belga da Ambev", "Bebidas", "stella.jpg", 4.9m, 530 },
                { Guid.Parse("88888888-8888-8888-8888-888888888888"), "Corona", 8.49m, "Cerveja mexicana da Ambev", "Bebidas", "corona.jpg", 4.8m, 520 },
                { Guid.Parse("99999999-9999-9999-9999-999999999999"), "Beck's", 7.29m, "Cerveja de sabor marcante", "Bebidas", "becks.jpg", 4.7m, 500 },
                { Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Caracu", 6.99m, "Cerveja escura e encorpada", "Bebidas", "caracu.jpg", 4.5m, 470 },
                { Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Polar", 5.79m, "Cerveja do Sul do Brasil", "Bebidas", "polar.jpg", 4.3m, 460 },
                { Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Franziskaner", 9.99m, "Cerveja de trigo premium", "Bebidas", "franziskaner.jpg", 4.9m, 540 },
                { Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"), "Hoegaarden", 9.49m, "Cerveja belga de trigo", "Bebidas", "hoegaarden.jpg", 4.8m, 550 },
                { Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Leffe", 10.99m, "Cerveja belga de abadia", "Bebidas", "leffe.jpg", 4.9m, 560 },
                { Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"), "Quilmes", 7.99m, "Cerveja argentina da Ambev", "Bebidas", "quilmes.jpg", 4.6m, 530 },
                { Guid.Parse("11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Wäls", 11.49m, "Cerveja artesanal brasileira", "Bebidas", "wals.jpg", 4.7m, 500 },
                { Guid.Parse("22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Colorado", 10.99m, "Cerveja artesanal com toque de mel", "Bebidas", "colorado.jpg", 4.8m, 520 },
                { Guid.Parse("33333333-cccc-cccc-cccc-cccccccccccc"), "Goose Island", 12.99m, "Cerveja artesanal americana", "Bebidas", "goose.jpg", 4.9m, 530 },
                { Guid.Parse("44444444-dddd-dddd-dddd-dddddddddddd"), "Serramalte", 7.49m, "Cerveja encorpada e maltada", "Bebidas", "serramalte.jpg", 4.7m, 500 },
                { Guid.Parse("55555555-eeee-eeee-eeee-eeeeeeeeeeee"), "Spaten", 8.99m, "Cerveja puro malte alemã", "Bebidas", "spaten.jpg", 4.8m, 510 }
          };

            migrationBuilder.InsertData(
                table: "ProdutosCarrinho",
                columns: new[] { "Id", "Titulo", "Valor", "Descricao", "Categoria", "Imagem", "Rate", "Contador" },
                values: produtos
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var ids = new object[]
            {
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Guid.Parse("66666666-6666-6666-6666-666666666666"),
                Guid.Parse("77777777-7777-7777-7777-777777777777"),
                Guid.Parse("88888888-8888-8888-8888-888888888888"),
                Guid.Parse("99999999-9999-9999-9999-999999999999"),
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                Guid.Parse("11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Guid.Parse("22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Guid.Parse("33333333-cccc-cccc-cccc-cccccccccccc"),
                Guid.Parse("44444444-dddd-dddd-dddd-dddddddddddd"),
                Guid.Parse("55555555-eeee-eeee-eeee-eeeeeeeeeeee")
            };

            migrationBuilder.DeleteData(
                table: "ProdutosCarrinho",
                keyColumn: "Id",
                keyValues: ids
            );
        }
    }
}
