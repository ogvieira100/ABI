using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.ProductsApi.Dto;
using DeveloperEvaluation.ProductsApi.Models;
using DeveloperEvaluation.ProductsApi.Models.Request;
using System.Threading;

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

        public async Task<IEnumerable<Products>> GetAllProductsAsync( CancellationToken cancellationToken = default)
        {
            /*Dapper*/
            var query = @"
                SELECT 
		            ""Id"",
		            ""Titulo"",
		            ""Valor"",
		            ""Descricao"",
		            ""Categoria"",
		            ""Imagem"",
		            ""Rate"",
		            ""Contador""
	            FROM ""Produtos"";
            ";
            var allProducts =  await _baseProductsRepository.RepositoryConsult.SearchAsync<ProductsSearchDto>(query, cancellationToken);
            return allProducts.Select(x => _mapper.Map<Products>(x));
        } 

        public async Task<Products?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
                  => (await _baseProductsRepository.RepositoryConsult.SearchAsync(x => x.Id == Id,cancellationToken))?.FirstOrDefault();

        public async Task<PaginatedList<Products>> GetPaginatedProductsRequestAsync(GetPaginatedProductsRequest getPaginatedProductsRequest,
            CancellationToken  cancellationToken = default)
        {
            var query = _baseProductsRepository.RepositoryConsult.GetQueryable();

            if (!string.IsNullOrEmpty(getPaginatedProductsRequest.Description))
                query = query.Where(x => x.Description.Contains(getPaginatedProductsRequest.Description));

            if (!string.IsNullOrEmpty(getPaginatedProductsRequest.Title))
                query = query.Where(x => x.Title.Contains(getPaginatedProductsRequest.Title));

            if (!string.IsNullOrEmpty(getPaginatedProductsRequest.Category))
                query = query.Where(x => x.Category.Contains(getPaginatedProductsRequest.Category));

            var paged =  await query.PaginateAsync(getPaginatedProductsRequest, cancellationToken);

            return _mapper.Map<PaginatedList<Products>>(paged);
        }
    }
}
