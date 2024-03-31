using CasasBahia.Api.DTOs;
using CasasBahia.Api.Model;

namespace CasasBahia.Api.Service.Interface
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProducts();
        Task<Produto> GetProductById(int id);
        Task <Produto>AddProduct(ProdutoDTO produtoDto);
        Task UpdateProduct(ProdutoDTO produtoDto);
        Task DeleteProduct(int id);
    }
}