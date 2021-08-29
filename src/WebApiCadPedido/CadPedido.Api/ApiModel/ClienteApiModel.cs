using System;
using System.ComponentModel.DataAnnotations;

namespace CadPedido.Api.ApiModel
{
  public class ClienteApiModel
  {
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Nome { get; set; }
  }
}
