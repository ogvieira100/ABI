using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.Core.Utils;
using DeveloperEvaluation.Core.Web;
using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
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
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {

            return Ok(new ApiResponse
            {
                Success = true

            });
        }

        /// <summary>
        /// UpdateProducts
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProducts([FromRoute] Guid id, CancellationToken cancellationToken)
        {

            var response = new { };
            return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
            {
                Success = true,
                Message = "User created successfully",
                Data = _mapper.Map<CreateProductResponse>(response)
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
        public async Task<IActionResult> GetAllProducts([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = new List<Products>();
            return OkPaginated(await PaginatedList<Products>.CreateAsync(response.AsQueryable(), response.Count, 30));
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
        public async Task<IActionResult> GetProducts([FromQuery] GetPaginatedProductsRequest  getPaginatedProductsRequest, CancellationToken cancellationToken)
        {
            return OkPaginated(await _productsQueries.GetPaginatedProductsRequestAsync(getPaginatedProductsRequest));
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
        public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {

            var response = await _productsQueries.GetByIdAsync(id);
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
        public async Task<IActionResult> CreateProducts([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
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
