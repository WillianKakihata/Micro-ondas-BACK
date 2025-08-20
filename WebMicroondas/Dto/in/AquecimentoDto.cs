using System.ComponentModel.DataAnnotations;
using WebMicroondas.Enuns;

namespace WebMicroondas.Dto.@in
{
    public class AquecimentoDto
    {
        [Range(0, 10, ErrorMessage = "the maximum power is 1 and the minimum is 10")]
        public int? potencia { get; set; }

        [Range(1, 120, ErrorMessage = "the maximum time is 120 seconds and the minimum is 1 second")]
        public int tempo { get; set; }

        public bool execucao { get; set; } = false;

        public StatusMicroondasEnum status { get; set; }
    }
}
