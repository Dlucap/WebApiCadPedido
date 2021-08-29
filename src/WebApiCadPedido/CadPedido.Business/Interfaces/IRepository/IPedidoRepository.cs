using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces.IRepository
{
  public interface IPedidoRepository : IRepository<Pedido>
  {
    Task<Pedido> ObterPedidoPorId(Guid id);
  }
}
