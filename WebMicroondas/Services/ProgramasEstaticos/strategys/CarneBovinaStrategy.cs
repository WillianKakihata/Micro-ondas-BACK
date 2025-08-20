namespace WebMicroondas.Services.ProgramasEstaticos.strategys
{
    public class CarneBovinaStrategy: ProgramasStrategy
    {
        public string nome => "Carne Bovina";
        public string alimento => "Carne Bovina";
        public int potencia => 4;
        public int tempo => 840;
        public string instrucao => ": Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.";
        public string stringAquecimento => "^";
    }
}
