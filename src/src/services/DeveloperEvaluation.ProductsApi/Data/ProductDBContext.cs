using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.ProductsApi.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DeveloperEvaluation.ProductsApi.Data
{
    public class ProductDBContext : DbContext, IDbContext
    {

        public ProductDBContext(DbContextOptions<ProductDBContext> options) 
            : base(options) { }

        public IDbConnection Connection 
            => this.Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyDateTimeConversion();
        }
    }
}
