using WebMicroondas.Dto.@in;
using WebMicroondas.Dto.@out;
using WebMicroondas.Models;

namespace WebMicroondas.Services.Microondas
{
    public class MicroondasService : MicroondasInterface
    {
        

        public Task<ResponseModel<AquecimentoResponseDto>> aquecimento(AquecimentoDto dto)
        {
            ResponseModel<AquecimentoResponseDto> response = new ResponseModel<AquecimentoResponseDto>();
            var aquecer = new AquecimentoResponseDto();
            aquecer.potencia = dto.potencia ?? 10;
            aquecer.tempo = dto.tempo;
            aquecer.execucao = true;
            aquecer.status = Enuns.StatusMicroondasEnum.AQUECER;
            response.Data = aquecer;
            response.Status = true;
            return Task.FromResult(response);
        }

        public Task<ResponseModel<AquecimentoResponseDto>> inicioRapido()
        {
            ResponseModel<AquecimentoResponseDto> response = new ResponseModel<AquecimentoResponseDto>();
            var aquecer = new AquecimentoResponseDto();
            aquecer.tempo = 30;
            aquecer.potencia = 10;
            aquecer.execucao = true;
            aquecer.status = Enuns.StatusMicroondasEnum.AQUECER;
            response.Data = aquecer;
            response.Status = true;
            return Task.FromResult(response);
        }

        public Task<ResponseModel<AcrescentarTempoDto>> acrescimoTempo(AquecerDto dto)
        {
            var aquecer = new AcrescentarTempoDto();
            ResponseModel<AcrescentarTempoDto> response = new ResponseModel<AcrescentarTempoDto>();
            if (dto.execucao)
            {
                aquecer.tempo = dto.tempo + 30;
            }

            response.Data = aquecer;
            response.Status = true;
            return Task.FromResult(response);
        }

        public Task<ResponseModel<AquecimentoResponseDto>> pausarOuDesligar(AquecimentoDto dto)
        {
            var aquecer = new AquecimentoResponseDto();
            ResponseModel<AquecimentoResponseDto> response = new ResponseModel<AquecimentoResponseDto>();
            if (dto.execucao && dto.status == Enuns.StatusMicroondasEnum.AQUECER)
            {
                aquecer.tempo = dto.tempo;
                aquecer.execucao = false;
                aquecer.status = Enuns.StatusMicroondasEnum.PAUSADO;
            }else if (dto.execucao == false && dto.status == Enuns.StatusMicroondasEnum.PAUSADO)
            {
                aquecer.tempo = 0;
                aquecer.status = Enuns.StatusMicroondasEnum.DESLIGADO;
            }
            else
            {
                response.Message = "Não é possível pausar ou desligar a partir do estado atual.";
                response.Status = false;
                return Task.FromResult(response);
            }
            response.Data = aquecer;
            response.Status = true;
            return Task.FromResult(response);

        }
       


    }
}
