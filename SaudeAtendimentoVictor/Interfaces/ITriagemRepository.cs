using SaudeAtendimentoVictor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Interfaces
{
    public interface ITriagemRepository
    {
        Task<IEnumerable<Triagem>> GetAllTriagensAsync();
        Task<IEnumerable<Especialidade>> GetAllEspecialidadesAsync();
        Task AddTriagemAsync(Triagem triagem);
        Task<bool> DeleteTriagemAsync(int pacienteId);
    }
}
