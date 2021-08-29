using System;
using System.ComponentModel.DataAnnotations;

namespace CadPedido.Api.ApiModel
{
  public class ProdutoApiModel
  {
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal Preco { get; set; }

    public bool Ativo { get; set; }
  }
}
