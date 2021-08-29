using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Interfaces.IServices;
using CadPedido.Business.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CadPedido.Business.Services
{
  public class ProdutoService : IProdutoService
  {
    private readonly IProdutoRepository _produtoRepository;


    public ProdutoService(IProdutoRepository produtoRepository)
    {
      _produtoRepository = produtoRepository;
    }

    public async Task<bool> Adicionar(Produto produto)
    {
      if (VerificaProdutoJaExiste(produto.Nome))
        return false;

      await _produtoRepository.Adicionar(produto);

      return true;
    }

    public async Task<bool> Atualizar(Produto produto)
    {
      if (VerificaProdutoJaExiste(produto.Nome))
        return false;

      await _produtoRepository.Atualizar(produto);
      return true;
    }

    public async Task<bool> Remover(Guid id)
    {
      var cliente = _produtoRepository.ObterProdutoPorId(id);

      if (cliente is not null)
        return false;

      await _produtoRepository.Remover(id);

      return true;
    }

    public void Dispose()
    {
      _produtoRepository?.Dispose();
    }

    private bool VerificaProdutoJaExiste(String nome)
    {
      return _produtoRepository.Buscar(prod => prod.Nome == nome).Result.Any();
    }
  }
}
