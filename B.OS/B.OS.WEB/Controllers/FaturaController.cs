
using B.OS.WEB.Models;
using B.OS.WEB.Models.Services.Interface;
using B.OS.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace B.OS.WEB.Controllers
{
	public class FaturaController : Controller
	{
		private readonly IFaturaService _serviceFatura;
		private readonly IFaturaItemService _serviceItem;

		public FaturaController(IFaturaService serviceFatura, IFaturaItemService serviceItem)
		{
			_serviceFatura = serviceFatura;
			_serviceItem = serviceItem;
		}

		public async Task<IActionResult> Index(string search, int page = 1)
		{
			IPagedList<FaturaGridViewModel> lista = null;

			try
			{
				lista = await _serviceFatura.BuscarPorTermo(search, page, 10);

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
