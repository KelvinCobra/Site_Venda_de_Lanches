using LanchesMvc.Models;
using LanchesMvc.Repositories;
using LanchesMvc.Repositories.Interfaces;
using LanchesMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMvc.Controllers
{
    public class LanchesController : Controller
    {
        private readonly ILanchesRepository _lancheRepository;
        public LanchesController(ILanchesRepository lanchesRepository)
        {
            _lancheRepository = lanchesRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanches> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LanchesListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanches> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                          .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }

            return View("~/Views/Lanches/List.cshtml", new LanchesListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }

}
