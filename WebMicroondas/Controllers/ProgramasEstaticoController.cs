using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMicroondas.Dto.@in;
using WebMicroondas.Dto.@out;
using WebMicroondas.Services.ProgramasEstaticos;

namespace WebMicroondas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramasEstaticoController : ControllerBase
    {
        private readonly ProgramasEstaticosService _programasEstaticosService;
        public ProgramasEstaticoController(ProgramasEstaticosService programasEstaticosService)
        {
            _programasEstaticosService = programasEstaticosService;
        }

        [HttpPost("{nome}/iniciar")]
        public async Task<IActionResult> IniciarPrograma(string nome)
        {
            var response = await _programasEstaticosService.IniciarPrograma(nome);
            return Ok(response);
        }

        [HttpPost("pausar")]
        public async Task<IActionResult> PausarPrograma([FromBody] AquecimentoDto dto)
        {
            var response = await _programasEstaticosService.PausarPrograma(dto);
            return Ok(response);
        }

        [HttpPost("listar")]
        public async Task<IActionResult> ListarProgramas()
        {
            var response = await _programasEstaticosService.BuscarTodasEstrategias();
            return Ok(response);
        }

    }
}
