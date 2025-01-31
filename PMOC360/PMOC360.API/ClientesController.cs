using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMOC360.Service.Dto;
using PMOC360.Service.Interfaces;

namespace PMOC360.API
{
	[ApiController]
	[Route("api/[controller]")]	
	public class ClientesController : ControllerBase
	{
		private readonly IClienteService _clienteService;

		public ClientesController(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[HttpGet]
		public IEnumerable<ClienteDto> ObterClientes()
		{
			return _clienteService.GetAll();
		}
	}
}
