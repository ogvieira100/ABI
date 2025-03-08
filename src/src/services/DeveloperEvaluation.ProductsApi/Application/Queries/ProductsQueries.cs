using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.ProductsApi.Models;
using DeveloperEvaluation.ProductsApi.Models.Request;

namespace DeveloperEvaluation.ProductsApi.Application.Queries
{
    public class ProductsQueries : IProductsQueries
    {

        readonly IBaseRepository<Products> _baseProductsRepository;
        readonly IMapper _mapper;
        public ProductsQueries(IMapper mapper, IBaseRepository<Products> baseProductsRepository)
        {
            _baseProductsRepository = baseProductsRepository;
            _mapper = mapper;
        }
        public async Task<Products?> GetByIdAsync(Guid Id)
        => (await _baseProductsRepository.RepositoryConsult.SearchAsync(x => x.Id == Id))?.FirstOrDefault();

        public async Task<PaginatedList<Products>> GetPaginatedProductsRequestAsync(GetPaginatedProductsRequest getPaginatedProductsRequest)
        {
            var query = _baseProductsRepository.RepositoryConsult.GetQueryable();

            if (!string.IsNullOrEmpty(getPaginatedProductsRequest.Description))
                query = query.Where(x => x.Description.Contains(getPaginatedProductsRequest.Description));

            if (!string.IsNullOrEmpty(getPaginatedProductsRequest.Title))
                query = query.Where(x => x.Title.Contains(getPaginatedProductsRequest.Title));

            if (!string.IsNullOrEmpty(getPaginatedProductsRequest.Category))
                query = query.Where(x => x.Category.Contains(getPaginatedProductsRequest.Category));

            var paged =  await query.PaginateAsync(getPaginatedProductsRequest);

            return _mapper.Map<PaginatedList<Products>>(paged);
        }
    }
}
