using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces.IRepository
{
  public interface IPedidoItemRepository : IRepository<PedidoItem>
  {
    Task<PedidoItem> ObterPedidoItemPorId(Guid id);
    bool VerificaItemPedidoJaExiste(Guid id);
    bool VerificaPedidoJaExiste(Guid pedidoId);
  }
}
