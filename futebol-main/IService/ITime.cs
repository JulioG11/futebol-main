using futebol.Models;
using futebol.View;

namespace futebol.IService
{
    public interface ITime
    {
        time Create(timeView Time);
        List<time> FindAll();
        time Update(timeView Time);
        void Delete(string nome_time);
    }
}
