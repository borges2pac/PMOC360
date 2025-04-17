using Dapper;
using Microsoft.Data.SqlClient;
using PMOC360.Web.Models.Data;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using System.Data;

namespace PMOC360.Web.Models.Repository
{
	public class EquipamentoRepository : IEquipamentoRepository
	{
		private readonly IDapperRepository _dapper;

		public EquipamentoRepository(IDapperRepository dapper)
		{
			_dapper = dapper;
		}

		public bool CadastrarEquipamentos(EquipamentoModel model)
		{
			bool result = false;

			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@clienteId", model.Cliente_ID, DbType.Int32);
				sprParams.Add("@equipamento", model.Equipamento, DbType.String);
				sprParams.Add("@fabricante", model.Fabricante, DbType.String);
				sprParams.Add("@modelo", model.Modelo, DbType.String);
				sprParams.Add("@potencia", model.Potencia, DbType.String);
				sprParams.Add("@serie", model.Serie, DbType.String);
				sprParams.Add("@tag", model.Tag, DbType.String);
				sprParams.Add("@tipo", model.Tipo_Atividade, DbType.String);
				sprParams.Add("@ambiente", model.Ambiente, DbType.String);
				sprParams.Add("@fixos", model.Fixos, DbType.Int32);
				sprParams.Add("@flutuantes", model.Flutuantes, DbType.Int32);
				sprParams.Add("@modeloId", model.Pmoc_Modelo_ID, DbType.Int32);
				sprParams.Add("@codigo", model.Cod_Etiqueta, DbType.Int64);
				sprParams.Add("@empresa", model.Cod_Empresa, DbType.Int32);
				sprParams.Add("@user", model.User_Cad, DbType.String);

				_dapper.execute_sp<int?>($"spr_CADASTRAR_EQUIPAMENTO", sprParams, commandType: CommandType.StoredProcedure);

				result = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return result;
		}

		public List<EquipamentoModel> GetEquipamentos(int clienteId, int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@clienteId", clienteId, DbType.Int32);
				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return _dapper.GetAll<EquipamentoModel>($"spr_GET_EQUIPAMENTO_CLIENTE", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public EquipamentoModel GetEquipamentoByCode(int barCode)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@barCode", barCode, DbType.Int32);

				return _dapper.GetChange<EquipamentoModel>($"spr_GET_EQUIPAMENTO_BY_CODE", sprParams, commandType: CommandType.StoredProcedure).Result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
