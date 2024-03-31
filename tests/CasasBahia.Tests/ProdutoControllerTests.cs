using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using CasasBahia.Api.Service.Interface;
using CasasBahia.Api.Controller;
using Assert = Xunit.Assert;
using CasasBahia.Api.DTOs;

namespace CasasBahia.Tests
{
    public class ProdutoControllerTests
    {
        private readonly Mock<IProdutoService> _mockService;
        private readonly ProdutoController _controller;

        public ProdutoControllerTests()
        {
            _mockService = new Mock<IProdutoService>();
            _controller = new ProdutoController(_mockService.Object);
        }

        [Fact]
        public async Task CreateProduct_ReturnsBadRequest_WhenProductIsNull()
        {
            var result = await _controller.CreateProduct(null);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Product is null", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateProduct_CallsAddProductAndReturnsCreatedAtRoute_WhenProductIsNotNull()
        {
            var productDTO = new ProdutoDTO { IdProduto = 1, /* other properties */ };
            var result = await _controller.CreateProduct(productDTO);

            _mockService.Verify(service => service.AddProduct(productDTO), Times.Once);

            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
            Assert.Equal("GetProduct", createdAtRouteResult.RouteName);
            Assert.Equal(productDTO.IdProduto, createdAtRouteResult.RouteValues["id"]);
            Assert.Equal(productDTO, createdAtRouteResult.Value);
        }
        
        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            _mockService.Setup(service => service.GetProductById(It.IsAny<int>())).ReturnsAsync((ProdutoDTO)null);

            var result = await _controller.GetProductById(1);

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetProductById_ReturnsOk_WhenProductExists()
        {
            var produtoDTO = new ProdutoDTO { IdProduto = 1, /* other properties */ };
            _mockService.Setup(service => service.GetProductById(It.IsAny<int>())).ReturnsAsync(produtoDTO);

            var result = await _controller.GetProductById(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(produtoDTO, okResult.Value);
        }
    }
}