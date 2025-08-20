using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMicroondas.Dto.@in;
using WebMicroondas.Services.Microondas;
using WebMicroondas.Services.ProgramasEstaticos;

namespace WebMicroondas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicroondasController : ControllerBase
    {
        private readonly MicroondasService _microondasService;
        public MicroondasController(MicroondasService microondasService)
        {
            _microondasService = microondasService;
        }

        [HttpPost("aquecimento")]
        public async Task<IActionResult> aquecer(AquecimentoDto aquecer)
        {
            var aquecimento = await _microondasService.aquecimento(aquecer);
            return Ok(aquecimento);
        }
        [HttpPost("inicioRapido")]
        public async Task<IActionResult> inicio_rapido()
        {
            var aquecimento = await _microondasService.inicioRapido();
            return Ok(aquecimento);
        }
        [HttpPost("acrescimoTempo")]
        public async Task<IActionResult> acrescentar_tempo(AquecerDto tempos)
        {
            var tempo = await _microondasService.acrescimoTempo(tempos);
            return Ok(tempo);
        }
        [HttpPost("pausar-desligar")]
        public async Task<IActionResult> pausar_desligar(AquecimentoDto pause)
        {
            var pausa_desliga = await _microondasService.aquecimento(pause);
            return Ok(pausa_desliga);
        }
    }
}
