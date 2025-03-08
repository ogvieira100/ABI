using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.ProductsApi.Models;
using DeveloperEvaluation.ProductsApi.Models.Request;

namespace DeveloperEvaluation.ProductsApi.Application.Queries
{
    public interface IProductsQueries
    {

        Task<Products?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Products>> GetAllProductsAsync(CancellationToken cancellationToken = default);

        Task<PaginatedList<Products>> GetPaginatedProductsRequestAsync(GetPaginatedProductsRequest getPaginatedProductsRequest, CancellationToken cancellationToken = default);

    }
}
