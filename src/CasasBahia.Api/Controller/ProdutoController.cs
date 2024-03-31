using CasasBahia.Api.DTOs;
using CasasBahia.Api.Model;
using CasasBahia.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CasasBahia.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService productService)
        {
            _produtoService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduct(ProdutoDTO produtoDTO)
        {
            if (!IsValidProduct(produtoDTO))
                return BadRequest("Product is null");

            await _produtoService.AddProduct(produtoDTO);

            return CreatedAtRoute("GetProduct", new { id = produtoDTO.IdProduto },
                produtoDTO);
        }

        private bool IsValidProduct(ProdutoDTO produtoDTO)
        {
            return produtoDTO != null;
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<Produto>> GetProductById(int id)
        {
            var produto = await _produtoService.GetProductById(id);

            if (produto == null)
                return NotFound("Product not found");

            return Ok(produto);
        }
    }
}