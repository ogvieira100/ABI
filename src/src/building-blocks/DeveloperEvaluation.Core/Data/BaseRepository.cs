using DeveloperEvaluation.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Data
{
    public class BaseRepository<TEntity>
                          : IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        public IUnitOfWork UnitOfWork { get; }

        public IRepositoryConsult<TEntity> RepositoryConsult { get; }

        readonly DbSet<TEntity> DbSet;

        readonly IDbContext _applicationContext;
        public BaseRepository(IUnitOfWork unitOfWork,
                              IRepositoryConsult<TEntity> repositoryConsult,
                              IDbContext applicationContext)
        {

            _applicationContext = applicationContext;
            UnitOfWork = unitOfWork;
            RepositoryConsult = repositoryConsult;
            DbSet = _applicationContext.Set<TEntity>();

        }
        public void Add(TEntity entity) => DbSet.Add(entity);

        public void Dispose() => GC.SuppressFinalize(this);

        public void Remove(TEntity entity) => DbSet.Remove(entity);

        public void Update(TEntity entity) => DbSet.Update(entity);

        public async Task AddAsync(TEntity entidade, CancellationToken cancellationToken = default) => await DbSet.AddAsync(entidade, cancellationToken);

        public async Task AddAsync<T>(T entidade, CancellationToken cancellationToken = default) where T : BaseEntity => await _applicationContext.Set<T>().AddAsync(entidade, cancellationToken);

        public void Remove<T>(T customer) where T : BaseEntity
             => _applicationContext.Set<T>().Remove(customer);

        public void RemoveRange(IEnumerable<TEntity> customer) => DbSet.RemoveRange(customer);
    }
}
