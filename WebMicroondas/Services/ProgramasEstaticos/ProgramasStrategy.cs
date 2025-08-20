namespace WebMicroondas.Services.ProgramasEstaticos
{
    public interface ProgramasStrategy
    {
        public string nome { get; }
        public string alimento { get;}
        public int potencia { get;}
        public int tempo { get; }
        public string instrucao { get; }
        public string stringAquecimento { get; }
    }
}
