using PMOC360.API.Services.Interfaces;
using PMOC360.Domain.Interfaces;
using PMOC360.Domain.Models;
using System.Data;

namespace PMOC360.API.Services
{
	public class EquipamentoService : IEquipamentoService
	{
		private readonly IEquipamentoRepository _repository;
		private readonly IClienteRepository _clienterepository;

		public EquipamentoService(IEquipamentoRepository repository, IClienteRepository clienterepository)
		{
			_repository = repository;
			_clienterepository = clienterepository;
		}

		public string Alterar(EquipamentoModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EquipamentoModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EquipamentoModel> GetAllForId(int id)
		{
			List<EquipamentoModel> list = new List<EquipamentoModel>();
			EquipamentoModel model = new EquipamentoModel();

			try
			{
				var retornoExecução = _repository.GetEquipamentos(id);

				foreach (DataRow dr in retornoExecução.Rows)
				{
					model.ID = Convert.ToInt32(dr[0].ToString());
					model.ClienteID = dr[1].ToString();
					model.Equipamento = dr[2].ToString();
					model.Fabricante = dr[3].ToString();
					model.Modelo = dr[4].ToString();
					model.Potencia = dr[5].ToString();
					model.Serie = dr[6].ToString();
					model.Tag = dr[7].ToString();
					model.TipoAtividade = dr[8].ToString();
					model.Ambiente = dr[9].ToString();
					model.Fixos = Convert.ToInt32(dr[10].ToString());
					model.Flutuantes = Convert.ToInt32(dr[11].ToString());
					model.PmocModeloID = Convert.ToInt32(dr[12].ToString());
					model.barCode = dr[13].ToString();
					model.Ativo = Convert.ToBoolean(dr[14].ToString()) == true ? 1 : 0;
					model.EmpresaId = Convert.ToInt32(dr[15].ToString());
					model.UserAlt = dr[16].ToString();
					model.UserCad = dr[17].ToString();
					model.DataAlt = string.IsNullOrEmpty(dr[18].ToString()) ? null : Convert.ToDateTime(dr[18].ToString());
					model.DataCad = string.IsNullOrEmpty(dr[19].ToString()) ? null : Convert.ToDateTime(dr[19].ToString());


					list.Add(model);
					model = new EquipamentoModel();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return list;
		}		

		public EquipamentoModel GetForId(int id)
		{
			throw new NotImplementedException();
		}

		public string Incluir(EquipamentoModel model)
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
