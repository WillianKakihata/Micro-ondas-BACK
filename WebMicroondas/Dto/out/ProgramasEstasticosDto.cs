using WebMicroondas.Enuns;

namespace WebMicroondas.Dto.@out{
    public class ProgramasEstasticosDto{
        public string nome { get; set; }
        public string alimento { get; set; }
        public int potencia { get; set; }
        public int tempo { get; set; }
        public string instrucao { get; set; }
        public string stringAquecimento { get; set; }
        public bool execucao { get; set; }
        public StatusMicroondasEnum status { get; set; }

    }
}
