using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMOC360.API.Service.Interfaces;
using PMOC360.Domain.Models;
using System.Collections.Generic;
using System.Xml;

namespace PMOC360.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientesController : ControllerBase
	{
		private readonly IClienteService _clienteService;

		public ClientesController(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[HttpGet("ObterClientes")]
		public IActionResult ObterClientes()
		{

			try
			{
				var list = _clienteService.GetAll();

				string json = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("ObterClientePorId")]
		public IActionResult ObterClientePorId(int id)
		{
			try
			{
				var cliente = _clienteService.GetForId(id);

				string json = JsonConvert.SerializeObject(cliente, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Cadastrar")]
		public IActionResult IncluirCliente([FromBody] ClienteModel model)
		{
			try
			{
				var output = _clienteService.Incluir(model);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("Alterar")]
		public IActionResult AlterarCliente([FromBody] ClienteModel model)
		{
			try
			{
				var output = _clienteService.Alterar(model);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("Desativar")]
		public IActionResult DesativarCliente(int id, string user)
		{
			try
			{
				var output = _clienteService.Excluir(id, user);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
