using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Models;
using CadPedido.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CadPedido.Data.Repository
{
  public class PedidoRepository : Repository<Pedido>, IPedidoRepository
  {

    public PedidoRepository(ApiDbContext context) : base(context)
    {

    }

    public async Task<Pedido> ObterPedidoPorId(Guid id)
    {
      return await Db.Pedido.AsNoTracking()
         .Include(itm => itm.PedidoItem)
         .FirstOrDefaultAsync(c => c.Id == id);
    }
  }
}
