using LanchesMvc.Context;
using LanchesMvc.Models;
using LanchesMvc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMvc.Repositories
{
    public class LanchesRepository : ILanchesRepository
    {
        private readonly AppDbContext _context;

        public LanchesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanches> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanches> LanchesPreferidos => _context.Lanches.
                                    Where(l => l.IsLanchePreferido);

        public Lanches GetLanchesById(int lancheId)
        {
           return _context.Lanches.FirstOrDefault(l=> l.LancheId == lancheId);
        }
    }
}
