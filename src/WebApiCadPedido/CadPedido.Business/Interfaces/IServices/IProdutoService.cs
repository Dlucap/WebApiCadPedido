using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces.IServices
{
  public interface IProdutoService
  {
    Task<bool> Adicionar(Produto fornecedor);
    Task<bool> Atualizar(Produto fornecedor);
    Task<bool> Remover(Guid id);
  }
}
