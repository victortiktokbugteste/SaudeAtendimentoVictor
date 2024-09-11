using Microsoft.EntityFrameworkCore;
using SaudeAtendimentoVictor.Data;
using SaudeAtendimentoVictor.Interfaces;
using SaudeAtendimentoVictor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Repositorios
{
    public class TriagemRepository : ITriagemRepository
    {
        private readonly ApplicationDbContext _context;

        public TriagemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Triagem>> GetAllTriagensAsync()
        {
            return await _context.Triagem.Include(e => e.Especialidade).Include(a => a.Atendimento).ToListAsync();
        }

        public async Task<bool> DeleteTriagemAsync(int pacienteId)
        {
            var triagem = await _context.Triagem.Where(a => a.Atendimento.PacienteID == pacienteId).ToListAsync();
            _context.Triagem.RemoveRange(triagem);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Especialidade>> GetAllEspecialidadesAsync()
        {
            return await _context.Especialidade.ToListAsync();
        }

        public async Task AddTriagemAsync(Triagem triagem)
        {
            try
            {
                _context.Triagem.Add(triagem);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
