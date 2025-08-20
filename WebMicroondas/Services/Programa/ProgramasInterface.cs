using WebMicroondas.Dto.@in;
using WebMicroondas.Models;

namespace WebMicroondas.Services.Programa
{
    public interface ProgramasInterface
    {
        Task<ResponseModel<List<ProgramasModel>>> getAllProgramas();
        Task<ResponseModel<ProgramasModel>> getById(int id);
        Task<ResponseModel<List<ProgramasModel>>> create(CreateProgramasDto createProgramasDto);
        Task<ResponseModel<List<ProgramasModel>>> update(UpdateProgramasDto updateProgramasDto, int id);
        Task<ResponseModel<List<ProgramasModel>>> delete(int id);

    }
}
