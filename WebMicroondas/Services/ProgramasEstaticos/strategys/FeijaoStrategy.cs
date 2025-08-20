namespace WebMicroondas.Services.ProgramasEstaticos.strategys
{
    public class FeijaoStrategy: ProgramasStrategy
    {
        public string nome => "Feijao";
        public string alimento => "Feijao";
        public int potencia => 9;
        public int tempo => 480;
        public string instrucao => "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.";
        public string stringAquecimento => "@";
    }
}
