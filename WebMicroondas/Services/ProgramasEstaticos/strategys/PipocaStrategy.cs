namespace WebMicroondas.Services.ProgramasEstaticos.strategys
{
    public class PipocaStrategy: ProgramasStrategy
    {
        public string nome => "Pipoca";
        public string alimento => "Pipoca";
        public int potencia => 7;
        public int tempo => 180;
        public string instrucao => "Observar o barulho de estouros do milho; se houver intervalo maior que 10 segundos entre estouros, interrompa o aquecimento.";
        public string stringAquecimento => "P";
    }
}
