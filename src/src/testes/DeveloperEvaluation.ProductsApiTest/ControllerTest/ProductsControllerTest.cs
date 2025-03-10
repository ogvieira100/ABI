using AutoMapper;
using DeveloperEvaluation.Core.Utils;
using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
using DeveloperEvaluation.ProductsApi.Application.DeleteProducts;
using DeveloperEvaluation.ProductsApi.Application.Queries;
using DeveloperEvaluation.ProductsApi.Controllers;
using DeveloperEvaluation.ProductsApi.Models;
using DeveloperEvaluation.ProductsApi.Models.Request;
using DeveloperEvaluation.ProductsApi.Models.Response;
using DeveloperEvaluation.ProductsApi.ValueObjects;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.ProductsApiTest.ControllerTest
{
  public  class ProductsControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductsQueries> _productsQueriesMock;
        private readonly ProductsController _controller;

        public ProductsControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _productsQueriesMock = new Mock<IProductsQueries>();
            _controller = new ProductsController(_productsQueriesMock.Object, _mediatorMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateProducts_ShouldReturnBadRequest_WhenValidationFails()
        {
            // Arrange
            var request = new CreateProductRequest { Title = "Short", Description = "Too short" };
            var validator = new CreateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            // Act
            var result = await _controller.CreateProducts(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult!.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task CreateProducts_ShouldReturnCreated_WhenSuccessful()
        {
            // Arrange
            var request = new CreateProductRequest
            {
                Title = "Valid Product Title",
                Description = "Valid description that meets length requirements.",
                Price = 10.0m,
                Category = "Electronics",
                Image = "image.jpg",
                Rate = 4.5m,
                Count = 100
            };

            var command = new CreateProductsCommand
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                Image = request.Image,
                Ratting = new RattingValueObjects()
            };

            var response = new CreateProductsResult { Id = Guid.NewGuid() };
            _mapperMock.Setup(m => m.Map<CreateProductsCommand>(request)).Returns(command);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductsCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);
            _mapperMock.Setup(m => m.Map<CreateProductResponse>(response))
                       .Returns(new CreateProductResponse { Id = response.Id });

            // Act
            var result = await _controller.CreateProducts(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<CreatedResult>();
            var createdResult = result as CreatedResult;
            createdResult!.StatusCode.Should().Be(StatusCodes.Status201Created);
            createdResult.Value.Should().BeOfType<ApiResponseWithData<CreateProductResponse>>();
            var responseData = createdResult.Value as ApiResponseWithData<CreateProductResponse>;
            responseData!.Success.Should().BeTrue();
            responseData.Message.Should().Be("Product created successfully");
            responseData.Data.Should().NotBeNull();
            responseData.Data!.Id.Should().Be(response.Id);
        }
    }
}
