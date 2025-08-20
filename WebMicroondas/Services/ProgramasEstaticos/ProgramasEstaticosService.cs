using WebMicroondas.Dto.@in;
using WebMicroondas.Dto.@out;
using WebMicroondas.Models;
using WebMicroondas.Services.Microondas;

namespace WebMicroondas.Services.ProgramasEstaticos
{
    public class ProgramasEstaticosService
    {
        private readonly ProgramasRegistry _registry;
        private readonly MicroondasService _microondas;

        public ProgramasEstaticosService(ProgramasRegistry registry, MicroondasService microondas)
        {
            _registry = registry;
            _microondas = microondas;
        }

        public Task<ResponseModel<AquecimentoResponseDto>> IniciarPrograma(string nomePrograma)
        {
            try
            {
                var programa = _registry.BuscarPorNome(nomePrograma);

                var dto = new AquecimentoDto
                {
                    tempo = programa.tempo,
                    potencia = programa.potencia,
                    execucao = true,
                    status = Enuns.StatusMicroondasEnum.AQUECER
                };

                return _microondas.aquecimento(dto);
            }
            catch (KeyNotFoundException e)
            {
                var response = new ResponseModel<AquecimentoResponseDto>
                {
                    Status = false,
                    Message = e.Message
                };
                return Task.FromResult(response);
            }
        }

        public Task<ResponseModel<AquecimentoResponseDto>> PausarPrograma(AquecimentoDto dto)
        {
            return _microondas.pausarOuDesligar(dto);
        }

        public Task<ResponseModel<List<ProgramasEstasticosDto>>> BuscarTodasEstrategias()
        {
            var response = new ResponseModel<List<ProgramasEstasticosDto>>();

            var programas = _registry.ListarTodos();


            var dtoList = programas.Select(p => new ProgramasEstasticosDto
            {
                nome = p.nome,
                alimento = p.alimento,
                potencia = p.potencia,
                tempo = p.tempo,
                instrucao = p.instrucao,
                execucao = false,
                stringAquecimento = p.stringAquecimento,
                status = Enuns.StatusMicroondasEnum.DESLIGADO
            }).ToList();

            response.Data = dtoList;
            response.Status = true;

            return Task.FromResult(response);
        }
    }
}
