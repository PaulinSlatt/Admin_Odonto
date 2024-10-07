using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netchallenge.Domain.Entities
{
    public class Sinistro
    {
        [Key]  
        [Column("id")]  
        public long Id { get; set; }

        [Column("paciente_id")]  
        public long PacienteId { get; set; }

        [ForeignKey("PacienteId")]  
        public Paciente Paciente { get; set; } = new Paciente();

        [Column("tratamento_id")]  
        public long TratamentoId { get; set; }

        [ForeignKey("TratamentoId")] 
        public Tratamento Tratamento { get; set; } = new Tratamento();

        [Column("data_ocorrencia")]  
        public DateTime DataOcorrencia { get; set; }

        [Column("valor_reembolsado")]  
        [StringLength(255)]  
        public string ValorReembolsado { get; set; } = string.Empty;

        [Column("status")]  
        [StringLength(50)]  
        public string Status { get; set; } = string.Empty;
    }
}