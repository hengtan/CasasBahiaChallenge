using CasasBahia.Api.DTOs;

namespace CasasBahia.Api.Service.Interface
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProducts();
        Task<ProdutoDTO> GetProductById(int id);
        Task AddProduct(ProdutoDTO ProdutoDTO);
        Task UpdateProduct(ProdutoDTO ProdutoDTO);
        Task DeleteProduct(int id);
    }
}