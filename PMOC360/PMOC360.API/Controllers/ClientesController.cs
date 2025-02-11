using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMOC360.API.Service.Interfaces;
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
	}
}
