using B.OS.WEB.Models;
using B.OS.WEB.Models.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace B.OS.WEB.Controllers
{
	public class ClienteController : Controller
	{
		private readonly IClienteService _service;

		public ClienteController(IClienteService service)
		{
			_service = service;	
		}

		public async Task<IActionResult> Index(string search, int page = 1)
		{
			IPagedList<TabCliente> lista = null;

			try
			{		
				lista = await _service.BuscarPorTermo(search, page, 10);

				ViewBag.Search = search;
			}
			catch (Exception ex)
			{
				ViewBag.AlertaTela = 0;
				ViewBag.MensagemRetorno = "ERRO DE PROCESSAMENTO! ENTRE EM CONTATO COM O SUPORTE!";
			}

			return View(lista);
		}

		[HttpPost]
		public async Task<IActionResult> Save(TabCliente model)
		{
			ChaveValor retorno = new ChaveValor();
			retorno.Codigo = "0";

			try
			{
				if(model.IncluirAlterar == 0)
				{
					await _service.InsertAsync(model);
				}
				else
				{
					await _service.UpdateAsync(model);
				}

				retorno.Codigo = "1";
				retorno.Descricao = "DADOS CADASTRADOS COM SUCESSO!";
			}
			catch (Exception ex)
			{
				retorno.Codigo = "0";
				retorno.Descricao = "ERRO DE PROCESSAMENTO! CONTATE O SUORTE!";

				return BadRequest(retorno);
			}

			return Ok(retorno);
		}

		[HttpGet]
		public async Task<IActionResult> Remove(short id)
		{
			try
			{
				_service.DeleteAsync(id);

				TempData["AlertaTela"] = 1;
				TempData["MensagemRetorno"] = "CADASTRO REMOVIDO COM SUCESSO!";
			}
			catch (Exception ex)
			{
				TempData["AlertaTela"] = 0;
				TempData["MensagemRetorno"] = "ERRO AO DELETAR CADASTRO! CONTATE O SUPORTE!";
			}

			return Ok();
		}

		public async Task<IActionResult> Form(int incluirAlterar, int id)
		{
			TabCliente retorno = new TabCliente();

			try
			{
				//ALTERAÇÃO
				if (incluirAlterar == 1)
				{
					//BUSCAR O CADASTRO
					retorno = await _service.GetByIdAsync(id);

					//IMPORTAR PARA A TELA FORM
				}

				retorno.IncluirAlterar = incluirAlterar;
			}
			catch (Exception ex)
			{
				ViewBag.AlertaTela = 0;
				ViewBag.MensagemRetorno = "ERRO DE PROCESSAMENTO! ENTRE EM CONTATO COM O SUPORTE!";
			}

			return View("Form", retorno);
		}
	}
}
