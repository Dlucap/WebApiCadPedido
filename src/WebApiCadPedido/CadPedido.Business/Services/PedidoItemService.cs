using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Interfaces.IServices;
using CadPedido.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadPedido.Business.Services
{
  public class PedidoItemService : IPedidoItemService
  {
    private readonly IPedidoItemRepository _pedidoItemRepository;

    public PedidoItemService(IPedidoItemRepository pedidoItemRepository)
    {
      _pedidoItemRepository = pedidoItemRepository;
    }

    public async Task<bool> Adicionar(PedidoItem pedidoItem)
    {
      if (VerificaPedidoJaExiste(pedidoItem.PedidoId))
        return false;

      await _pedidoItemRepository.Adicionar(pedidoItem);
      return true;
    }


    public async Task<bool> Atualizar(PedidoItem pedidoItem)
    {
      if (VerificaItemPedidoJaExiste(pedidoItem.Id))
        return false;

      await _pedidoItemRepository.Atualizar(pedidoItem);
      return true;
    }
       
    public async Task<bool> Remover(Guid id)
    {
      var cliente = _pedidoItemRepository.ObterPedidoItemPorId(id);

      if (cliente is not null)
        return false;

      await _pedidoItemRepository.Remover(id);

      return true;
    }

    private bool VerificaItemPedidoJaExiste(Guid id)
    {
      return _pedidoItemRepository.VerificaItemPedidoJaExiste(id);
    }

    private bool VerificaPedidoJaExiste(Guid pedidoId)
    {
      return _pedidoItemRepository.VerificaPedidoJaExiste(pedidoId);
    }
    public void Dispose()
    {
      _pedidoItemRepository?.Dispose();
    }
  }
}
