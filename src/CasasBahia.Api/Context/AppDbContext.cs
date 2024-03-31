using CasasBahia.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CasasBahia.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
               .HasKey(c => c.IdProduto);

            modelBuilder.Entity<Produto>()
            .Property(p => p.Nome)
            .HasMaxLength(50)
            .IsRequired();

            modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)            
            .HasColumnType("decimal(10,4)")
            .IsRequired();

            modelBuilder.Entity<Produto>()
            .Property(p => p.Quantidade)
            .IsRequired();

            modelBuilder.Entity<Produto>()
            .Property(p => p.DataCadastro)
            .IsRequired();
        }
    }
}
