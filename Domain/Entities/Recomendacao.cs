using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace netchallenge.Domain.Entities
{
    public class Recomendacao
    {
        public long Id { get; set; }

        [Column("paciente_id")]
        public long PacienteId { get; set; }

        [ForeignKey("PacienteId")]  
        public Paciente Paciente { get; set; } = new Paciente();

        [Column("tratamento_id")]
        public long TratamentoId { get; set; }

        [ForeignKey("TratamentoId")]  
        public Tratamento Tratamento { get; set; } = new Tratamento();

        [Column("data_recomendacao")]
        public DateTime DataRecomendacao { get; set; }

        [Column("motivo")]
        public string Motivo { get; set; } = string.Empty;
    }
}