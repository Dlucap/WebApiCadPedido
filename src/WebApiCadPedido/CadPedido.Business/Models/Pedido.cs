using System.Collections.Generic;

namespace CadPedido.Business.Models
{
  public class Pedido : Entity
  {       
    public string ClienteId { get; set; }
 
    public decimal Total { get; set; }

    public IEnumerable<PedidoItem> PedidoItem { get; set; }

    public Cliente Cliente { get; set; }
  }
}
