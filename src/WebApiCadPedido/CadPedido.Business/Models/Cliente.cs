namespace CadPedido.Business.Models
{
  public class Cliente : Entity
  {
    public string Nome { get; set; }

    /*EF*/
    public Pedido Pedido { get; set; }
  }
}
