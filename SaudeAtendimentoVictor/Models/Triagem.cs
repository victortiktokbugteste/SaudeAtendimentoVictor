using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAtendimentoVictor.Models
{
    public class Triagem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O atendimento é obrigatório.")]
        public int? AtendimentoID { get; set; }
        public Atendimento Atendimento { get; set; }
        public string Sintomas { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string PressaoArterial { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Peso { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Altura { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        public int? EspecialidadeID { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
