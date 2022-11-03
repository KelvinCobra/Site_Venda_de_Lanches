using LanchesMvc.Models;

namespace LanchesMvc.Repositories.Interfaces
{
    public interface ILanchesRepository
    {
        IEnumerable<Lanches> Lanches { get; }
        IEnumerable<Lanches> LanchesPreferidos { get; }
        Lanches GetLanchesById (int lancheId);


    }
}
