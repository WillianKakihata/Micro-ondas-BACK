using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebMicroondas.Dto.@in;
using WebMicroondas.Models;
using WebMicroondas.Services.Microondas;
using WebMicroondas.Services.Programa;

namespace WebMicroondas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramasController : ControllerBase
    {
        private readonly ProgramasInterface _programasInterface;
        public ProgramasController(ProgramasInterface programasInterface)
        {
            _programasInterface = programasInterface;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ResponseModel<List<ProgramasModel>>>> findAll()
        {
            var microondas = await _programasInterface.getAllProgramas();
            return Ok(microondas);
        }

        [HttpGet("list/{id}")]
        public async Task<ActionResult<ResponseModel<ProgramasModel>>> findById(int id)
        {
            var microondas = await _programasInterface.getById(id);
            return Ok(microondas);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseModel<ProgramasModel>>> create([FromBody] CreateProgramasDto dto)
        {
            var programas = await _programasInterface.create(dto);
            return Created(
                "/api/programas/",
                programas);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResponseModel<ProgramasModel>>> delete(int id)
        {
            var programas = await _programasInterface.delete(id);
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ResponseModel<ProgramasModel>>> put([FromBody] UpdateProgramasDto dto, int id)
        {
            var microondas = await _programasInterface.update(dto, id);
            return NoContent();
        }
    }
}
