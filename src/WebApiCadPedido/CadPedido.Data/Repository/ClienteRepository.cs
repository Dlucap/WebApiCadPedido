using CadPedido.Business.Interfaces;
using CadPedido.Business.Models;
using CadPedido.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CadPedido.Data.Repository
{
  public class ClienteRepository : Repository<Cliente>, IClienteRepository
  {

    public ClienteRepository(ApiDbContext context) : base(context)
    {

    }

    public async Task<Cliente> ObterClientePorId(Guid id)
    {
      return await Db.Cliente.AsNoTracking()
          .FirstOrDefaultAsync(c => c.Id == id);
    }      
        
  }
}
