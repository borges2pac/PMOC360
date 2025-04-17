using X.PagedList;

namespace B.OS.WEB.Models.Services.Interface
{
	public interface IClienteService
	{
		Task<IPagedList<TabCliente>> BuscarPorTermo(string termo, int pagina = 1, int tamanhoPagina = 10);

		Task InsertAsync(TabCliente entity);

		Task<TabCliente> GetByIdAsync(int id);

		Task<IEnumerable<TabCliente>> GetAllAsync();

		Task UpdateAsync(TabCliente entity);

		Task DeleteAsync(int id);
	}
}
