using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMOC360.API.Services.Interfaces;
using PMOC360.Domain.Models;

namespace PMOC360.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TecnicoController : ControllerBase
	{
		private readonly ITecnicoService _service;

		public TecnicoController(ITecnicoService service)
		{
			_service = service;
		}

		[HttpPost("CadastrarTecnico")]
		public IActionResult CadastrarTecnico([FromBody] TecnicoModel model)
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

		[HttpGet("GetTecnicos")]
		public IActionResult GetTecnicos()
		{
			try
			{
				var output = _service.GetAll();

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
