using System.ComponentModel.DataAnnotations.Schema;

namespace netchallenge.Domain.Entities
{
    public class Tratamento
    {
        public long Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        [Column("tipo")]  
        public string Tipo { get; set; } = string.Empty;

        [Column("custo")]
        public string Custo { get; set; } = string.Empty;

        public ICollection<Sinistro>? Sinistros { get; set; }
        public ICollection<Recomendacao>? Recomendacoes { get; set; }
    }
}