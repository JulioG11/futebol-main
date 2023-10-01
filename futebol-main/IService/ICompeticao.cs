using futebol.Models;

namespace futebol.IService
{
    public interface ICompeticao
    {
        competicao Create(competicao Competicao);
        List<competicao> FindAll();
        competicao Update(competicao Competica);
        void Delete(string nome_competicao);
    }
}
