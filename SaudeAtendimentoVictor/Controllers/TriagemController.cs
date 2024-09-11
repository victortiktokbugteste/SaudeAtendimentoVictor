using Microsoft.AspNetCore.Mvc;
using SaudeAtendimentoVictor.Interfaces;
using SaudeAtendimentoVictor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Controllers
{
    public class TriagemController : Controller
    {
        private readonly ITriagemRepository _triagemRepository;
        public TriagemController(ITriagemRepository triagemRepository)
        {
            _triagemRepository = triagemRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SalvarTriagem([FromBody] Triagem triagem)
        {
            var triagens = _triagemRepository.GetAllTriagensAsync().Result;

            if (triagens != null && triagens.Count() > 0)
            {
                if (triagens.Where(x => x.AtendimentoID == triagem.AtendimentoID).Count() > 0)
                    return Json(new { error = "Não é possível criar outra triagem para o mesmo atendimento.", success = false });

            }

            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                                          .SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage)
                                          .ToList();

                string error = string.Join(", ", errorMessages);

                return Json(new { error = error, success = false });
            }

            await _triagemRepository.AddTriagemAsync(triagem);
            return Json(new { success = true });
        }

        public async Task<JsonResult> ObterTriagens()
        {
            var triagens = await _triagemRepository.GetAllTriagensAsync();
            return Json(triagens);
        }

        public async Task<JsonResult> ObterEspecialidades()
        {
            var especialidades = await _triagemRepository.GetAllEspecialidadesAsync();
            return Json(especialidades);
        }
    }
}
