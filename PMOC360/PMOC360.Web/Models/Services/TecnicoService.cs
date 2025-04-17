using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;

namespace PMOC360.Web.Models.Services
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

		public string Excluir(int id, int empresaId, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TecnicoModel> GetAll(int empresaId)
		{
			try
			{
				return _repository.GetTecnicos(empresaId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<TecnicoModel> GetAllForId(int id, int empresaId)
		{
			throw new NotImplementedException();
		}

		public TecnicoModel GetForId(int id, int empresaId)
		{
			throw new NotImplementedException();
		}

		public string Incluir(TecnicoModel model)
		{
			string output = string.Empty;

			try
			{
				var retornoExecução = _repository.CadastrarTecnico(model);

				if (retornoExecução)
					output = "Técnico cadastrado com sucesso!";
				else
					output = "Falha ao cadastrar o técnico.";
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}
	}
}
