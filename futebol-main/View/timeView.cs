using futebol.Models;

namespace futebol.View
{
    public class timeView
    {
        public string nome_time { get; set; } //chave primária
        public DateTime fundacao { get; set; }
        public string nome_estadio { get; set; }
    }
}
