namespace WebMicroondas.Services.ProgramasEstaticos.strategys
{
    public class LeiteStrategy: ProgramasStrategy
    {
        public string nome => "Leite";
        public string alimento => "Leite";
        public int potencia => 5;
        public int tempo => 300;
        public string instrucao => "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras.";
        public string stringAquecimento => "L";
    }
    
}
