using WebMicroondas.Dto.@in;
using WebMicroondas.Dto.@out;
using WebMicroondas.Models;

namespace WebMicroondas.Services.Microondas
{
    public interface MicroondasInterface
    {
      
        Task<ResponseModel<AquecimentoResponseDto>> aquecimento(AquecimentoDto dto);
        Task<ResponseModel<AquecimentoResponseDto>> inicioRapido();
        Task<ResponseModel<AcrescentarTempoDto>> acrescimoTempo(AquecerDto dto);
        Task<ResponseModel<AquecimentoResponseDto>> pausarOuDesligar(AquecimentoDto dto);
       

    }
}
