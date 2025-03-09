using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperEvaluation.CartsApi.Mapping
{
    public class ProductMapping : BaseMapping<Products>
    {
        public override void Configure(EntityTypeBuilder<Products> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title)
                .HasColumnName("Titulo")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("Descricao")
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(p => p.Ratting, owned =>
            {

                owned.Property(d => d.Rate)
                    .HasColumnName("Rate")
                    .HasPrecision(20, 5)
                    .IsRequired(false);

                owned.Property(d => d.Count)
                  .HasColumnName("Contador")
                  .IsRequired(false);

            });

            builder.Property(x => x.Image)
              .HasColumnName("Imagem")
              .HasMaxLength(20)
              .IsRequired(false);

            builder.Property(x => x.Category)
              .HasColumnName("Categoria")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("Valor")
                .HasPrecision(20, 5)
                .IsRequired();

            builder.ToTable("ProdutosCarrinho");

        }
    }
}
