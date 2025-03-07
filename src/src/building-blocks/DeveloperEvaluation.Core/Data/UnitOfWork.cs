using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public async Task<bool> CommitAsync() => await _dbContext.SaveChangesAsync() > 0;

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
