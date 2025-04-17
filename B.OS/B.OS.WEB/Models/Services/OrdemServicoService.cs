using B.OS.WEB.Models.Repository.Interfaces;
using B.OS.WEB.Models.Services.Interface;
using B.OS.WEB.Models.ViewModels;
using X.PagedList;

namespace B.OS.WEB.Models.Services
{
	public class OrdemServicoService : IOrdemServicoService
	{
		private readonly IOrdemServicoRepository _repository;
		private readonly IClienteRepository _cliente;

		public OrdemServicoService(IOrdemServicoRepository repository, IClienteRepository cliente)
		{
			_repository = repository;
			_cliente = cliente;
		}

		public Task<IPagedList<OSGridViewModel>> BuscarPorTermo(string termo, int pagina = 1, int tamanhoPagina = 10)
		{
			try
			{
				OSGridViewModel model = new OSGridViewModel();
				List<OSGridViewModel> resultados = new List<OSGridViewModel>();

				var ordemServico = (List<TabOrdemServico>)_repository.GetAllAsync().Result;

				foreach (var os in ordemServico) 
				{
					model = new OSGridViewModel() 
					{
						Codigo = os.Codigo,
						Cliente = _cliente.GetByIdAsync(os.ClienteId).Result.Nome.ToString(),						
						Abertura = os.Abertura,
						Equipamento = os.Equipamento,
						Status = os.Status,
					};

					resultados.Add(model);
				}

				if (!String.IsNullOrEmpty(termo))
				{
					resultados = resultados.FindAll(e => e.pesquisaTermo.Any(tp => tp.ToLower().Contains(termo.ToLower())));
				}

				return resultados.ToPagedListAsync(pagina, tamanhoPagina);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task InsertAsync(TabOrdemServico entity)
		{
			throw new NotImplementedException();
		}
	}
}
