using Microsoft.AspNetCore.Mvc;
using SaudeAtendimentoVictor.Interfaces;
using SaudeAtendimentoVictor.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly ITriagemRepository _triagemRepository;
        public PacienteController(IPacienteRepository pacienteRepository,
            IAtendimentoRepository atendimentoRepository,
            ITriagemRepository triagemRepository)
        {
            _pacienteRepository = pacienteRepository;
            _atendimentoRepository = atendimentoRepository;
            _triagemRepository = triagemRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> CadastrarPaciente([FromBody] Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                                          .SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage)
                                          .ToList();

                string error = string.Join(", ", errorMessages);

                return Json(new { error = error, success  = false });
            }

            await _pacienteRepository.AddPacienteAsync(paciente);

            return Json(new { success = true });
        }

        public async Task<JsonResult> ExcluirPaciente([FromBody] Paciente paciente)
        {
            await _triagemRepository.DeleteTriagemAsync(paciente.Id);
            await _atendimentoRepository.DeleteAtendimentoAsync(paciente.Id);
            await _pacienteRepository.DeletePacienteAsync(paciente.Id);
            return Json(new { success = true });
        }

        public async Task<JsonResult> ObterPacientes()
        {
            var pacientes = await _pacienteRepository.GetAllPacientesAsync();
            return Json(pacientes);
        }

    }
}
