using AutoMapper;
using CadPedido.Api.ApiModel;
using CadPedido.Business.Interfaces.IRepository;
using CadPedido.Business.Interfaces.IServices;
using CadPedido.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadPedido.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProdutoController : ControllerBase
  {
    private readonly IProdutoRepository _produtoRepository;
    private readonly IProdutoService _produtoService;
    private readonly IMapper _mapper;

    public ProdutoController(IProdutoRepository produtoRepository,
                             IProdutoService produtoService,
                             IMapper mapper)
    {
      _produtoRepository = produtoRepository;
      _produtoService = produtoService;
      _mapper = mapper;
    }

    /// <summary>
    /// Retorna todos os produtos cadastrados (não recomendado)
    /// </summary>
    /// <returns></returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoApiModel>>> GetProduto()
    {
      var produtos = await _produtoRepository.ObterTodos();
      var produto = _mapper.Map<IEnumerable<ProdutoApiModel>>(produtos);

      if (produto == null)
        return NotFound();

      return Ok(produto);
    }

    /// <summary>
    /// Retorna produto por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retorna produto por Id</returns>
    ///  <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(Guid id)
    {
      var produto = await ObterProdutoPorId(id);

      if (produto == null)
        return NotFound();

      return Ok(produto);
    }

    /// <summary>
    /// Cadastra um produto
    /// </summary>
    /// <param name="value"></param>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpPost]
    public async Task<ActionResult<Produto>> Post(ProdutoApiModel produtoApiModel)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var produtoEntity = _mapper.Map<Produto>(produtoApiModel);

      await _produtoRepository.Adicionar(produtoEntity);

      return CreatedAtAction("GetCompra", new { id = produtoApiModel.Id }, produtoApiModel);
    }

    /// <summary>
    /// Atualiza um produto
    /// </summary>
    /// <param name="id"></param>
    /// <param name="produtoApiModel"></param>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, ProdutoApiModel produtoApiModel)
    {
      if (id != produtoApiModel.Id)
        return BadRequest();

      if (!ModelState.IsValid)
        return BadRequest();

      await _produtoRepository.Atualizar(_mapper.Map<Produto>(produtoApiModel));

      return NoContent();
    }

    /// <summary>
    /// Deleta um produto por Id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204"> Item Deletado com sucesso</response>
    /// <response code="404"> Requisição</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      var produto = await ObterProdutoPorId(id);

      if (produto == null)
        return NotFound();

      await _produtoRepository.Remover(id);

      return NoContent();
    }

    private async Task<ProdutoApiModel> ObterProdutoPorId(Guid id)
    {
      var produto = await _produtoRepository.ObterPorId(id);
      return _mapper.Map<ProdutoApiModel>(produto);
    }
  }
}
