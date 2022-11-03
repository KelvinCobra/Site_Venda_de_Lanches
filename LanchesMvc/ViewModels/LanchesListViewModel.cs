using LanchesMvc.Models;

namespace LanchesMvc.ViewModels
{
    public class LanchesListViewModel
    { 
         
         public IEnumerable<Lanches> Lanches { get; set; }
        
          public string CategoriaAtual { get; set; }
    }
}
