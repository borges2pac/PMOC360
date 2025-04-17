using X.PagedList;

namespace B.OS.WEB.Models.Repository.Interfaces
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task<IPagedList<T>> BuscarPorTermo(string termo, int pagina = 1, int tamanhoPagina = 10);

		Task InsertAsync(T entity);

		Task<T> GetByIdAsync(int id);

		Task<IEnumerable<T>> GetAllAsync();

		Task UpdateAsync(T entity);

		Task DeleteAsync(int id);
	}
}
