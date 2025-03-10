using AutoMapper;
using DeveloperEvaluation.Core.Utils;
using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
using DeveloperEvaluation.ProductsApi.Application.DeleteProducts;
using DeveloperEvaluation.ProductsApi.Application.Queries;
using DeveloperEvaluation.ProductsApi.Controllers;
using DeveloperEvaluation.ProductsApi.Models;
using DeveloperEvaluation.ProductsApi.Models.Request;
using DeveloperEvaluation.ProductsApi.Models.Response;
using FluentValidation.Results;
using MediatR;
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
        public async Task CreateProduct_ShouldReturnCreated_WhenValidRequest()
        {
            // Arrange
            var request = new CreateProductRequest { Description = "New Product" };
            var validationResult = new ValidationResult();
            var command = new CreateProductsCommand { Description = "New Product" };
            var createResponse = new CreateProductsResult { Id = Guid.NewGuid() };

            var validatorMock = new Mock<CreateProductRequestValidator>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateProductRequest>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(validationResult);

            _mapperMock.Setup(m => m.Map<CreateProductsCommand>(It.IsAny<CreateProductRequest>())).Returns(command);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductsCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(createResponse);

            // Act
            var result = await _controller.CreateProducts(request);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var returnValue = Assert.IsType<ApiResponseWithData<CreateProductResponse>>(createdResult.Value);
            Assert.Equal("New Product", returnValue.Data.Id.ToString());
        }


        [Fact]
        public async Task GetProduct_ShouldReturnOk_WhenProductExists()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Products { Id = productId,  Description = "Product" };

            _productsQueriesMock.Setup(p => p.GetByIdAsync(productId, It.IsAny<CancellationToken>()))
                                .ReturnsAsync(product);

            _mapperMock.Setup(m => m.Map<GetProductResponse>(It.IsAny<Products>()))
                       .Returns(new GetProductResponse { Id = productId, Description = "Product" });

            // Act
            var result = await _controller.GetProduct(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ApiResponseWithData<GetProductResponse>>(okResult.Value);
            Assert.Equal(productId, returnValue.Data.Id);
        }


        [Fact]
        public async Task GetAllProducts_ShouldReturnOk_WhenProductsExist()
        {
            // Arrange
            var productList = new List<Products> { new Products { Id = Guid.NewGuid(), Description = "Product 1" } };

            _productsQueriesMock.Setup(p => p.GetAllProductsAsync(It.IsAny<CancellationToken>()))
                                .ReturnsAsync(productList);

            // Act
            var result = await _controller.GetAllProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<List<Products>>(okResult.Value);
            Assert.NotEmpty(returnValue);
        }


        [Fact]
        public async Task DeleteProduct_ShouldReturnOk_WhenValidRequest()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var request = new DeleteProductRequest { Id = productId };
            var validationResult = new ValidationResult();
            var command = new DeleteProductsCommand { Id = productId };
            var del = new DeleteProductResult();

            var apiResponse = new ApiResponse { Success = true, Message = "Produto deletado com sucesso" };

            var validatorMock = new Mock<DeleteProductRequestValidator>();
           
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<DeleteProductRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

            _mapperMock.Setup(m => m.Map<DeleteProductsCommand>(It.IsAny<DeleteProductRequest>())).Returns(command);
           
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteProductsCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(del);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ApiResponse>(okResult.Value);
            Assert.True(returnValue.Success);
            Assert.Equal("Produto deletado com sucesso", returnValue.Message);
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnBadRequest_WhenValidationFails()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var request = new DeleteProductRequest { Id = productId };
            var validationResult = new ValidationResult(new[] { new ValidationFailure("Id", "Invalid Id") });

            var validatorMock = new Mock<DeleteProductRequestValidator>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<DeleteProductRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains("Invalid Id", badRequestResult.Value.ToString());
        }

    }
}
