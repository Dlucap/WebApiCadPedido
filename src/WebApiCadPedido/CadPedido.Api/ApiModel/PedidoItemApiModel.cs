using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadPedido.Api.ApiModel
{
  public class PedidoItemApiModel
  {
    [Key]
    public Guid Id { get; set; }      
    public Guid PedidoId { get; set; }
    public Guid ProdutoId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal Total { get; set; }
    

  }
}
