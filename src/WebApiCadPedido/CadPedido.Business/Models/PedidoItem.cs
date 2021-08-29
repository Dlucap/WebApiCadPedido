using System;

namespace CadPedido.Business.Models
{
  public class PedidoItem : Entity
  {      
    public Guid PedidoId { get; set; }
    public Guid ProdutoId { get; set; }       
    public int Quantidade { get; set; }       
    public decimal Total { get; set; }
    public Pedido Pedido { get; set; }
    public Produto Produto { get; set; }
  }
}
