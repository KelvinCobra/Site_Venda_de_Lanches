using LanchesMvc.Models;
using LanchesMvc.Repositories;
using LanchesMvc.Repositories.Interfaces;
using LanchesMvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMvc.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILanchesRepository _lanchesRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILanchesRepository lanchesRepository, CarrinhoCompra carrinhoCompra)
        {
            _lanchesRepository = lanchesRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }

        [Authorize]
        public RedirectToActionResult AdicionarItemNOCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.
                FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public RedirectToActionResult RemoverItemDoCarrinho(int lancheId)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.
                FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
