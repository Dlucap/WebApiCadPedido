using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadPedido.Api.ApiModel
{
  public class PedidoApiModel
  {

    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string ClienteId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]   
  
    public decimal Total { get; set; }

    public IEnumerable<PedidoItemApiModel> PedidoItem { get; set; }

  }
}
