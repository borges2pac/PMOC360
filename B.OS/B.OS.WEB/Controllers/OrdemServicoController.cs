using B.OS.WEB.Models;
using B.OS.WEB.Models.Services.Interface;
using B.OS.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace B.OS.WEB.Controllers
{
	public class OrdemServicoController : Controller
	{
		private readonly IOrdemServicoService _service;

		public OrdemServicoController(IOrdemServicoService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index(string search, int page = 1)
		{
			IPagedList<OSGridViewModel> lista = null;

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
	}
}

