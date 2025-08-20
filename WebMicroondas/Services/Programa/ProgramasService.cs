using Microsoft.EntityFrameworkCore;
using WebMicroondas.data;
using WebMicroondas.Dto.@in;
using WebMicroondas.Models;
using WebMicroondas.Services.ProgramasEstaticos;
using WebMicroondas.Services.ProgramasEstaticos.strategys;

namespace WebMicroondas.Services.Programa
{
    public class ProgramasService : ProgramasInterface
    {
        public readonly AppDbContext _context;
        public ProgramasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ProgramasModel>>> create(CreateProgramasDto createProgramasDto)
        {
            ResponseModel<List<ProgramasModel>> response = new ResponseModel<List<ProgramasModel>>();
            try
            {
                var estrategias = new List<ProgramasStrategy>
                    {
                    new PipocaStrategy(),
                    new LeiteStrategy(),
                    new CarneBovinaStrategy(),
                    new FrangoStrategy(),
                    new FeijaoStrategy()
                };


                var programas = new ProgramasModel()
                {
                    nome = createProgramasDto.nome,
                    potencia = createProgramasDto.potencia,
                    tempo = createProgramasDto.tempo,
                    instrucao = createProgramasDto.instrucao,
                    stringAquecimento = createProgramasDto.stringAquecimento
                };

                var microondasBD = await _context.Programas
                    .FirstOrDefaultAsync(db => db.stringAquecimento == createProgramasDto.stringAquecimento);

                if (microondasBD != null)
                {
                    throw new Exception($"String de aquecimento não pode ser igual ao '{microondasBD.stringAquecimento}' do {microondasBD.nome}");
                }

                if (createProgramasDto.stringAquecimento == ".")
                    throw new Exception("String de aquecimento não pode ser '.'");

                if (estrategias.Any(p => p.stringAquecimento == createProgramasDto.stringAquecimento))
                    throw new Exception($"String de aquecimento '{createProgramasDto.stringAquecimento}' já pertence a um programa fixo.");

                if (estrategias.GroupBy(p => p.stringAquecimento).Any(g => g.Count() > 1))
                    throw new Exception("Strings de aquecimento das estratégias devem ser únicas.");


                _context.Add(programas);
                await _context.SaveChangesAsync();

                response.Data = await _context.Programas.ToListAsync();
                response.Message = "Program created successfully";
                response.Status = true;
                return response;
            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ProgramasModel>>> delete(int id)
        {
            ResponseModel<List<ProgramasModel>> response = new ResponseModel<List<ProgramasModel>>();
            try
            {
                var microondas = await _context.Programas.FirstOrDefaultAsync(db => db.id == id);
                if (microondas == null)
                {
                    response.Message = "Microwave not found";
                    response.Status = false;
                    return response;
                }
                _context.Remove(microondas);
                await _context.SaveChangesAsync();
                response.Data = await _context.Programas.ToListAsync();
                response.Message = "Microwave deleted successfully";
                return response;
            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ProgramasModel>>> getAllProgramas()
        {
            ResponseModel<List<ProgramasModel>> response = new ResponseModel<List<ProgramasModel>>();
            try
            {
                var program = await _context.Programas.ToListAsync();
                response.Data = program;
                response.Message = "program retrieved successfully";
                response.Status = true;
                return response;
            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<ProgramasModel>> getById(int id)
        {
            ResponseModel<ProgramasModel> response = new ResponseModel<ProgramasModel>();
            try
            {
                var program = await _context.Programas.FirstOrDefaultAsync(db => db.id == id);
                if (program == null)
                {
                    response.Message = "Program not found";
                    response.Status = false;
                    return response;
                }
                response.Data = program;
                response.Message = "program retrieved successfully";
                response.Status = true;
                return response;
            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ProgramasModel>>> update(UpdateProgramasDto updateProgramasDto, int id)
        {
            ResponseModel<List<ProgramasModel>> response = new ResponseModel<List<ProgramasModel>>();
            try
            {
                var program = await _context.Programas.FirstOrDefaultAsync(db => db.id == updateProgramasDto.id);
                if (program == null)
                {
                    response.Message = "program not found";
                    response.Status = false;
                    return response;
                }
                program.id = updateProgramasDto.id;
                program.nome = updateProgramasDto.nome;
                program.potencia = updateProgramasDto.potencia;
                program.tempo = updateProgramasDto.tempo;
                program.instrucao = updateProgramasDto.instrucao;

                _context.Update(program);
                response.Data = await _context.Programas.ToListAsync();
                response.Message = "program updated successfully";
                return response;


            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.Status = false;
                return response;
            }

        }
    }
}