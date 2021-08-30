using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Interfaces.IServices;
using CadPedido.Business.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CadPedido.Business.Services
{
  public class PedidoService : IPedidoService
  {
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
      _pedidoRepository = pedidoRepository;
    }
    public async Task<bool> Adicionar(Pedido pedido)
    {
      if (VerificaClienteJaExiste(pedido.Id))
        return false;
     
      await _pedidoRepository.Adicionar(pedido);

      return true;
    }

    public async Task<bool> Atualizar(Pedido pedido)
    {
      if (VerificaClienteJaExiste(pedido.Id))
        return false;

      await _pedidoRepository.Atualizar(pedido);
      return true;
    }

    public async Task<bool> Remover(Guid id)
    {
      var cliente = _pedidoRepository.ObterPedidoPorId(id);

      if (cliente is not null)
        return false;

      await _pedidoRepository.Remover(id);

      return true;
    }

    private bool VerificaClienteJaExiste(Guid id)
    {
      return _pedidoRepository.Buscar(ped => ped.Id == id).Result.Any();
    }

    public void Dispose()
    {
      _pedidoRepository?.Dispose();
    }
  }
}
