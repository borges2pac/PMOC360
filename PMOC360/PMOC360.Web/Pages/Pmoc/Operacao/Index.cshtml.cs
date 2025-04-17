using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.Services.Interfaces;
using PMOC360.Web.Models.ViewModels;
using static Dapper.SqlMapper;
using static System.Net.Mime.MediaTypeNames;

namespace PMOC360.Web.Pages.Pmoc.Operacao
{
    public class IndexModel : PageModel
    {
		private readonly IPmocOperacaoService _service;

		public IndexModel(IPmocOperacaoService service)
		{
			_service = service;
		}

		[BindProperty]
		public PmocOperacaoCadViewModel OperacaoCad { get; set; }

		[BindProperty]
		public PmocOperacaoViewModel Operacao { get; private set; }

		[BindProperty]
		public IEnumerable<ItemViewModel> Itens { get; set; }

		[BindProperty]
		public string BarCode { get; set; }

		[BindProperty]
		public DateTime DataVisita { get; set; } = DateTime.Now.Date;

		[BindProperty]
		public int ClienteId { get; set; }

		[BindProperty]
		public int EquipamentoId { get; set; }

		[BindProperty]
		public int ModeloId { get; set; }

		[BindProperty]
		public IFormFile? Arquivo1 { get; set; }
		
		[BindProperty]
		public IFormFile? Arquivo2 { get; set; }
		
		[BindProperty]
		public IFormFile? Arquivo3 { get; set; }
		
		[BindProperty]
		public IFormFile? Arquivo4 { get; set; }

		public string AlertMessage { get; private set; }

		public void OnGet()
        {
			
        }

		public IActionResult OnPostSearch()
		{
			var operacao = _service.GetDadosOperacao(BarCode);

			if (operacao != null)
			{
				Operacao = operacao;
			}

			return Page();
		}

		[HttpPost]
		public IActionResult OnPostSave()
		{
			try
			{
				OperacaoCad.Equipamento_Id = EquipamentoId;
				OperacaoCad.Modelo_Id = ModeloId;
				OperacaoCad.Cliente_Id = ClienteId;
				OperacaoCad.Dt_Ultima_Visita = DataVisita;
				OperacaoCad.Cod_Empresa = 2;
				OperacaoCad.UserCad = "Administrador";

				#region Processar Imagens
				using var memoryStream = new MemoryStream();

				// Verifica se é uma imagem
				var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".gif" };

				if (Arquivo1 != null || Arquivo1.Length != 0)
				{
					var extensao1 = Path.GetExtension(Arquivo1.FileName).ToLower();

					if (!extensoesPermitidas.Contains(extensao1))
					{
						AlertMessage = "Apenas arquivos de imagem (.jpg, .png, .gif) são permitidos.";
						return Page();
					}

					Arquivo1.CopyToAsync(memoryStream);
					var imagemBytes = memoryStream.ToArray();

					OperacaoCad.ImagemDadosOne = imagemBytes;
				}

				if (Arquivo2 != null || Arquivo2.Length != 0)
				{
					var extensao2 = Path.GetExtension(Arquivo2.FileName).ToLower();

					if (!extensoesPermitidas.Contains(extensao2))
					{
						AlertMessage = "Apenas arquivos de imagem (.jpg, .png, .gif) são permitidos.";
						return Page();
					}

					Arquivo2.CopyToAsync(memoryStream);
					var imagemBytes = memoryStream.ToArray();

					OperacaoCad.Imagens.ImagemDadosTwo = imagemBytes;
				}

				if (Arquivo3 != null || Arquivo3.Length != 0)
				{
					var extensao3 = Path.GetExtension(Arquivo3.FileName).ToLower();

					if (!extensoesPermitidas.Contains(extensao3))
					{
						AlertMessage = "Apenas arquivos de imagem (.jpg, .png, .gif) são permitidos.";
						return Page();
					}

					Arquivo3.CopyToAsync(memoryStream);
					var imagemBytes = memoryStream.ToArray();

					OperacaoCad.Imagens.ImagemDadosThree = imagemBytes;
				}

				if (Arquivo4 != null || Arquivo4.Length != 0)
				{
					var extensao4 = Path.GetExtension(Arquivo4.FileName).ToLower();

					if (!extensoesPermitidas.Contains(extensao4))
					{
						AlertMessage = "Apenas arquivos de imagem (.jpg, .png, .gif) são permitidos.";
						return Page();
					}

					Arquivo4.CopyToAsync(memoryStream);
					var imagemBytes = memoryStream.ToArray();

					OperacaoCad.Imagens.ImagemDadosFour = imagemBytes;
				}
				#endregion


				var teste = OperacaoCad;

				var retorno = _service.InsertOperacao(OperacaoCad);

				if (retorno)
					return Page();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}

			return Page();
		}

		//public async Task<IActionResult> OnGetDeleteAsync(int id)
		//{
		//	var item = id;

		//	if (id > 0 || id != null)
		//	{
		//		var retorno = _cliente.DesativarCliente(id);
		//		TempData["AlertMessage"] = retorno.ToString();
		//	}

		//	return RedirectToPage();
		//}

		//		CREATE TABLE Imagens(
		//			Id INT IDENTITY(1,1) PRIMARY KEY,
		//			Nome NVARCHAR(255),
		//			Imagem VARBINARY(MAX)
		//		);
		//  <img src="data:image/png;base64,@Convert.ToBase64String(img.ImagemDados)" width="100">

	}
}
