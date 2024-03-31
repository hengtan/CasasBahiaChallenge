using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CasasBahia.Api.DTOs
{
    public class ProdutoDTO
    {
        [JsonIgnore]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Preço é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo Quantidade é obrigatório")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo Data do Cadastro é obrigatório")]
        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
