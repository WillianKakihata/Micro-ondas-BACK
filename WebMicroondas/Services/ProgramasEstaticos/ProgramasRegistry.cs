using WebMicroondas.Services.ProgramasEstaticos.strategys;

namespace WebMicroondas.Services.ProgramasEstaticos
{
    public class ProgramasRegistry
    {
        private readonly Dictionary<string, ProgramasStrategy> _programas;

        public ProgramasRegistry()
        {
            var estrategias = new List<ProgramasStrategy>
            {
                new PipocaStrategy(),
                new LeiteStrategy(),
                new CarneBovinaStrategy(),
                new FrangoStrategy(),
                new FeijaoStrategy()
            };

            if (estrategias.Any(p => p.stringAquecimento == "."))
                throw new Exception("String de aquecimento não pode ser '.'");

            if (estrategias.GroupBy(p => p.stringAquecimento).Any(g => g.Count() > 1))
                throw new Exception("Strings de aquecimento devem ser únicas.");

            _programas = estrategias.ToDictionary(p => p.nome.ToLower());
        }

        public IEnumerable<ProgramasStrategy> ListarTodos()
        {
            return _programas.Values;
        }
        public ProgramasStrategy BuscarPorNome(string nome)
        {
            if (_programas.TryGetValue(nome.ToLower(), out var programa))
                return programa;
            throw new KeyNotFoundException($"Programa '{nome}' não encontrado.");
        }
    }
}
