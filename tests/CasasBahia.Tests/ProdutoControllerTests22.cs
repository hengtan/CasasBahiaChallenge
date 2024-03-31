// using Xunit;
// using Moq;
// using Microsoft.AspNetCore.Mvc;
// using CasasBahia.Api.Service.Interface;
// using CasasBahia.Api.Controller;
// using Assert = Xunit.Assert;
// using CasasBahia.Api.DTOs;
// using CasasBahia.Api.Model;
// using Microsoft.EntityFrameworkCore;
// using Produto = CasasBahia.Api.Model.Produto;
//
// // using Produto = CasasBahia.Api.DTOs.Produto;
//
// namespace CasasBahia.Tests
// {
//     public class ProdutoControllerTests22(IProdutoService productService)
//     {
//         private readonly IProdutoService _produtoService = productService;
//
//         // private readonly Mock<IProdutoService> _mockService;
//         private readonly ProdutoController _controller;
//
//         // public ProdutoControllerTests22()
//         // {
//         //     // _mockService = new Mock<IProdutoService>();
//         //     _controller = new ProdutoController(IProdutoService productService);: 
//         // }
//
//
//         [Fact]
//         public async Task ProdutoCreateRandomProduct2()
//         {
//             var random = new Random();
//             _controller.CreateProduct(new Produto
//             {
//                 Nome = $"Produto {random.Next(1, 20)}",
//                 Preco = Math.Round((decimal)(random.NextDouble() * (20 - 1) + 1), 2),
//                 Quantidade = random.Next(1, 20),
//                 DataCadastro = DateTime.Now,
//                 DataAlteracao = DateTime.Now
//             });
//             // return new Api.Model.Produto
//             // {
//             //     Nome = $"Produto {random.Next(1, 20)}",
//             //     Preco = (decimal)(random.NextDouble() * (20 - 1) + 1),
//             //     Quantidade = random.Next(1, 20),
//             //     DataCadastro = DateTime.Now,
//             //     DataAlteracao = DateTime.Now
//             // }
//         }
//
// // [Fact]
// // public async Task Create_A_Something()
// // {
// //     var p = CreateRandomProduct();
// //     var result = await _controller.CreateProduct(p);
// // // }
// //
// //         [Fact]
// //         public async Task CreateProduct_ReturnsBadRequest_WhenProductIsNull()
// //         {
// //             var result = await _controller.CreateProduct(null);
// //             var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
// //             Assert.Equal("Product is null", badRequestResult.Value);
// //         }
// //
// //         [Fact]
// //         public async Task CreateProduct_CallsAddProductAndReturnsCreatedAtRoute_WhenProductIsNotNull()
// //         {
// //             var produto = new Api.Model.Produto { IdProduto = 1, /* other properties */ };
// //             var result = await _controller.CreateProduct(produto);
// //
// //             _mockService.Verify(service => service.AddProduct(produto), Times.Once);
// //
// //             var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
// //             Assert.Equal("GetProduct", createdAtRouteResult.RouteName);
// //             Assert.Equal(produto.IdProduto, createdAtRouteResult.RouteValues["id"]);
// //             Assert.Equal(produto, createdAtRouteResult.Value);
// //         }
// //
// //         [Fact]
// //         public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
// //         {
// //             _mockService.Setup(service => service.GetProductById(It.IsAny<int>()))
// //                 .ReturnsAsync((Func<Api.DTOs.Produto>)null);
// //
// //             var result = await _controller.GetProductById(1);
// //
// //             Assert.IsType<NotFoundObjectResult>(result.Result);
// //         }
//
//         // [Fact]
//         // public async Task GetProductById_ReturnsOk_WhenProductExists()
//         // {
//         //     var produtoDTO = new Produto { IdProduto = 1, /* other properties */ };
//         //     _mockService.Setup(service => service.GetProductById(It.IsAny<int>())).ReturnsAsync(produtoDTO);
//         //
//         //     var result = await _controller.GetProductById(1);
//         //
//         //     var okResult = Assert.IsType<OkObjectResult>(result.Result);
//         //     Assert.Equal(produtoDTO, okResult.Value);
//         // }
//     }
// }