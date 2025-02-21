using PMOC360.API.Services.Interfaces;
using PMOC360.Domain.Interfaces;
using PMOC360.Domain.Models;
using System.Data;
using System.Reflection;

namespace PMOC360.API.Services
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

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ModeloItensModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ModeloItensModel> GetAllForId(int id)
		{
			List<ModeloItensModel> list = new List<ModeloItensModel>();

			try
			{
				var dt = _repository.ImportarListaPmocPorModelo(id);

				foreach (DataRow dr in dt.Rows)
				{
					ModeloItensModel model = new ModeloItensModel() 
					{
						ID = Convert.ToInt32(dr["ID"]),
						ModeloID = Convert.ToInt32(dr["MODLEO_ID"]),
						Descricao = Convert.ToString(dr["DESCRICAO"]),
						Frequencia = Convert.ToString(dr["FREQUENCIA"]),
						Observacao = Convert.ToString(dr["OBSERVACAO"]),
						EmpresaId = Convert.ToInt32(dr["COD_EMPRESA"]),
						UserAlt = Convert.ToString(dr["USR_ALT"]),
						UserCad = Convert.ToString(dr["USR_CAD"]),
						DataAlt = string.IsNullOrEmpty(Convert.ToString(dr["DATA_ALT"])) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ALT"]),
						DataCad = Convert.ToDateTime(dr["DATA_CAD"])
					};

					list.Add(model);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return list;
		}

		public ModeloItensModel GetForId(int id)
		{
			ModeloItensModel model = new ModeloItensModel();

			try
			{
				var item = _repository.ImportarListaPmocPorId(id);

				if (item != null && item.Rows.Count == 1)
				{
					foreach (DataRow dr in item.Rows)
					{
						model = new ModeloItensModel()
						{
							ID = Convert.ToInt32(dr["ID"]),
							ModeloID = Convert.ToInt32(dr["MODLEO_ID"]),
							Descricao = Convert.ToString(dr["DESCRICAO"]),
							Frequencia = Convert.ToString(dr["FREQUENCIA"]),
							Observacao = Convert.ToString(dr["OBSERVACAO"]),
							EmpresaId = Convert.ToInt32(dr["COD_EMPRESA"]),
							UserAlt = Convert.ToString(dr["USR_ALT"]),
							UserCad = Convert.ToString(dr["USR_CAD"]),
							DataAlt = string.IsNullOrEmpty(Convert.ToString(dr["DATA_ALT"])) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ALT"]),
							DataCad = Convert.ToDateTime(dr["DATA_CAD"])
						};
					}
				}
				else
				{
					throw new Exception("Falha ao obter o item do modelo por id.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return model;
		}

		public string Incluir(ModeloItensModel model)
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
