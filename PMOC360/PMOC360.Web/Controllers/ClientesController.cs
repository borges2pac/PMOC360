using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMOC360.Service.Interfaces;
using PMOC360.Web.ViewModels;
using System.Collections.Generic;

namespace PMOC360.Web.Controllers
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
		public IEnumerable<ClienteViewModel> ObterClientes()
		{
			List<ClienteViewModel> clientes = new List<ClienteViewModel>();

			try
			{
				var list = _clienteService.GetAll();


				foreach (var item in list)
				{
					var cliente = new ClienteViewModel
					{
						ID = item.ID,
						Nome = item.Nome,
						Documento = item.Documento,
						Email = item.Email,
						Telefone = item.Telefone,
						Responsavel = item.Responsavel,
						Endereco = item.Endereco,
						Numero = item.Numero,
						Complemento = item.Complemento,
						Bairro = item.Bairro,
						Cidade = item.Cidade,
						Estado = item.Estado,
						Cep = item.Cep,
						Ativo = item.Ativo,
						EmpresaId = item.EmpresaId,
						UserCad = item.UserCad,
						UserAlt = item.UserAlt,
						DataCad = item.DataCad == null ? new DateTime() : Convert.ToDateTime(item.DataCad),
						DataAlt = item.DataAlt == null ? new DateTime() : Convert.ToDateTime(item.DataAlt)
					};

					clientes.Add(cliente);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return clientes;
		}
	}
}
