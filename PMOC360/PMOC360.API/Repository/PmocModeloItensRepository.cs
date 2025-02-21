using PMOC360.Data;
using PMOC360.Domain.Interfaces;
using PMOC360.Domain.Models;
using System.Data;

namespace PMOC360.API.Repository
{
	public class PmocModeloItensRepository : IPmocModeloItensRepository
	{
		private readonly ISqlExecutor _sqlExecutor;

		public PmocModeloItensRepository(ISqlExecutor sqlExecutor)
		{
			_sqlExecutor = sqlExecutor;
		}

		public string Alterar(ModeloItensModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ModeloItensModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public ModeloItensModel GetForId(int id)
		{
			throw new NotImplementedException();
		}

		public DataTable ImportarListaPmocPorId(int id)
		{
			try
			{
				return _sqlExecutor.ImportarListaPmocPorId(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable ImportarListaPmocPorModelo(int id)
		{
			try
			{
				return _sqlExecutor.ImportarListaPmocPorModelo(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Incluir(ModeloItensModel model)
		{
			string output = string.Empty;

			try
			{
				var retornoExecucao = _sqlExecutor.CadastrarItensModelo(model);

				if (!retornoExecucao)
				{
					throw new Exception("Falha ao cadastrar os itens do modelo.");
				}
				else
				{
					output = "Itens do Modelo cadastrados com sucesso.";
				}				
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}
	}
}
