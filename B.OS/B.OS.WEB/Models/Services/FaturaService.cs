using B.OS.WEB.Models.Repository.Interfaces;
using B.OS.WEB.Models.Services.Interface;
using B.OS.WEB.Models.ViewModels;
using X.PagedList;

namespace B.OS.WEB.Models.Services
{
	public class FaturaService : IFaturaService
	{
		private readonly IFaturaRepository _repository;
		private readonly IClienteRepository _cliente;

		public FaturaService(IFaturaRepository repository, IClienteRepository cliente)
		{
			_repository = repository;
			_cliente = cliente;
		}

		public async Task<IPagedList<FaturaGridViewModel>> BuscarPorTermo(string termo, int pagina = 1, int tamanhoPagina = 10)
		{
			try
			{
				FaturaGridViewModel model = new FaturaGridViewModel();
				List<FaturaGridViewModel> resultados = new List<FaturaGridViewModel>();

				var faturas = (List<TabFatura>)_repository.GetAllAsync().Result;

				foreach (var fatura in faturas) 
				{
					model = new FaturaGridViewModel()
					{
						Codigo = fatura.Codigo,
						Cliente = _cliente.GetByIdAsync(fatura.ClienteId).Result.Nome.ToString(),
						Data = fatura.Data,
						Total = fatura.Total,
						Pago = fatura.Pago == "S" ? "SIM" : "NÃO",
					};

					resultados.Add(model);
				}

				if (!String.IsNullOrEmpty(termo))
				{
					resultados = resultados.FindAll(e => e.pesquisaTermo.Any(tp => tp.ToLower().Contains(termo.ToLower())));
				}

				return await resultados.ToPagedListAsync(pagina, tamanhoPagina);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task InsertAsync(TabFatura entity)
		{
			try
			{
				//VERIFICA O MAIOR NÚMERO DE ID INSERIDO
				var lista = _repository.GetAllAsync();

				var id = lista.Result.OrderByDescending(u => u.Codigo).FirstOrDefault();

				//INSERE UM NOVO ID
				//id = id == 0 ? 1 : (id + 1);

				//INSERE O DATE TIME NOW
				//INSERE NA TABELA

				return _repository.InsertAsync(entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
