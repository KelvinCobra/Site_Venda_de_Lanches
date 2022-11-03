using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMvc.Models
{
    [Table("CarrinhoCompraltens")]

    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set; }

        public Lanches Lanche { get; set; }

        public int Quantidade { get; set; }

        [StringLength(200)]

        public string CarrinhoCompraId { get; set; }
    }

}

