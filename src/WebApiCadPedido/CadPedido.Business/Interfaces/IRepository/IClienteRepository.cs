using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces.IRepository
{
  public interface IClienteRepository : IRepository<Cliente>
  {
    Task<Cliente> ObterClientePorId(Guid id);
  }
}
