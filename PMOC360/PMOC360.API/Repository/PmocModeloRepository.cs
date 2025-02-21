using PMOC360.Data;
using PMOC360.Domain.Interfaces;
using PMOC360.Domain.Models;
using System.Data;

namespace PMOC360.API.Repository
{
	public class PmocModeloRepository : IPmocModeloRepository
	{
		private readonly ISqlExecutor _sqlExecutor;

		public PmocModeloRepository(ISqlExecutor sqlExecutor)
		{
			_sqlExecutor = sqlExecutor;
		}

		public string Alterar(PmocModeloModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PmocModeloModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public PmocModeloModel GetForId(int id)
		{
			throw new NotImplementedException();
		}

		public DataTable ImportarListaPmocModelo(int id)
		{
			DataTable dt = new DataTable();

			try
			{
				dt = _sqlExecutor.ImportarListaPmocModelo(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dt;
		}

		public DataTable ImportarPmocModelo(int id)
		{
			DataTable dt = new DataTable();

			try
			{
				dt = _sqlExecutor.ImportarPmocModelo(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dt;
		}

		public string Incluir(PmocModeloModel model)
		{
			string output = string.Empty;

			try
			{
				var retornoExecucao = _sqlExecutor.CadastrarModelo(model);

				output = retornoExecucao.ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}
	}
}
