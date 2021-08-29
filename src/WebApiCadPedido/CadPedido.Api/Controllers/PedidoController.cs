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
  public class PedidoController : ControllerBase
  {
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IPedidoService _pedidoService;
    private readonly IPedidoItemService _pedidoItemService;
    private readonly IMapper _mapper;

    public PedidoController(IPedidoRepository pedidoRepository,
                            IPedidoService pedidoService,
                            IPedidoItemService pedidoItemService,
                            IMapper mapper)

    {
      _pedidoRepository = pedidoRepository;
      _pedidoService = pedidoService;
      _pedidoItemService = pedidoItemService;
      _mapper = mapper;
    }

    /// <summary>
    /// Retorna todos os Pedidos 
    /// </summary>
    /// <returns>Retorna todos os clientes (não recomendado)</returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PedidoApiModel>>> GetPedido()
    {
      var pedidos = await _pedidoRepository.ObterTodos();
      var pedido = _mapper.Map<IEnumerable<PedidoApiModel>>(pedidos);

      if (pedido == null)
        return NotFound();

      return Ok(pedido);
    }

    /// <summary>
    /// Retorna Pedidos  Por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retorna Cliente Por ID</returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> GetCliente(Guid id)
    {
      var pedido = await ObterPedidoPorId(id);

      if (pedido == null)
        return NotFound();

      return Ok(pedido);
    }

    /// <summary>
    /// Cadastrar um novo pedido
    /// </summary>
    /// <param name="pedidoApiModel"></param>
    /// <returns>Cadastrar um novo cliente</returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpPost]
    public async Task<ActionResult<Pedido>> PostCliente(PedidoApiModel pedidoApiModel)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var pedidoEntity = _mapper.Map<Pedido>(pedidoApiModel);

      await _pedidoRepository.Adicionar(pedidoEntity);
      pedidoApiModel.Id = pedidoEntity.Id;

      foreach (var item in pedidoEntity.PedidoItem)
      {
        item.PedidoId = pedidoEntity.Id;
        await _pedidoItemService.Adicionar(item);
      }

      return CreatedAtAction("GetCompra", new { id = pedidoApiModel.Id }, pedidoApiModel);
    }

    /// <summary>
    /// Atualiza dados do pedido 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="clienteApiModel"></param>
    /// <returns>Atualiza dados do cliente </returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(Guid id, PedidoApiModel pedidoApiModel)
    {
      if (id != pedidoApiModel.Id)
        return BadRequest();

      if (!ModelState.IsValid)
        return BadRequest();

      await _pedidoRepository.Atualizar(_mapper.Map<Pedido>(pedidoApiModel));

      return NoContent();
    }

    /// <summary>
    /// Deleta o cliente por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Deleta o cliente por Id</returns>
    /// <response code="204"> Item Deletado com sucesso</response>
    /// <response code="404"> Requisição</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      var pedidos = await ObterPedidoPorId(id);

      if (pedidos == null)
        return NotFound();

      await _pedidoRepository.Remover(id);

      return NoContent();
    }

    private async Task<PedidoApiModel> ObterPedidoPorId(Guid id)
    {
      var pedido = await _pedidoRepository.ObterPorId(id);
      return _mapper.Map<PedidoApiModel>(pedido);
    }

  }
}
