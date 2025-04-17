using B.OS.WEB.Models.ViewModels;
using X.PagedList;

namespace B.OS.WEB.Models.Services.Interface
{
	public interface IOrdemServicoService
	{
		Task<IPagedList<OSGridViewModel>> BuscarPorTermo(string termo, int pagina = 1, int tamanhoPagina = 10);

		Task InsertAsync(TabOrdemServico entity);
	}
}
