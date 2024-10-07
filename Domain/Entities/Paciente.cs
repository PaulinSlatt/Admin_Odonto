using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netchallenge.Domain.Entities
{
    public class Paciente
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;  

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email não é um endereço de email válido.")]
        public string Email { get; set; } = string.Empty;  

        [Column("data_nascimento")]  
        public DateTime? DataNascimento { get; set; }

        public string Genero { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string? Complemento { get; set; } 
        public string Numero { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;

        public ICollection<Sinistro>? Sinistros { get; set; }
        public ICollection<Recomendacao>? Recomendacoes { get; set; }
    }
}