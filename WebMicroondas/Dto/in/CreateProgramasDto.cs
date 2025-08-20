namespace WebMicroondas.Dto.@in
{
    public class CreateProgramasDto
    {
        public string nome { get; set; }
        public int potencia { get; set; }
        public int tempo { get; set; }
        public string? instrucao { get; set; }

        public string stringAquecimento { get; set; }
    }
}
