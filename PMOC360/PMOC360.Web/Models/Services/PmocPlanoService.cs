using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using PMOC360.Web.Models.Services.Interfaces;

namespace PMOC360.Web.Models.Services
{
	public class PmocPlanoService : IPmocPlanoService
	{
		private readonly IPmocPlanoRepository _repository;

		public PmocPlanoService(IPmocPlanoRepository repository)
		{
			_repository = repository;
		}

		public string Alterar(PmocPlanoModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, int empresaId, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PmocPlanoModel> GetAll(int empresaId)
		{
			try
			{
				return _repository.GetAllPmocPlano(empresaId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<PmocPlanoModel> GetAllForId(int id, int empresaId)
		{
			throw new NotImplementedException();
		}

		public PmocPlanoModel GetForId(int id, int empresaId)
		{
			try
			{
				return _repository.GetPmocPlanoForId(id, empresaId).Result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Incluir(PmocPlanoModel model)
		{
			throw new NotImplementedException();
		}
	}
}
