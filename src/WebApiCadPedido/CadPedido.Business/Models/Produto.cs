namespace CadPedido.Business.Models
{
  public class Produto : Entity
  {
    public string Nome { get; set; }    
    public decimal Preco { get; set; }
    public bool Ativo { get; set; }

  }
}
