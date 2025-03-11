using DeveloperEvaluation.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Data
{
 
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Add(TEntity entidade);

        Task AddAsync(TEntity entidade,CancellationToken cancellationToken = default);

        Task AddAsync<T>(T entidade, CancellationToken cancellationToken = default) where T : BaseEntity;

        void Update(TEntity customer);

        void Remove(TEntity customer);

        void RemoveRange(IEnumerable<TEntity> customer);

        void Remove<T>(T customer) where T : BaseEntity;

        IUnitOfWork UnitOfWork { get; }

        IRepositoryConsult<TEntity> RepositoryConsult { get; }
    }
}
