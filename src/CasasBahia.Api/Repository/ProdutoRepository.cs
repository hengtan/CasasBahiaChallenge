using CasasBahia.Api.Context;
using CasasBahia.Api.Model;
using CasasBahia.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CasasBahia.Api.Repository
{
    public class ProdutoRepository(AppDbContext context) : IProdutoRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            return await _context.Produtos
                .Where(predicate: p => p.IdProduto == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Produto> Create(Produto Produto)
        {
            _context.Produtos.Add(Produto);
            await _context.SaveChangesAsync();
            return Produto;
        }

        public async Task<Produto> Update(Produto Produto)
        {
            _context.Entry(Produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Produto;
        }

        public async Task<Produto> Delete(int id)
        {
            var Produto = await GetProdutoById(id);
            _context.Produtos.Remove(Produto);
            await _context.SaveChangesAsync();
            return Produto;
        }
    }
}
