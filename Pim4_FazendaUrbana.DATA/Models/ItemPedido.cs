using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Models
{
    [Table("ItemPedido")]
    public partial class ItemPedido
    {
        [Key]
        [Column("idItemPedido")]
        public int IdItemPedido { get; set; }
        [Column("idPedido")]
        public int IdPedido { get; set; }

        [Column("idProduto")]
        public int IdProduto { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("valorUn")]
        public decimal ValorUn { get; set; }

        [ForeignKey("IdPedido")]
        [InverseProperty("Itens")]
        public virtual Pedido Pedido { get; set; }

        [ForeignKey("IdProduto")]
        public virtual Produto Produto { get; set; }

    }
}
