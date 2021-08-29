using AutoMapper;
using CadPedido.Api.ApiModel;
using CadPedido.Business.Interfaces;
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
  public class ClienteController : ControllerBase
  {
    private readonly IClienteRepository _clienteRepository;
    private readonly IClienteService _clienteService;
    private readonly IMapper _mapper;

    public ClienteController(IClienteRepository clienteRepository, IClienteService clienteService,IMapper mapper)
    {
      _clienteRepository = clienteRepository;
      _clienteService = clienteService;
      _mapper = mapper;
    }

    /// <summary>
    /// Retorna todos os clientes 
    /// </summary>
    /// <returns>Retorna todos os clientes (não recomendado)</returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteApiModel>>> GetCliente()
    {
      var clientes = await _clienteRepository.ObterTodos();
      var cliente = _mapper.Map<IEnumerable<ClienteApiModel>>(clientes);

      if (cliente == null)
        return NotFound();

      return Ok(cliente);
    }

    /// <summary>
    /// Retorna Cliente Por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retorna Cliente Por ID</returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(Guid id)
    {
      var cliente = await ObterClientePorId(id);
     
      if (cliente == null)
        return NotFound();

      return Ok(cliente);
    }

    /// <summary>
    /// Cadastrar um novo cliente
    /// </summary>
    /// <param name="clienteApiModel"></param>
    /// <returns>Cadastrar um novo cliente</returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(ClienteApiModel clienteApiModel)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var clienteEntity = _mapper.Map<Cliente>(clienteApiModel);

      await _clienteRepository.Adicionar(clienteEntity);
      
      return CreatedAtAction("GetCompra", new { id = clienteApiModel.Id }, clienteApiModel);

    }

    /// <summary>
    /// Atualiza dados do cliente 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="clienteApiModel"></param>
    /// <returns>Atualiza dados do cliente </returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(Guid id, ClienteApiModel clienteApiModel)
    {
      if (id != clienteApiModel.Id)
        return BadRequest();

      if (!ModelState.IsValid)
        return BadRequest();

      await _clienteRepository.Atualizar(_mapper.Map<Cliente>(clienteApiModel));

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
      var compraApi = await ObterClientePorId(id);

      if (compraApi == null)
        return NotFound();

      await _clienteRepository.Remover(id);

      return NoContent();
    }

    /// <summary>
    /// Metodo auxiliar para obter todos os clientes por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retorna o cliente desejado</returns>
    private async Task<ClienteApiModel> ObterClientePorId(Guid id)
    {
      var compra = await _clienteRepository.ObterPorId(id);
      return _mapper.Map<ClienteApiModel>(compra);
    }
    
  }
}
