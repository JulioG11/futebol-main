using futebol.Models;
using futebol.View;

namespace futebol.IService
{
    public interface IJogador
    {
        jogador Create(jogadorView Jogador);
        List<jogador> FindAll(string nome_time);
        jogador Update(jogadorView Jogador);
        jogador TransferJogador(long id_jogador, string timeOrigem, string timeDestino);
        void Delete(long id_jogador);
    }
}
