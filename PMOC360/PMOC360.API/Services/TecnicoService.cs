using PMOC360.API.Services.Interfaces;
using PMOC360.Domain.Interfaces;
using PMOC360.Domain.Models;

namespace PMOC360.API.Services
{
	public class TecnicoService : ITecnicoService
	{
		private readonly ITecnicoRepository _repository;

		public TecnicoService(ITecnicoRepository repository)
		{
			_repository = repository;
		}

		public string Alterar(TecnicoModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TecnicoModel> GetAll()
		{			
			try
			{
				return _repository.GetAll();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<TecnicoModel> GetAllForId(int id)
		{
			throw new NotImplementedException();
		}

		public TecnicoModel GetForId(int id)
		{
			throw new NotImplementedException();
		}

		public string Incluir(TecnicoModel model)
		{
			string output = string.Empty;

			try
			{
				output = _repository.Incluir(model);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}
	}
}
