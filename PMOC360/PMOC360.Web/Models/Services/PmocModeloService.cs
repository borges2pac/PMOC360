using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace PMOC360.Web.Models.Services
{
	public class PmocModeloService : IPmocModeloService
	{
		private readonly IPmocModeloRepository _repository;

		public PmocModeloService(IPmocModeloRepository repository)
		{
			_repository = repository;
		}

		public string Alterar(PmocModeloModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, int empresaId, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PmocModeloModel> GetAll(int empresaId)
		{
			try
			{
				return _repository.ImportarListaPmocModelo(empresaId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<PmocModeloModel> GetAllForId(int id, int empresaId)
		{
			throw new NotImplementedException();
		}

		public PmocModeloModel GetForId(int id, int empresaId)
		{
			try
			{
				return _repository.ImportarPmocModelo(id, empresaId).Result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Incluir(PmocModeloModel model)
		{
			throw new NotImplementedException();
		}
	}
}
