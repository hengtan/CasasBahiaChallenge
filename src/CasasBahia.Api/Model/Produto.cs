using System.Text.Json.Serialization;

namespace CasasBahia.Api.Model
{
    public class Produto
    {
        public int IdProduto { get; set; }

        public string? Nome { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
