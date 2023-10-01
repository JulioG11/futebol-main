using futebol.Data;
using futebol.IService;
using futebol.Models;

namespace futebol.Services
{
    public class competicaoService : ICompeticao
    {
        private Context _context;
        public competicaoService(Context context)
        {
            _context = context;
        }
        public competicao Create(competicao Competicao)
        {
            try
            {
                _context.Add(Competicao);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Competicao;
        }

        public List<competicao> FindAll()
        {
            return _context.competicao.ToList();
        }

        public competicao Update(competicao Competicao)
        {
            if (!Exists(Competicao.nome_competicao)) return new competicao();
            var result = _context.competicao.SingleOrDefault(c => c.nome_competicao.Equals(Competicao.nome_competicao));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(Competicao);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return Competicao;
        }

        public void Delete(string nome_competicao)
        {
            var result = _context.competicao.SingleOrDefault(c => c.nome_competicao.Equals(nome_competicao));
            if (result != null)
            {
                try
                {
                    _context.competicao.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool Exists(string nome_competicao)
        {
            return _context.competicao.Any(c => c.nome_competicao.Equals(nome_competicao));
        }
    }
}
