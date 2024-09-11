using SaudeAtendimentoVictor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task AddAtendimentoAsync(Atendimento atendimento);
        Task<IEnumerable<Models.Status>> GetAllStatusAsync();
        Task<IEnumerable<Atendimento>> GetAllAtendimentosAsync();
        Task<bool> DeleteAtendimentoAsync(int pacienteId);
    }
}
