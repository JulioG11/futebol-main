using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace futebol.Models
{
    [Table("jogador", Schema = "mini_mundo_futebol")]
    public class jogador
    {
        [Key()]
        public long id_jogador { get; set; } //chave primária
        public string nome_jogador { get; set; }
        public string nome_time { get; set; } //chave estrangeira
        public time Time { get; set; }
        public long duracao_contrato { get; set; }
        public string nacionalidade { get; set; }
        public DateTime data_nascimento { get; set; }
    }
}
