using System;
using System.Text.Json.Serialization;

namespace CadPedido.Business.Models
{
  public class PedidoItem : Entity
  {      
    public Guid PedidoId { get; set; }
    public Guid ProdutoId { get; set; }       
    public int Quantidade { get; set; }       
    public decimal Total { get; set; }
    /*EF Relation*/
    [JsonIgnore]
    public Pedido Pedido { get; set; }
    [JsonIgnore]
    public Produto Produto { get; set; }
  }
}
