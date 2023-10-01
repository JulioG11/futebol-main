namespace futebol.View
{
    public class jogadorView
    {
        public long id_jogador { get; set; } //chave primária
        public string nome_jogador { get; set; }
        public string nome_time { get; set; } //chave estrangeira
        public long duracao_contrato { get; set; }
        public string nacionalidade { get; set; }
        public DateTime data_nascimento { get; set; }
    }
}
