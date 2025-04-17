using B.OS.WEB.Models.ViewModels;
using X.PagedList;

namespace B.OS.WEB.Models.Services.Interface
{
	public interface IFaturaService
	{
		Task<IPagedList<FaturaGridViewModel>> BuscarPorTermo(string termo, int pagina = 1, int tamanhoPagina = 10);

		Task InsertAsync(TabFatura entity);
	}
}
