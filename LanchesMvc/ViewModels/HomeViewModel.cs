using LanchesMvc.Models;

namespace LanchesMvc.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanches> LanchesPreferidos { get; set; }
    }
}
