using B.OS.WEB.Context;
using B.OS.WEB.Models.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using static Dapper.SqlMapper;

namespace B.OS.WEB.Models.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		private readonly OrdemServicoContext _dbContext;

		public BaseRepository(OrdemServicoContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IPagedList<T>> BuscarPorTermo(string termo, int pagina, int tamanhoPagina)
		{
			IPagedList<T> resultados;

			try
			{
				if (!String.IsNullOrEmpty(termo))
				{
					resultados = _dbContext.Set<T>().ToList()
						.Where(e => e.pesquisaTermo.Any(tp => tp.ToLower().Contains(termo.ToLower())))
						.ToPagedList(pagina, tamanhoPagina);
				}
				else
				{
					resultados = _dbContext.Set<T>().ToList().ToPagedList(pagina, tamanhoPagina);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return resultados;
		}

		public async Task InsertAsync(T entity)
		{
			try
			{
				_dbContext.Set<T>().Add(entity);
				await _dbContext.SaveChangesAsync();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public async Task<T> GetByIdAsync(int id)
		{
			try
			{
				return await _dbContext.Set<T>().FindAsync(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			try
			{
				return await _dbContext.Set<T>().ToListAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task UpdateAsync(T entity)
		{
			try
			{
				_dbContext.Set<T>().Update(entity);
				await _dbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task DeleteAsync(int id)
		{
			try
			{
				var entity = await GetByIdAsync(id);

				if (entity != null)
				{
					_dbContext.Set<T>().Remove(entity);
					await _dbContext.SaveChangesAsync();

				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
