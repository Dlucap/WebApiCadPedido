using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Interfaces.IRepository
{
  public interface IProdutoRepository : IRepository<Produto>
  {
    Task<Produto> ObterProdutoPorId(Guid id);
  }
}
