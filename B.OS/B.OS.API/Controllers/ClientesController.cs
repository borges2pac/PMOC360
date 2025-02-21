using B.OS.API.Models;
using B.OS.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace B.OS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientesController : ControllerBase
	{
		private readonly IClientesService _service;

		public ClientesController(IClientesService service)
		{
			_service = service;
		}

		[HttpGet("GetAllClientes")]
		public IActionResult GetClientes()
		{
			try
			{
				var retorno = _service.GetAllClientes().ToList();

				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet("GetCliente")]
		public IActionResult GetCliente(int id)
		{
			var cliente = _service.GetCliente(id);

			if (cliente == null)
				return NotFound();

			return Ok();
		}

		[HttpPost]
		public IActionResult PostCliente([FromBody]Cliente cliente)
		{
			_service.InsertCliente(cliente);
			return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
		}

		[HttpPut]
		public IActionResult PutCliente([FromBody] Cliente cliente)
		{
			if (id != cliente.Id)
				return BadRequest();

			_context.Entry(cliente).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCliente(int id)
		{
			var cliente = await _context.Clientes.FindAsync(id);
			if (cliente == null)
				return NotFound();

			_context.Clientes.Remove(cliente);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
