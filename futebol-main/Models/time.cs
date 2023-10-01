using futebol.IService;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace futebol.Models
{
    [Table("time", Schema = "futebol")]
    public class time
    {
        public string nome_time { get; set; } //chave primária
        public DateTime fundacao { get; set; }
        public string nome_estadio { get; set; }

        public virtual List<jogador> jogadores { get; set;}
    }
}
