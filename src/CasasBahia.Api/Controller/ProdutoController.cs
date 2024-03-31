using CasasBahia.Api.DTOs;
using CasasBahia.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CasasBahia.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController(IProdutoService productService) : ControllerBase
    {
        private readonly IProdutoService _produtoService = productService;

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> CreateProduct(ProdutoDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest("Product is null");

            await _produtoService.AddProduct(productDTO);

            return CreatedAtRoute("GetProduct", new { id = productDTO.IdProduto },
                               productDTO);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProdutoDTO>> GetProductById(int id)
        {
            var productDTO = await _produtoService.GetProductById(id);

            if (productDTO == null)
                return NotFound("Product not found");

            return Ok(productDTO);
        }
    }
}