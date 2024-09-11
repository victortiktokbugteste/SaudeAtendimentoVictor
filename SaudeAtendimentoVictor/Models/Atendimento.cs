using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAtendimentoVictor.Models
{
    public class Atendimento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumeroSequencial { get; set; }

        [Required(ErrorMessage = "O paciente é obrigatório.")]
        public int? PacienteID { get; set; }
        public Paciente Paciente { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataHoraChegada { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public int? StatusID { get; set; }
        public Status Status { get; set; }
    }
}
