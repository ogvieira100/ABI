using Dapper;
using DeveloperEvaluation.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Data
{
    public class RepositoryConsult<TEntity> : IRepositoryConsult<TEntity> where TEntity : BaseEntity
    {
        readonly IDbContext _context;
        protected readonly DbSet<TEntity> DbSet;
        public RepositoryConsult(IDbContext Context)
        {
            _context = Context;
            DbSet = _context.Set<TEntity>();
        }

        public void Dispose() => GC.SuppressFinalize(this);
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) => await DbSet.AnyAsync(predicate, cancellationToken);
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) => await DbSet.ToListAsync(cancellationToken);
        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) => await DbSet.Where(predicate).ToListAsync(cancellationToken);
        public IQueryable<TEntity> GetQueryable() => DbSet.AsQueryable();
        public async Task<IEnumerable<TEntity>> SearchAsync(string query, CancellationToken cancellationToken = default)
        => await _context.Connection.QueryAsync<TEntity>(new CommandDefinition(query, cancellationToken: cancellationToken));
        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(x => x.Id == id);
    }
}
