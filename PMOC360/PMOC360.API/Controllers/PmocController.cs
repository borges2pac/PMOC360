using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMOC360.API.Service.Interfaces;
using PMOC360.API.Services.Interfaces;
using PMOC360.Domain.Models;

namespace PMOC360.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PmocController : ControllerBase
	{
		private readonly IPmocModeloService _modeloService;
		private readonly IPmocModeloItensService _itemService;

		public PmocController(IPmocModeloService modeloService, IPmocModeloItensService itemService)
		{
			_modeloService = modeloService;
			_itemService = itemService;
		}

		[HttpPost("InserirModelo")]
		public IActionResult InserirModelo([FromBody] PmocModeloModel model)
		{
			try
			{
				var output = _modeloService.Incluir(model);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("InserirItemModelo")]
		public IActionResult InserirItemModelo([FromBody] ModeloItensModel model)
		{
			try
			{
				var output = _itemService.Incluir(model);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetPmocModelo")]
		public IActionResult GetPmocModelo(int id)
		{
			try
			{
				var output = _modeloService.GetForId(id);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetAllPmocModelo")]
		public IActionResult GetAllPmocModelo(int empresaId)
		{
			try
			{
				var output = _modeloService.GetAllForId(empresaId);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetAllItensForModelo")]
		public IActionResult GetAllItensForModelo(int id)
		{
			try
			{
				var output = _itemService.GetAllForId(id);

				string json = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);

				return Ok(json);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetItemForModelo")]
		public IActionResult GetItemForModelo(int id)
		{
			try
			{
				var output = _itemService.GetAllForId(id);

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
