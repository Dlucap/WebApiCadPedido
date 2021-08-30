using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Models;
using CadPedido.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

    public bool VerificaItemPedidoJaExiste(Guid id)
    {
      return Buscar(item => item.Id == id).Result.Any();
    }

    public bool VerificaPedidoJaExiste(Guid pedidoId)
    {
      return Buscar(item => item.PedidoId == pedidoId).Result.Any();
    }
  }
}
