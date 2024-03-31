using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using CasasBahia.Api.Controller;
using CasasBahia.Api.Service.Interface;
using CasasBahia.Api.DTOs;
using Assert = Xunit.Assert;
using Produto = CasasBahia.Api.Model.Produto;

namespace CasasBahia.Api.Tests
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
        public async Task CreateProduct_ReturnsCreatedAtRouteResult_WhenProductIsNotNull()
        {
            var produtoDTO = new ProdutoDTO() { IdProduto = 1, /* other properties */ };
            var result = await _controller.CreateProduct(produtoDTO);
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
            Assert.Equal(produtoDTO, createdAtRouteResult.Value);
        }

        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            _mockService.Setup(service => service.GetProductById(It.IsAny<int>())).ReturnsAsync((Produto)null);
            var result = await _controller.GetProductById(1);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetProductById_ReturnsOk_WhenProductExists()
        {
            var produto = new Produto { IdProduto = 1, /* other properties */ };
            _mockService.Setup(service => service.GetProductById(It.IsAny<int>())).ReturnsAsync(produto);
            var result = await _controller.GetProductById(1);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(produto, okResult.Value);
        }
    }
}