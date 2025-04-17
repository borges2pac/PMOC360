using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using System.Data;
using System.Reflection;

namespace PMOC360.Web.Models.Services
{
	public class PmocModeloItensService : IPmocModeloItensService
	{
		private readonly IPmocModeloItensRepository _repository;

		public PmocModeloItensService(IPmocModeloItensRepository repository)
		{
			_repository = repository;
		}

		public string Alterar(ModeloItensModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, int empresaId, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ModeloItensModel> GetAll(int empresaId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ModeloItensModel> GetAllForId(int id, int empresaId)
		{
			try
			{
				return _repository.ImportarListaItensPorModelo(id, empresaId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ModeloItensModel GetForId(int id, int empresaId)
		{
			try
			{
				return _repository.ImportarListaItensPorId(id, empresaId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Incluir(ModeloItensModel model)
		{
			throw new NotImplementedException();
		}
	}
}
