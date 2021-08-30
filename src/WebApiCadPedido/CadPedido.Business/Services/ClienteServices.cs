using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Interfaces.IServices;
using CadPedido.Business.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CadPedido.Business.Services
{
  public class ClienteServices : IClienteService
  {   
    private readonly IClienteRepository _clienteRepository;
    
    public ClienteServices(IClienteRepository clienteRepository)
    {
      _clienteRepository = clienteRepository;      
    } 

    public async Task<bool> Adicionar(Cliente cliente)
    {
      if (VerificaClienteJaExiste(cliente.Nome))     
        return false;     

      await _clienteRepository.Adicionar(cliente);

      return true;
    }

    public async Task<bool> Atualizar(Cliente cliente)
    {
      if (VerificaClienteJaExiste(cliente.Nome))
        return false;

      await _clienteRepository.Atualizar(cliente);
      return true;
    }
     
    public async Task<bool> Remover(Guid id)
    {
      var cliente = _clienteRepository.ObterClientePorId(id);

      if(cliente is not null)
        return false;

      await _clienteRepository.Remover(id);

      return true;
    }

    private bool VerificaClienteJaExiste(String nome)
    {
      return _clienteRepository.Buscar(cli => cli.Nome == nome).Result.Any();
    }

    public void Dispose()
    {   
      _clienteRepository?.Dispose();
    }
  }
}
