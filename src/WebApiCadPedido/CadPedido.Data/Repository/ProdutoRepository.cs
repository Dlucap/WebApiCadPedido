using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Models;
using CadPedido.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CadPedido.Data.Repository
{
  public class ProdutoRepository : Repository<Produto>, IProdutoRepository
  {
    public ProdutoRepository(ApiDbContext context) : base(context)
    {

    }

    public  async Task<Produto> ObterProdutoPorId(Guid id)
    {
      return await Db.Produto.AsNoTracking()
          .FirstOrDefaultAsync(p => p.Id == id);
    }
  }
}
