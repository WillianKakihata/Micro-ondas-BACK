namespace WebMicroondas.Services.ProgramasEstaticos.strategys
{
    public class FrangoStrategy: ProgramasStrategy
    {
        public string nome => "Frango";
        public string alimento => "Frango";
        public int potencia => 7;
        public int tempo => 480;
        public string instrucao => "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme";
        public string stringAquecimento => "$";
    }
}
