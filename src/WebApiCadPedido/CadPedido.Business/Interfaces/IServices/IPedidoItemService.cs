using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces.IServices
{
  public interface IPedidoItemService : IDisposable
  {
    Task<bool> Adicionar(PedidoItem pedidoItem);
    Task<bool> Atualizar(PedidoItem pedidoItem);
    Task<bool> Remover(Guid id);
  }
}
