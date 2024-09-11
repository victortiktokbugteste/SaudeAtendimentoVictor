using SaudeAtendimentoVictor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllPacientesAsync();
        Task AddPacienteAsync(Paciente paciente);
        Task<bool> DeletePacienteAsync(int Id);
    }
}
