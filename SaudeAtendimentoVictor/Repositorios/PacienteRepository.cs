using Microsoft.EntityFrameworkCore;
using SaudeAtendimentoVictor.Data;
using SaudeAtendimentoVictor.Interfaces;
using SaudeAtendimentoVictor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Repositorios
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddPacienteAsync(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePacienteAsync(int Id)
        {
            var paciente = await _context.Paciente.FindAsync(Id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Paciente>> GetAllPacientesAsync()
        {
            return await _context.Paciente.ToListAsync();
        }
    }
}
