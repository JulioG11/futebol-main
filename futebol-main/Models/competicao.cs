using System.ComponentModel.DataAnnotations.Schema;

namespace futebol.Models
{
    [Table("competicao", Schema = "futebol")]
    public class competicao
    {
        public string nome_competicao { get; set; } //chave primária
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
    }
}
