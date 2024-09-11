using System.ComponentModel.DataAnnotations;

namespace SaudeAtendimentoVictor.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [MaxLength(20)]
        public string Sexo { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}
