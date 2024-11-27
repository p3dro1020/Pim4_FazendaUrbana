using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Models
{
    public class Pedido
    {
        [Key]
        [Column("idPedido")]
        public int IdPedido { get; set; }

        [Required]
        [Column("qtdItem")]
        public int QtdItem { get; set; }

        [Required]
        [Column("valorTotal")]
        public decimal ValorTotal { get; set; }

        [Required]
        [Column("dataCompra")]
        public DateTime DataCompra { get; set; }

        [InverseProperty("Pedido")]
        public virtual ICollection<ItemPedido> Itens { get; set; }

    }
}
