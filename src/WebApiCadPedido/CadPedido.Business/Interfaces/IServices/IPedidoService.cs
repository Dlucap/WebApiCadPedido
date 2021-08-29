using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces.IServices
{
  public interface IPedidoService : IDisposable
  {
    Task<bool> Adicionar(Pedido fornecedor);
    Task<bool> Atualizar(Pedido fornecedor);
    Task<bool> Remover(Guid id);
  }
}
