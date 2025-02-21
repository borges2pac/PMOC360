using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMOC360.API.Services.Interfaces;
using PMOC360.Domain.Models;
using System.Reflection;

namespace PMOC360.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EquipamentosController : ControllerBase
	{
		private readonly IEquipamentoService _service;

		public EquipamentosController(IEquipamentoService service)
		{
			_service = service;
		}

		[HttpPost("EquipamentoCadastrar")]
		public IActionResult Cadastrar([FromBody] EquipamentoModel model)
		{
			try
			{
				var output = _service.Incluir(model);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetEquipamentos")]
		public IActionResult ListaEquipamentos(int clienteId)
		{

			try
			{
				var output = _service.GetAllForId(clienteId);

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
