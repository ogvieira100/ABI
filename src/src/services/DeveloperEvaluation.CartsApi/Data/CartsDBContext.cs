using DeveloperEvaluation.CartsApi.Mapping;
using DeveloperEvaluation.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DeveloperEvaluation.CartsApi.Data
{
    public class CartsDBContext : DbContext, IDbContext
    {
        public CartsDBContext(DbContextOptions<CartsDBContext> options)
          : base(options) { }

        public IDbConnection Connection
            => this.Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CartsItensMapping());
            modelBuilder.ApplyConfiguration(new CartsMapping());
        }
    }
}
