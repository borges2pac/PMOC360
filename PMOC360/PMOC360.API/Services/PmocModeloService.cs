using PMOC360.API.Services.Interfaces;
using PMOC360.Domain.Interfaces;
using PMOC360.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace PMOC360.API.Services
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

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PmocModeloModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PmocModeloModel> GetAllForId(int id)
		{
			List<PmocModeloModel> modeloList = new List<PmocModeloModel>();

			try
			{
				var list = _repository.ImportarListaPmocModelo(id);

				foreach (DataRow dr in list.Rows)
				{
					PmocModeloModel model = new PmocModeloModel() 
					{
						ID = Convert.ToInt32(dr["ID"]),
						Nome = Convert.ToString(dr["NOME"]),
						EmpresaId = Convert.ToInt32(dr["COD_EMPRESA"]),
						UserAlt = Convert.ToString(dr["USR_ALT"]),
						UserCad = Convert.ToString(dr["USR_CAD"]),
						DataAlt = string.IsNullOrEmpty(Convert.ToString(dr["DATA_ALT"])) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ALT"]),
						DataCad = Convert.ToDateTime(dr["DATA_CAD"]),
					};

					modeloList.Add(model);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return modeloList;
		}

		public PmocModeloModel GetForId(int id)
		{
			PmocModeloModel model = new PmocModeloModel();

			try
			{
				var modelo = _repository.ImportarPmocModelo(id);

				if (modelo != null && modelo.Rows.Count == 1)
				{
					foreach (DataRow dr in modelo.Rows)
					{
						model = new PmocModeloModel()
						{
							ID = Convert.ToInt32(dr["ID"]),
							Nome = Convert.ToString(dr["NOME"]),
							EmpresaId = Convert.ToInt32(dr["COD_EMPRESA"]),
							UserAlt = Convert.ToString(dr["USR_ALT"]),
							UserCad = Convert.ToString(dr["USR_CAD"]),
							DataAlt = string.IsNullOrEmpty(Convert.ToString(dr["DATA_ALT"])) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ALT"]),
							DataCad = Convert.ToDateTime(dr["DATA_CAD"]),
						};
					}
				}
				else
				{
					throw new Exception("Falha ao obter o modelo por id.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return model;
		}

		public string Incluir(PmocModeloModel model)
		{
			try
			{
				return _repository.Incluir(model);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
