using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperEvaluation.CartsApi.Mapping
{
    public class CartsItensMapping : BaseMapping<CartsItens>
    {
        public override void Configure(EntityTypeBuilder<CartsItens> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantidade")
                .IsRequired();

            builder.Property(x => x.Discounts)
                .HasPrecision(20, 5)
                .HasColumnName("Desconto")
                .IsRequired(false);

            builder.Property(x => x.UnitPrices)
               .HasPrecision(20, 5)
               .HasColumnName("PrecoUnitario")
               .IsRequired();

            /*relations One two many*/

            builder.HasOne(x => x.Carts)
                .WithMany(x => x.CartsItens)
                .HasForeignKey(x=>x.CartsId)
                .IsRequired(true);

            builder.HasOne(x => x.Product)
               .WithMany(x => x.CartsItens)
               .HasForeignKey(x => x.ProductId)
               .IsRequired(true);

            builder.ToTable("CarrinhoItens");
        }
    }
}
