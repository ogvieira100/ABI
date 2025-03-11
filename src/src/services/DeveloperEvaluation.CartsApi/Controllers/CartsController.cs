using AutoMapper;
using DeveloperEvaluation.CartsApi.Application.CreateCarts;
using DeveloperEvaluation.CartsApi.Models.Request;
using DeveloperEvaluation.CartsApi.Models.Response;
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
        /// CreateCarts
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartsResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCarts([FromBody] CreateCartsRequest request,
            CancellationToken cancellationToken = default)
        {
            var validator = new CreateCartsRequestValidator();

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateCartsCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateCartsResponse>
            {
                Success = true,
                Message = "Carts created successfully",
                Data = _mapper.Map<CreateCartsResponse>(response)
            });
        }
    }
}
