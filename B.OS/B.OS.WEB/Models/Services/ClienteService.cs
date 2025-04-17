using B.OS.WEB.Models.Repository.Interfaces;
using B.OS.WEB.Models.Services.Interface;
using System.Collections.Generic;
using X.PagedList;
using static Dapper.SqlMapper;

namespace B.OS.WEB.Models.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _repository;

		public ClienteService(IClienteRepository repository)
		{
			_repository = repository;
		}

		public async Task<IPagedList<TabCliente>> BuscarPorTermo(string termo, int pagina = 1, int tamanhoPagina = 10)
		{
			try
			{
				List<TabCliente> resultados;

				resultados = (List<TabCliente>)_repository.GetAllAsync().Result;

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

		public Task DeleteAsync(int id)
		{
			try
			{
				return _repository.DeleteAsync(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task<IEnumerable<TabCliente>> GetAllAsync()
		{
			try
			{
				return _repository.GetAllAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task<TabCliente> GetByIdAsync(int id)
		{
			try
			{
				return _repository.GetByIdAsync(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task InsertAsync(TabCliente entity)
		{
			try
			{
				//VERIFICA O MAIOR NÚMERO DE ID INSERIDO
				var lista = _repository.GetAllAsync();

				var id = lista.Result.OrderByDescending(u => u.Codigo).FirstOrDefault();

				//INSERE UM NOVO ID
				entity.Codigo = id.Codigo + 1;

				//INSERE O DATE TIME NOW
				entity.DataCadastro = DateTime.Now;

				//INSERE NA TABELA
				return _repository.InsertAsync(entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task UpdateAsync(TabCliente entity)
		{
			try
			{
				return _repository.UpdateAsync(entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
