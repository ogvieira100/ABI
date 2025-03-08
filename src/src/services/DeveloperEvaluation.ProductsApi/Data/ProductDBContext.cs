using DeveloperEvaluation.ProductsApi.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEvaluation.ProductsApi.Data
{
    public class ProductDBContext:DbContext
    {

        public ProductDBContext(DbContextOptions<ProductDBContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
}
