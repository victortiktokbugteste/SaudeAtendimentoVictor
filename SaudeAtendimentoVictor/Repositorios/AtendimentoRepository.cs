using Microsoft.EntityFrameworkCore;
using SaudeAtendimentoVictor.Data;
using SaudeAtendimentoVictor.Interfaces;
using SaudeAtendimentoVictor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Repositorios
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AtendimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Models.Status>> GetAllStatusAsync()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task<IEnumerable<Atendimento>> GetAllAtendimentosAsync()
        {
            return await _context.Atendimento.Include(p=> p.Paciente).Include(s => s.Status).ToListAsync();
        }

        public async Task AddAtendimentoAsync(Atendimento atendimento)
        {
            _context.Atendimento.Add(atendimento);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAtendimentoAsync(int pacienteId)
        {
            var atendimento = await _context.Atendimento.Where(a => a.PacienteID == pacienteId).ToListAsync();
            _context.Atendimento.RemoveRange(atendimento);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
