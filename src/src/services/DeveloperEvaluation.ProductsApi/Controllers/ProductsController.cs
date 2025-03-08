using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.Core.Utils;
using DeveloperEvaluation.Core.Web;
using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
using DeveloperEvaluation.ProductsApi.Application.DeleteProducts;
using DeveloperEvaluation.ProductsApi.Application.Queries;
using DeveloperEvaluation.ProductsApi.Models;
using DeveloperEvaluation.ProductsApi.Models.Request;
using DeveloperEvaluation.ProductsApi.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperEvaluation.ProductsApi.Controllers
{


    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        readonly IProductsQueries _productsQueries;

        public ProductsController(IProductsQueries productsQueries, IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productsQueries = productsQueries;
        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var request = new DeleteProductRequest { Id = id };
            var validator = new DeleteProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteProductsCommand>(request);
            var resp =  await _mediator.Send(command, cancellationToken);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Produto deletado com sucesso"
            });
        }

   

        /// <summary>
        /// GetProducts
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("All")]
        [ProducesResponseType(typeof(PaginatedResponse<Products>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken = default)
        {
            var response = new List<Products>();
            return Ok(await _productsQueries.GetAllProductsAsync(cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getPaginatedProductsRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(PaginatedResponse<Products>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProducts([FromQuery] GetPaginatedProductsRequest  getPaginatedProductsRequest, CancellationToken cancellationToken = default)
        {
            return OkPaginated(await _productsQueries.GetPaginatedProductsRequestAsync(getPaginatedProductsRequest, cancellationToken));
        }

        /// <summary>
        /// GetProduct
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken = default  )
        {

            var response = await _productsQueries.GetByIdAsync(id, cancellationToken);
            if (response == null)
                throw new KeyNotFoundException($"Produto com  ID {id} não encontrado");

            return base.Ok(_mapper.Map<GetProductResponse>(response));
        }

        /// <summary>
        /// CreateProducts
        /// </summary>
        /// <param name="request">CreateProductRequest</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProducts([FromBody] CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var validator = new CreateProductRequestValidator();

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateProductsCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            
            return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
            {
                Success = true,
                Message = "Product created successfully",
                Data = _mapper.Map<CreateProductResponse>(response)
            });
        }
    }
}
