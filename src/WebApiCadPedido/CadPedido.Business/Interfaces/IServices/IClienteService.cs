using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces.IServices
{
  public interface IClienteService : IDisposable
  {
    Task<bool> Adicionar(Cliente fornecedor);
    Task<bool> Atualizar(Cliente fornecedor);
    Task<bool> Remover(Guid id);
  }
}
