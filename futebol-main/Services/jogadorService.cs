using futebol.Data;
using futebol.IService;
using futebol.Models;
using futebol.View;
using Microsoft.EntityFrameworkCore.Storage;

namespace futebol.Services
{
    public class jogadorService : IJogador
    {
        private Context _context;
        public jogadorService(Context context)
        {
            _context = context;
        }

        public jogador Create(jogadorView Jogador)
        {
            try
            {
                var novoJogador = new jogador {
                    nome_jogador = Jogador.nome_jogador,
                    nome_time = Jogador.nome_time,
                    duracao_contrato = Jogador.duracao_contrato,
                    nacionalidade = Jogador.nacionalidade,
                    data_nascimento = Jogador.data_nascimento
                };
                _context.jogador.Add(novoJogador);
                _context.SaveChanges();
                return novoJogador; 
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<jogador> FindAll(string nome_time)
        {
            return _context.jogador.Where(j => j.nome_time == nome_time).ToList();
        }

        public jogador Update(jogadorView Jogador)
        {
            var existingJogador = _context.jogador.FirstOrDefault(j => j.id_jogador == Jogador.id_jogador);

            if (existingJogador == null)
            {
                return null; 
            }
            try
            {
                existingJogador.nome_jogador = Jogador.nome_jogador;
                existingJogador.duracao_contrato = Jogador.duracao_contrato;
                existingJogador.nacionalidade = Jogador.nacionalidade;
                existingJogador.data_nascimento = Jogador.data_nascimento;
                //nesse context não deve atualizar a propriedade 'nome_time' pois é uma chave estrangeira
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return existingJogador; 
        }


        public void Delete(long id_jogador)
        {
            var result = _context.jogador.SingleOrDefault(t => t.id_jogador.Equals(id_jogador));
            if (result != null)
            {
                try
                {
                    _context.jogador.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void TransferJogador(long id_jogador, string timeOrigem, string timeDestino)
        {
            try
            {
                var jogador  = _context.jogador.SingleOrDefault(j => j.id_jogador == id_jogador);

                if (jogador != null)
                {
                    // Verifique se os times de origem e destino são válidos
                    var sourceTeamExists = _context.time.Any(t => t.nome_time == timeOrigem);
                    var destinationTeamExists = _context.time.Any(t => t.nome_time == timeDestino);

                    if (sourceTeamExists && destinationTeamExists)
                    {
                        // Atualize o nome_time do jogador
                        jogador.nome_time = timeDestino;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
