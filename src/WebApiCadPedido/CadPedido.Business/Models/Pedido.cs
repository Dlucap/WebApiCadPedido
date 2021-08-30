using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CadPedido.Business.Models
{
  public class Pedido : Entity
  {       
    public Guid ClienteId { get; set; }

   // [JsonIgnore]
    public decimal Total { get; set; }

    public IEnumerable<PedidoItem> PedidoItem { get; set; }

    /*EF Relation*/
    [JsonIgnore]
    public Cliente Cliente { get; set; }
  }
}
