using CasasBahia.Api.DTOs;
using CasasBahia.Api.Model;
using CasasBahia.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CasasBahia.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController(IProdutoService productService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduct(ProdutoDTO produtoDTO)
        {
            if (!IsValidProduct(produtoDTO))
                return BadRequest(
                    "Não foi possível criar o produto. Verifique os dados informados.");

            var response = await productService.AddProduct(produtoDTO);

            return Ok(response);
        }

        private static bool IsValidProduct(ProdutoDTO produtoDTO)
        {
            return produtoDTO != null;
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<Produto>> GetProductById(int id)
        {
            var produto = await productService.GetProductById(id);

            if (produto is null)
                return NotFound("Não foi possível encontrar o produto. Verifique o ID informado.");

            return Ok(produto);
        }
    }
}