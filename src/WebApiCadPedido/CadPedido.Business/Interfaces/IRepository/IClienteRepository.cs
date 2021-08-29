using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces
{
  public interface IClienteRepository : IRepository<Cliente>
  {
    Task<Cliente> ObterClientePorId(Guid id);
  }
}
