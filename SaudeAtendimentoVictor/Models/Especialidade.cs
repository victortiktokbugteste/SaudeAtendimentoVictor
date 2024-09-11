using System.ComponentModel.DataAnnotations;

namespace SaudeAtendimentoVictor.Models
{
    public class Especialidade
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
