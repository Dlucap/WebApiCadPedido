using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Models;
using CadPedido.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CadPedido.Data.Repository
{
  public class PedidoItemRepository : Repository<PedidoItem>, IPedidoItemRepository
  {
    public PedidoItemRepository(ApiDbContext context) : base(context)
    {

    }

    public async Task<PedidoItem> ObterPedidoItemPorId(Guid id)
    {
      return await Db.PedidoItem.AsNoTracking()        
        .FirstOrDefaultAsync(c => c.Id == id);
    }
  }
}
