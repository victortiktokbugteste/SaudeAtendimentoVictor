using Microsoft.AspNetCore.Mvc;
using SaudeAtendimentoVictor.Interfaces;
using SaudeAtendimentoVictor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        public AtendimentoController(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ObterAtendimentos()
        {
            var atendimentos = await _atendimentoRepository.GetAllAtendimentosAsync();
            return Json(atendimentos);
        }

        public async Task<JsonResult> SalvarAtendimento([FromBody] Atendimento atendimento)
        {
            var atendimentos = _atendimentoRepository.GetAllAtendimentosAsync().Result;
            var lastSequenceNumber = 0;

            if (atendimentos != null && atendimentos.Count() > 0)
            {
                if(atendimentos.Where(x=>x.PacienteID == atendimento.PacienteID).Count() > 0)
                    return Json(new { error = "Não é possível criar outro atendimento para o mesmo paciente.", success = false });

                lastSequenceNumber = atendimentos.OrderByDescending(x => x.NumeroSequencial).FirstOrDefault().NumeroSequencial;
            }
            
            atendimento.NumeroSequencial = lastSequenceNumber + 1;
            atendimento.DataHoraChegada = DateTime.Now;

            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                                          .SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage)
                                          .ToList();

                string error = string.Join(", ", errorMessages);

                return Json(new { error = error, success = false });
            }

            await _atendimentoRepository.AddAtendimentoAsync(atendimento);
            return Json(new { success = true });
        }

        public async Task<JsonResult> ObterStatus()
        {
            var status = await _atendimentoRepository.GetAllStatusAsync();
            return Json(status);
        }
    }
}
