using CasasBahia.Api.Context;
using CasasBahia.Api.Model;
using CasasBahia.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CasasBahia.Api.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            return await _context.Produtos
                .Where(predicate: p => p.IdProduto == id)
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException();
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
            var produto = await GetProdutoById(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
            return produto;
        }
    }
}