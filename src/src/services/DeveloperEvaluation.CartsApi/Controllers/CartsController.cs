using AutoMapper;
using DeveloperEvaluation.Core.Utils;
using DeveloperEvaluation.Core.Web;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperEvaluation.CartsApi.Controllers
{
    public class CartsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CartsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        /// <summary>
        /// CreateProducts
        /// </summary>
        /// <param name="request">CreateProductRequest</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[HttpPost]
        //[ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> CreateCarts([FromBody] CreateProductRequest request, CancellationToken cancellationToken = default)
        //{
        //    var validator = new CreateProductRequestValidator();

        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<CreateProductsCommand>(request);
        //    var response = await _mediator.Send(command, cancellationToken);

        //    return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        //    {
        //        Success = true,
        //        Message = "Product created successfully",
        //        Data = _mapper.Map<CreateProductResponse>(response)
        //    });
        //}


    }
}
