using System.ComponentModel.DataAnnotations;
using WebMicroondas.Enuns;

namespace WebMicroondas.Dto.@in
{
    public class AquecerDto{
        public int? potencia { get; set; }
        public int tempo { get; set; }
        public bool execucao { get; set; } = false;
        public StatusMicroondasEnum status { get; set; }
    }
}
