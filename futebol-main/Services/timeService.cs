using futebol.IService;
using futebol.Models;
using futebol.Data;
using futebol.View;

namespace futebol.Services
{
    public class timeService : ITime
    {
        private Context _context;
        public timeService(Context context)
        {
            _context = context;
        }
        public time Create(timeView Time)
        {
            try
            {
                var novoTime = new time {
                    nome_time = Time.nome_time,
                    fundacao = Time.fundacao,
                    nome_estadio = Time.nome_estadio,
                };
                _context.time.Add(novoTime);
                _context.SaveChanges();
                return novoTime;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<time> FindAll()
        {
            return _context.time.ToList();
        }

        public time Update(timeView Time)
        {
            var existingTime = _context.time.FirstOrDefault(t => t.nome_time == Time.nome_time);
            if (existingTime == null)
            {
                return null; 
            }
            try
            {
                existingTime.nome_time = Time.nome_time;
                existingTime.fundacao = Time.fundacao;
                existingTime.nome_estadio = Time.nome_estadio;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return existingTime;
        }

        public void Delete(string nome_time)
        {
            var result = _context.time.SingleOrDefault(t => t.nome_time.Equals(nome_time));
            if (result != null)
            {
                try
                {
                    _context.time.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
