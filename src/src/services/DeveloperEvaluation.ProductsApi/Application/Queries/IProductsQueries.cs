using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.ProductsApi.Models;
using DeveloperEvaluation.ProductsApi.Models.Request;

namespace DeveloperEvaluation.ProductsApi.Application.Queries
{
    public interface IProductsQueries
    {
        
        Task<Products?> GetByIdAsync(Guid Id);

        Task<PaginatedList<Products>> GetPaginatedProductsRequestAsync(GetPaginatedProductsRequest getPaginatedProductsRequest);

    }
}
