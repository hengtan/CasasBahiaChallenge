using CasasBahia.Api.Model;

namespace CasasBahia.Api.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetProdutoById(int id);
        Task<Produto> Create(Produto produto);
        Task<Produto> Update(Produto produto);
        Task<Produto> Delete(int id);
    }
}