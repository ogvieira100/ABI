using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperEvaluation.CartsApi.Mapping
{
    public class CartsMapping : BaseMapping<Carts>
    {

        public override void Configure(EntityTypeBuilder<Carts> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.UserIdInsert)
                .HasColumnName("UsuarioInsert")
                .IsRequired();

            builder.Property(x => x.StatusCartsEn)
                .HasColumnName("StatusCarrinho")
                .IsRequired();

            builder.Property(x => x.DateOfSale)
                .HasColumnName("DataVenda")
                .IsRequired(false);

            builder.ToTable("Carrinho");

        }

    }
}
